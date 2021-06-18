using System;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public struct RecipientData
    {
        public string LotNumber { get; set; }
        public long BankGuarantee { get; private set; }
        public string CompanyName { get; private set; }
        public string Email { get; private set; }
        public int WinsCount { get; private set; }
        public DateTime TermOfPerformance { get; set; }

        public RecipientData(
            string lotNumber, long bankGuarantee, string companyName, 
            string email, int winsCount, DateTime termOfPerformance)
        {
            LotNumber = lotNumber;
            BankGuarantee = bankGuarantee;
            CompanyName = companyName;
            Email = email;
            WinsCount = winsCount;
            TermOfPerformance = termOfPerformance;
        }
    }    
}
