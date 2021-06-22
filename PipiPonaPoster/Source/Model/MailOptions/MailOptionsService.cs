using System.IO;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using System;

namespace PipiPonaPoster.Source.Model.MailOptions
{
    public class MailOptionsService : IMailOptionsService
    {
        public OptionsSaveChangesResponse HandleSaveChangesRequest(MailOptionsDataString fieldsInputData) => new()
        {
            HasErrors = TryCreateSendingOptionsData(fieldsInputData, out List<string> invalidFields, out bool hasWarning),
            HasWarning = hasWarning,
            InvalidFields = invalidFields
        };

        private static bool TryCreateSendingOptionsData(MailOptionsDataString fieldsInputData, out List<string> invalidFields, out bool hasWarning)
        {
            hasWarning = false;
            invalidFields = new();

            var optionsData = new MailOptionsData
            {
                FontSize = GetFontSize(invalidFields),
                FontStyle = GetFontStyle(invalidFields),
                MailTopic = GetMailTopic(invalidFields),
                FirstImagePath = GetFirstImagePath(invalidFields),
                SecondImagePath = GetSecondImagePath(invalidFields),
                FirstMailText = GetFirstMailText(),
                SecondMailText = GetSecondMailText()
            };

            SaveChanges(optionsData);
            UpdateSavepoint();

            invalidFields = invalidFields.Distinct().ToList();

            // true -- has errors
            return invalidFields.Count != 0;


            #region Local Functions
            int GetFontSize(List<string> invalidFields)
            {
                const int MIN_FONT_SIZE = 8;
                const int MAX_FONT_SIZE = 32;

                if (int.TryParse(fieldsInputData.FontSize, out int @out)
                    && @out >= MIN_FONT_SIZE && @out <= MAX_FONT_SIZE)
                    return @out;
                else
                {
                    invalidFields.Add("FontSize");
                    return new();
                }
            }

            string GetFontStyle(List<string> invalidFields)
            {
                if (string.IsNullOrEmpty(fieldsInputData.FontStyle)
                    || string.IsNullOrWhiteSpace(fieldsInputData.FontStyle))
                {
                    invalidFields.Add("FontStyle");
                    return null;
                }
                else return fieldsInputData.FontStyle;
            }

            string GetMailTopic(List<string> invalidFields)
            {
                if (string.IsNullOrEmpty(fieldsInputData.MailTopic)
                    || string.IsNullOrWhiteSpace(fieldsInputData.MailTopic))
                {
                    invalidFields.Add("MailTopic");
                    return null;
                }
                else return fieldsInputData.MailTopic;
            }

            string GetFirstImagePath(List<string> invalidFields)
            {
                if (string.IsNullOrEmpty(fieldsInputData.FirstImagePath) || !File.Exists(fieldsInputData.FirstImagePath))
                {
                    invalidFields.Add("FirstImagePath");
                    return null;
                }
                else return fieldsInputData.FirstImagePath;
            }

            string GetSecondImagePath(List<string> invalidFields)
            {
                if (string.IsNullOrEmpty(fieldsInputData.SecondImagePath) || !File.Exists(fieldsInputData.SecondImagePath))
                {
                    invalidFields.Add("SecondImagePath");
                    return null;
                }
                else return fieldsInputData.SecondImagePath;
            }

            string GetFirstMailText()
            {
                return fieldsInputData.FirstMailText;
            }

            string GetSecondMailText()
            {
                return fieldsInputData.SecondMailText;
            }
            #endregion
        }

        private static void SaveChanges(MailOptionsData optionsData)
        {
            if (!Directory.Exists(Program.OPTIONS_DIR))
                Directory.CreateDirectory(Program.OPTIONS_DIR);

            string json = JsonConvert.SerializeObject(optionsData, Formatting.Indented);
            File.WriteAllText(Program.MAIL_OPTIONS_FILE, json);

            Program.mailOptions = optionsData;
        }

        private static void UpdateSavepoint()
        {
            if (Directory.Exists(Program.SAVEPOINT_DIR))
                Directory.Delete(Program.SAVEPOINT_DIR, recursive: true);

            Directory.CreateDirectory(Program.SAVEPOINT_DIR);

            File.WriteAllText(Program.NUM_SAVEPOINT_FILE, Program.numSavepoint.ToString());

            if (!Directory.Exists(Program.OPTIONS_DIR))
                throw new Exception("\'options\' directory were not found!");

            File.Copy(Program.SENDING_OPTIONS_FILE, Program.SAVEPOINT_SENDING_OPTIONS_FILE);
            File.Copy(Program.MAIL_OPTIONS_FILE, Program.SAVEPOINT_MAIL_OPTIONS_FILE);

            if (!File.Exists(Program.TEMP_SAVEPOINT_SENDING_OPTIONS_FILE))
                File.Copy(Program.SENDING_OPTIONS_FILE, Program.TEMP_SAVEPOINT_SENDING_OPTIONS_FILE);

            if (!File.Exists(Program.TEMP_SAVEPOINT_MAIL_OPTIONS_FILE))
                File.Copy(Program.MAIL_OPTIONS_FILE, Program.TEMP_SAVEPOINT_MAIL_OPTIONS_FILE);
        }
    }
}
