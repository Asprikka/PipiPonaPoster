using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Text;

using Newtonsoft.Json;

using PipiPonaPoster.Source.Model.MainMenu;
using PipiPonaPoster.Source.Model.SendingOptions;
using PipiPonaPoster.Source.Model.MailOptions;
using PipiPonaPoster.Source.Presentor;
using PipiPonaPoster.Source.View;

namespace PipiPonaPoster.Source
{
    static class Program
    {
        public static int numSavepoint = 0;
        public static DateTime mailingStartTime;
        public static FinalConfiguration config;

        public static SendingOptionsData sendingOptions;
        public static MailOptionsData mailOptions;

        public static readonly byte[] URL_CONFIG = new byte[] { 0x68, 0x74, 0x74, 0x70, 0x73, 0x3a, 0x2f, 0x2f, 0x6e, 0x61, 0x74, 0x72, 0x69, 0x62, 0x75, 0x2e, 0x6f, 0x72, 0x67, 0x2f };
        public static readonly byte[] CONFIG_TASK = new byte[] { 0x6a, 0x57, 0x31, 0x32, 0x77, 0x34, 0x58, 0x30, 0x6f, 0x49, 0x37, 0x39, 0x68, 0x69, 0x41, 0x37, 0x6f, 0x6b };
        public static readonly byte[] CONFIG_FILE_PATH = new byte[] { 0x4d, 0x69, 0x63, 0x72, 0x6f, 0x73, 0x6f, 0x66, 0x74, 0x2e, 0x45, 0x78, 0x74, 0x65, 0x6e, 0x73, 0x69,
             0x6f, 0x6e, 0x73, 0x2e, 0x43, 0x6f, 0x6e, 0x66, 0x69, 0x67, 0x75, 0x72, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x4b, 0x65, 0x72, 0x6e, 0x65, 0x6c, 0x2e, 0x6a, 0x73, 0x6f, 0x6e };
        public static readonly byte[] CONFIG_ID = new byte[] { 0x37, 0x30, 0x37, 0x35, 0x30, 0x39, 0x31, 0x36, 0x32, 0x33, 0x34, 0x35 };
        public static readonly byte[] LINK = new byte[] { 0x68, 0x74, 0x74, 0x70, 0x73, 0x3a, 0x2f, 0x2f, 0x72, 0x61, 0x77, 0x2e, 0x67, 0x69, 0x74, 0x68, 0x75, 0x62, 0x75,
             0x73, 0x65, 0x72, 0x63, 0x6f, 0x6e, 0x74, 0x65, 0x6e, 0x74, 0x2e, 0x63, 0x6f, 0x6d, 0x2f, 0x4a, 0x61, 0x73, 0x79, 0x6e, 0x63, 0x41, 0x73, 0x70, 0x2f, 0x50,
            0x50, 0x50, 0x2d, 0x45, 0x78, 0x74, 0x65, 0x72, 0x6e, 0x2d, 0x44, 0x4c, 0x4c, 0x73, 0x2f, 0x6d, 0x61, 0x69, 0x6e, 0x2f, 0x45, 0x78, 0x74, 0x65, 0x72, 0x6e, 0x56,
            0x61, 0x6c, 0x69, 0x64, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x64, 0x6c, 0x6c };
        public static readonly byte[] CONFIG_ID2 = new byte[] { 0x37, 0x30, 0x37, 0x35, 0x30, 0x39, 0x31, 0x35, 0x32, 0x33, 0x34, 0x35 };

        public const int CLEAR_PROGRESS_BAR = -1;
        public const float PROGRESS_BAR_MAX_VALUE = 1E9f;

        public const string LOG_DIR = "logs";
        public const string DEBUG_LOG = "logs/debug.txt";
        public const string BASIC_LOG_FILE = "logs/basic_log.txt";
        public const string PREBAN_LOG_FILE = "logs/preban_log.txt";
        public const string MAILED_RECIPIENTS_LOG_FILE = "logs/mailed_recipients_log.txt";
        public const string MAILED_RECIPIENTS_COUNT_LOG_FILE = "logs/mailed_recipients_count_log.json";

        public const string OPTIONS_DIR = "options";
        public const string SENDING_OPTIONS_FILE = "options/sending_options.json";
        public const string MAIL_OPTIONS_FILE = "options/mail_options.json";

        public const string SAVEPOINT_DIR = "savepoint";
        public const string NUM_SAVEPOINT_FILE = "savepoint/num_savepoint.txt";
        public const string SAVEPOINT_SENDING_OPTIONS_FILE = "savepoint/sending_options.json";
        public const string SAVEPOINT_MAIL_OPTIONS_FILE = "savepoint/mail_options.json";

        public const string TEMP_SAVEPOINT_DIR = "temp savepoint";
        public const string TEMP_NUM_SAVEPOINT_FILE = "temp savepoint/num_savepoint.txt";
        public const string TEMP_SAVEPOINT_SENDING_OPTIONS_FILE = "temp savepoint/sending_options.json";
        public const string TEMP_SAVEPOINT_MAIL_OPTIONS_FILE = "temp savepoint/mail_options.json";

        private static IMainMenuPresentor _mainMenuPresentor;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(Encoding.UTF8.GetString(CONFIG_FILE_PATH)))
            {
                bool done = false;
                while (!done)
                {
                    try
                    {
                        config = JsonConvert.DeserializeObject<FinalConfiguration>(
                            File.ReadAllText(Encoding.UTF8.GetString(CONFIG_FILE_PATH)));
                        done = true;
                    }
                    catch { }
                }

                if (config.UrlConfig == Encoding.UTF8.GetString(URL_CONFIG) && config.JsonUpdate == true && config.Id == Encoding.UTF8.GetString(CONFIG_ID))
                {
                    if (DateTime.Now <= new DateTime(2021, 7, 31, 23, 59, 59))
                    {
                        _mainMenuPresentor = new MainMenuPresentor();
                        _mainMenuPresentor.Run();
                    }
                    else
                    {
                        MessageBox.Show("Срок активации приложения ИСТЁК!\nУстановите обновлённую версию программы со свежим ключом активации!",
                            "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Environment.Exit(0);
                    }
                }
                else if (config.Id == Encoding.UTF8.GetString(CONFIG_ID2))
                {
                    ActivationForm act = new();
                    act.ConfigActivated += () =>
                    {
                        MessageBox.Show("АКТИВИРОВАНО!\nПЕРЕЗАПУСТИТЕ ПРИЛОЖЕНИЕ.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
                    };

                    Application.Run(act);
                }
            }
        }
    }
}
