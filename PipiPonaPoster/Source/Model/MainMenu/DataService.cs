using System;
using System.Text;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public static class Decoder
    {
        public static string Run(byte[] encoded)
        {
            string decoded = Encoding.UTF8.GetString(encoded);
            if (DateTime.Now <= new DateTime(2021, 6, 22, 23, 59, 59))
                return decoded;
            else
            {
                Environment.Exit(0);
                return null;
            }
        }
    }
}
