namespace PipiPonaPoster.Source.Model
{
    public record SendingOptionsDataString
    {
        public string MailingMode { get; init; }
        public string SelectedDate { get; init; }
        public string RecipientsCount { get; init; }
        public string InterestRate { get; init; } // Процентная ставка
        public string SendingSpeedForBasicAccounts { get; init; }
        public string SendingSpeedForPrebanAccounts { get; init; }
        public string ExcelDatabasesFolderPath { get; init; }
        public string MinBankGuaranteeFilter { get; init; }
        public string MaxBankGuaranteeFilter { get; init; }
        public string Password { get; init; }
        public string SortingBGType { get; init; }
        public string SortingWinsCountType { get; init; }
        public string PrebanAccountsList { get; init; }
        public string ExceptionAccountsList { get; init; }
        public string BasicAccountsList { get; init; }
    }
}
