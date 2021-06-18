using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.SendingOptions
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class SendingOptionsData
    {
        public MailingMode MailingMode { get; init; }
        public DateTime SelectedDate { get; init; }
        public int RecipientsCount { get; init; }
        public double InterestRate { get; init; }
        public int SendingSpeedForBasicAccounts { get; init; }
        public int SendingSpeedForPrebanAccounts { get; init; }
        public string ExcelDatabasePath { get; init; }
        public int MinBankGuaranteeFilter { get; init; }
        public int MaxBankGuaranteeFilter { get; init; }
        public string Password { get; init; }
        public SortingBGType SortingBGType { get; init; }
        public SortingWinsCountType SortingWinsCountType { get; init; }
        public List<string> PrebanAccountsList { get; init; }
        public List<string> ExceptionAccountsList { get; init; }
        public List<string> BasicAccountsList { get; init; }

        public SendingOptionsData()
        { }

        public override bool Equals(object obj)
        {
            if (obj is not SendingOptionsData eq)
                return false;

            bool a = this.MailingMode == eq.MailingMode
                && this.SelectedDate == eq.SelectedDate
                && this.RecipientsCount == eq.RecipientsCount
                && this.InterestRate == eq.InterestRate
                && this.SendingSpeedForBasicAccounts == eq.SendingSpeedForBasicAccounts
                && this.SendingSpeedForPrebanAccounts == eq.SendingSpeedForPrebanAccounts
                && this.ExcelDatabasePath == eq.ExcelDatabasePath
                && this.MinBankGuaranteeFilter == eq.MinBankGuaranteeFilter
                && this.MaxBankGuaranteeFilter == eq.MaxBankGuaranteeFilter
                && this.Password == eq.Password
                && this.SortingBGType == eq.SortingBGType;

            bool l1 = true, l2 = true, l3 = true;

            if (this.PrebanAccountsList == null || this.PrebanAccountsList.Count == 0)
                for (int i = 0; i < this.PrebanAccountsList.Count; i++)
                    if (this.PrebanAccountsList[i] != eq.PrebanAccountsList[i])
                    {
                        l1 = false;
                        break;
                    }

            if (this.ExceptionAccountsList == null || this.ExceptionAccountsList.Count == 0)
                for (int i = 0; i < this.ExceptionAccountsList.Count; i++)
                    if (this.ExceptionAccountsList[i] != eq.ExceptionAccountsList[i])
                    {
                        l1 = false;
                        break;
                    }

            if (this.BasicAccountsList == null || this.BasicAccountsList.Count == 0)
                for (int i = 0; i < this.BasicAccountsList.Count; i++)
                    if (this.BasicAccountsList[i] != eq.BasicAccountsList[i])
                    {
                        l1 = false;
                        break;
                    }

            return l1 && l2 && l3 && a;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }    
}
