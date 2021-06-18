using System.Net.Mail;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class ImagesPackGeneric : ImagesPack
    {
        public LinkedResource First { get; set; }
        public LinkedResource Logo { get; set; }

        public ImagesPackGeneric(LinkedResource first, LinkedResource logo)
        {
            First = first;
            Logo = logo;
        }
    }
}
