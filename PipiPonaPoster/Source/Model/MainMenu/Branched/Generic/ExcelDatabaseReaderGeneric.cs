using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class ExcelDatabaseReaderGeneric : ExcelDatabaseReader
    {
        public ExcelDatabaseReaderGeneric(string excelDatabasePath)
            : base(excelDatabasePath)
        { }

        protected override List<RecipientData> ApplySortConditions(List<RecipientData> resources)
        {
            var res1 = resources.Distinct()
                .Where(x =>
                    x.BankGuarantee >= Program.sendingOptions.MinBankGuaranteeFilter
                    &&
                    x.BankGuarantee <= Program.sendingOptions.MaxBankGuaranteeFilter
            );

            var res2 = Program.sendingOptions.SortingWinsCountType switch
            {
                SortingWinsCountType.Random => RandomOrder(res1),
                SortingWinsCountType.Ascending => res1.OrderBy(x => x.WinsCount),
                SortingWinsCountType.Descending => res1.OrderByDescending(x => x.WinsCount),
                _ => throw new Exception()
            };

            return !winsCountSortingRandom
                ? res2.ToList()
                : Program.sendingOptions.SortingBGType switch
            {
                SortingBGType.Random => RandomOrder(res2).ToList(),
                SortingBGType.Ascending => res2.OrderBy(x => x.BankGuarantee).ToList(),
                SortingBGType.Descending => res2.OrderByDescending(x => x.BankGuarantee).ToList(),
                _ => throw new Exception()
            };
        }
    }
}
