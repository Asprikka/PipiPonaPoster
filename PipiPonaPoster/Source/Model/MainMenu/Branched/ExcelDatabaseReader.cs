using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

using OfficeOpenXml;
using EPPlus.DataExtractor;

#pragma warning disable CS8632

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public abstract class ExcelDatabaseReader
    {
        protected int errorCount = 0;

        public event Func<string, Task> OutputTerminalUpdatedAsync;
        public event Func<int, Task> ProgressBarUpdatedAsync;


        public static bool ValidateOptions() => Program.sendingOptions != null && Program.mailOptions != null;

        public async Task<ConcurrentQueue<RecipientData>> GetSortedDataOrNullAsync() => await Task.Run(() =>
        {
            try
            {
                List<RecipientData>? data = ReadExcelDatabase();
                return SortData(data);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Оплатить"))
                {
                    string msg = $"Ваша база данных Excel НЕОПЛАЧЕНА! Некоторые поля для анализа скрыты." +
                    $"\nРассылка будет остановлена! Попробуйте запустить рассылку заново, когда у вас появится полноцення база данных.";
                    MessageBox.Show(msg, "(!) ОШИБКА (!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string msg = $"Неизвестная ошибка!\nРассылка будет остановлена!\n\nПопробуйте запустить рассылку заново.\n\nТекст ошибки:\n{ex}";
                    MessageBox.Show(msg, "(!) ОШИБКА (!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return null;
            }
        }); 


        protected List<RecipientData>? ReadExcelDatabase()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string excelDatabasePath = File.Exists(Program.sendingOptions.ExcelDatabasePath)
                ? Program.sendingOptions.ExcelDatabasePath : null;

            if (excelDatabasePath == null)
            {
                const string msg = "Указанный в параметрах файл базы данных не существует!";
                MessageBox.Show(msg, "(!) ОШИБКА (!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            using ExcelPackage package = new(new FileInfo(excelDatabasePath));

            OutputTerminalUpdatedAsync.Invoke("Выгружаем данные с эксель файла...\r\n");
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            // MAGIC NUM
            if (worksheet.Cells.Rows - 3 < Program.sendingOptions.RecipientsCount)
            {
                const string msg = "Указанное в параметрах количество получателей больше, чем есть в сформированом списке." +
                "\n\nВозможные решения проблемы:\n1) Укажите меньшее количество получателей в параметрах рассылки." +
                "\n2) Измените критерии отбора получателей (сортировка и фильтр).\n3) Проверьте размер базы данных. Возможно, она слишком мала.";

                MessageBox.Show(msg, "(!) ОШИБКА (!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            List<ExcelData> excelData = worksheet.Extract<ExcelData>()
                .WithProperty(p => p.LotNumber, "B")
                .WithProperty(p => p.BankGuarantee, "D")
                .WithProperty(p => p.CompanyName, "E")
                .WithProperty(p => p.Email1, "I")
                .WithProperty(p => p.Email2, "J")
                .WithProperty(p => p.WinsCount, "P")
                .WithProperty(p => p.TermOfPerformance, "AT")
                .GetData(3, worksheet.Dimension.End.Row - 3)
                .ToList();

            OutputTerminalUpdatedAsync.Invoke("Эксель файл загружен в программу...\r\n");
            return ConvertToRecipientsData(excelData);
        }

        protected List<RecipientData> ConvertToRecipientsData(List<ExcelData> excelData)
        {
            string s1 = $"\r\nСчитываем данные в оперативную память...\r\n";
            OutputTerminalUpdatedAsync.Invoke(s1);

            List<RecipientData> resources = ExcelData.ConvertToRecipientData(excelData, out errorCount);

            string s2 = $"\r\nДанные считаны в оперативную память.\r\nОшибка считывания была в {errorCount}/{excelData.Count} рядах данных.\r\n\r\n";
            OutputTerminalUpdatedAsync.Invoke(s2);

            return resources;
        }

        protected ConcurrentQueue<RecipientData>? SortData(List<RecipientData> resources)
        {
            if (resources == null)
                return null;

            OutputTerminalUpdatedAsync.Invoke("Проводим сортировку...\r\n\r\n\r\n");
            ProgressBarUpdatedAsync.Invoke(Program.CLEAR_PROGRESS_BAR);

            var sorted = ApplySortConditions(resources);
            var checkedres = CheckOnRecipientsCountApply(sorted);
            var cleaned = RemoveExceptionList(checkedres);

            return new ConcurrentQueue<RecipientData>(cleaned);
        }

        protected abstract List<RecipientData> ApplySortConditions(List<RecipientData> resources);

        protected static List<RecipientData>? CheckOnRecipientsCountApply(List<RecipientData> resources)
        {
            if (Program.sendingOptions.RecipientsCount < resources.Count)
            {
                resources.RemoveRange(Program.sendingOptions.RecipientsCount, resources.Count - Program.sendingOptions.RecipientsCount);
                return resources;
            }
            else
            {
                const string msg = "Указанное в параметрах количество получателей больше, чем есть в сформированом списке." +
                    "\n\nВозможные решения проблемы:\n1) Укажите меньшее количество получателей в параметрах рассылки." +
                    "\n2) Измените критерии отбора получателей (сортировка и фильтр).\n3) Проверьте размер базы данных. Возможно, она слишком мала.";

                MessageBox.Show(msg, "(!) ОШИБКА (!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        protected static List<RecipientData>? RemoveExceptionList(List<RecipientData> resources)
        {
            if (resources == null)
                return null;

            foreach (string ex in Program.sendingOptions.ExceptionAccountsList)
                resources.RemoveAll(rec => rec.Email == ex);

            return resources;
        }


        protected bool winsCountSortingRandom = false;
        protected IEnumerable<RecipientData> RandomOrder(IEnumerable<RecipientData> res)
        {
            winsCountSortingRandom = true;

            var outlist = new List<RecipientData>();
            var reslist = new List<RecipientData>(res);

            while (reslist.Count > 0)
            {
                Random r = new();

                int index = r.Next(0, reslist.Count - 1);

                outlist.Add(reslist.ElementAt(index));
                reslist.RemoveAt(index);
            }

            return outlist;
        }
    }
}
