using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class ExcelData
    {
        public string LotNumber { get; set; }
        public long BankGuarantee { get; set; }
        public string CompanyName { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public int WinsCount { get; set; }
        public DateTime TermOfPerformance { get; set; }

        public static List<RecipientData> ConvertToRecipientData(List<ExcelData> excelData, out int errorCount)
        {
            errorCount = 0;
            List<RecipientData> resources = new();

            for (int i = 0; i < excelData.Count; i++)
            {
                List<string> emailsPartOneFormatted = (excelData[i].Email1 == null) ? new()
                    : new(excelData[i].Email1
                    .Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x.Contains('@') && !x.Contains("http")).Distinct());

                List<string> emailsPartTwoFormatted = (excelData[i].Email2 == null) ? new()
                    : new(excelData[i].Email2
                    .Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x.Contains('@') && !x.Contains("http")).Distinct());

                List<string> emails = new();
                emails.AddRange(emailsPartOneFormatted);
                emails.AddRange(emailsPartTwoFormatted);

                if (emails.Count == 0)
                {
                    errorCount++;
                    continue;
                }

                foreach (string email in emails)
                    resources.Add(new RecipientData(
                        excelData[i].LotNumber,
                        excelData[i].BankGuarantee,
                        excelData[i].CompanyName,
                        email,
                        excelData[i].WinsCount,
                        excelData[i].TermOfPerformance
                    ));

                // Обновление прогресс бара произойдет ~1000 раз
                //if (i % (excelData.Count / 1000) == 0)
                //    await ProgressBarUpdated.Invoke(EXCEL_DATA_PARSING_STEP);
            }

            return resources;
        }
    }
}
