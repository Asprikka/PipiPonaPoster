using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public static class ExcelDatabaseStateListExtension
    {
        // 2021-07-03_17-30-u8942-protocol.xlsx - an example name
        private static readonly int EXCEL_DB_REQUIRED_NAME_LENGTH = 36;

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

                string dbName = new FileInfo(dbPath).Name;
                if (dbName.Length != EXCEL_DB_REQUIRED_NAME_LENGTH)
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
                dbDateTimes.Add((db, GetDatabaseDateTime(db.Name)));

            var orderedDbDt = dbDateTimes.OrderByDescending(dbdt => dbdt.dateTime);

            return orderedDbDt.FirstOrDefault(dbdt => !dbdt.dbState.IsRead).dbState;
        }

        private static DateTime GetDatabaseDateTime(string dbName)
        {
            // 2021-07-03_17-30-u8942-protocol.xlsx
            return new DateTime(
                year: int.Parse(dbName.Substring(0, 4)),
                month: int.Parse(dbName.Substring(5, 2)),
                day: int.Parse(dbName.Substring(8, 2)),
                hour: int.Parse(dbName.Substring(11, 2)),
                minute: int.Parse(dbName.Substring(14, 2)),
                second: 0
            );
        }
    }
}
