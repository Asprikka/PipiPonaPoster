using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public static class ExcelDatabaseStateListExtension
    {
        public static void Update(this List<ExcelDatabaseState> excelDatabaseStateList)
        {
            if (!Directory.Exists(Program.sendingOptions.ExcelDatabasesFolderPath))
            {
                MessageBox.Show("Папки с эксель базами данных не существует!", "(!) ОШИБКА (!)",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw new Exception("Папки с эксель базами данных не существует!");
            }

            var dbs = Directory.EnumerateFiles(Program.sendingOptions.ExcelDatabasesFolderPath, ".xlsx").ToList();

            foreach (string dbPath in dbs)
            {
                // whether the db is currently exists in excelDatabaseStateList
                if (excelDatabaseStateList.FirstOrDefault(dbState => dbState.Path == dbPath) is not null)
                    continue;

                excelDatabaseStateList.Add(new ExcelDatabaseState(dbPath));
            }
        }

        public static bool TryGetCurrentExcelDatabase(this List<ExcelDatabaseState> excelDatabaseStateList, out ExcelDatabaseState outDbs)
        {            
            ExcelDatabaseState freshestDB = FindFreshestDatabaseOrDefault(excelDatabaseStateList);
            outDbs = freshestDB;

            return outDbs is not null;
        }

        private static ExcelDatabaseState FindFreshestDatabaseOrDefault(List<ExcelDatabaseState> excelDatabaseStateList)
        {
            List<(ExcelDatabaseState dbState, DateTime dateTime)> dbDateTimes = new();

            foreach (var db in excelDatabaseStateList)
                dbDateTimes.Add((db, GetDatabaseDateTime(db.Path)));

            var orderedDbDt = dbDateTimes.OrderByDescending(dbdt => dbdt.dateTime);

            return orderedDbDt.FirstOrDefault(dbdt => !dbdt.dbState.IsRead).dbState;
        }

        private static DateTime GetDatabaseDateTime(string dbPath)
        {
            // 2021-07-03_17-30-u8942-protocol.xlsx
            return new DateTime(
                year: int.Parse(dbPath.Substring(0, 4)),
                month: int.Parse(dbPath.Substring(5, 2)),
                day: int.Parse(dbPath.Substring(8, 2)),
                hour: int.Parse(dbPath.Substring(11, 2)),
                minute: int.Parse(dbPath.Substring(14, 2)),
                second: 0
            );
        }
    }
}
