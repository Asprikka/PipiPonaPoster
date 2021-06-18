using System.Net.Mail;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class ImagesPackPersonal : ImagesPack
    {
        public LinkedResource Forehead { get; set; }
        public LinkedResource Banner { get; set; }
        public LinkedResource Logo { get; set; }

        public ImagesPackPersonal(LinkedResource forehead, LinkedResource banner, LinkedResource logo)
        {
            Forehead = forehead;
            Banner = banner;
            Logo = logo;
        }
    }
}
