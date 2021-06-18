using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.SendingOptions
{
    public class SendingOptionsService : ISendingOptionsService
    {
        public OptionsSaveChangesResponse HandleSaveChangesRequest(SendingOptionsDataString fieldsInputData) => new()
        {
            HasErrors = TryCreateSendingOptionsData(fieldsInputData, out List<string> invalidFields, out bool hasWarning),
            HasWarning = hasWarning,
            InvalidFields = invalidFields
        };

        private static bool TryCreateSendingOptionsData(SendingOptionsDataString fieldsInputData, out List<string> invalidFields, out bool hasWarning)
        {
            hasWarning = false;
            invalidFields = new();

            var optionsData = new SendingOptionsData()
            {
                MailingMode = GetMailingMode(invalidFields),
                SelectedDate = GetSelectedDate(invalidFields),
                RecipientsCount = GetRecipientsCount(invalidFields),
                InterestRate = GetInterestRate(invalidFields),
                SendingSpeedForBasicAccounts = GetSendingSpeedForBasicAccounts(invalidFields),
                SendingSpeedForPrebanAccounts = GetSendingSpeedForPrebanAccounts(invalidFields),
                ExcelDatabasePath = GetExcelDatabasePath(invalidFields),
                MinBankGuaranteeFilter = GetMinBankGuaranteeFilter(invalidFields),
                MaxBankGuaranteeFilter = GetMaxBankGuaranteeFilter(invalidFields),
                Password = GetPassword(invalidFields),
                SortingBGType = GetSortingBGType(invalidFields),
                SortingWinsCountType = GetSortingWinsCountType(invalidFields),
                PrebanAccountsList = GetPrebanAccountsList(),
                ExceptionAccountsList = GetExceptionAccountsList(),
                BasicAccountsList = GetBasicAccountsList()
            };

            DoSpecialOnErrorAfterChecks(invalidFields);
            SendingSpeedWarningCheck(invalidFields, out hasWarning);

            if (hasWarning)
                return false;

            SaveChanges(optionsData);
            UpdateSavepoint();

            invalidFields = invalidFields.Distinct().ToList();

            // true -- has errors
            return invalidFields.Count != 0;


            #region Local Functions
            void SendingSpeedWarningCheck(List<string> invalidFields, out bool hasWarning)
            {
                hasWarning = false;

                const string defaultWarning = "(!) ПРЕДУПРЕЖДЕНИЕ (!)\n";
                string warning = defaultWarning;

                int basicspeed = GetSendingSpeedForBasicAccounts(invalidFields);
                int prebanspeed = GetSendingSpeedForPrebanAccounts(invalidFields);

                if (basicspeed > 9)
                    warning += "\nВысокая скорость рассылки для Основного списка! (рекомендуется до 9)";

                if (prebanspeed > 6)
                    warning += "\nВысокая скорость рассылки для Уязвимого списка! (рекомендуется до 6)";

                if (warning != defaultWarning)
                {
                    warning += "\n\nВы подвергаете свои почтовые ящики неоправданному риску быть забаненными! Тише едим, дальше будем. " +
                        "\nВы уверены в том, что не хотите снизить скорость рассылки?";

                    DialogResult result = MessageBox.Show(warning, "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (result == DialogResult.No)
                        hasWarning = true;
                }
            }

            void DoSpecialOnErrorAfterChecks(List<string> invalidFields)
            {
                int min = GetMinBankGuaranteeFilter(invalidFields);
                int max = GetMaxBankGuaranteeFilter(invalidFields);

                if (max <= min || max < 0 || min < 0)
                {
                    invalidFields.Add("MinBankGuaranteeFilter");
                    invalidFields.Add("MaxBankGuaranteeFilter");
                }

                if ((GetBasicAccountsList().Count + GetPrebanAccountsList().Count) == 0)
                {
                    invalidFields.Add("BasicAccountsList");
                    invalidFields.Add("PrebanAccountsList");
                }
            }

            MailingMode GetMailingMode(List<string> invalidFields)
            {
                if (uint.TryParse(fieldsInputData.MailingMode, out uint @out))
                    return (MailingMode)@out;
                else
                {
                    invalidFields.Add("MailingMode");
                    return new();
                }
            }

            DateTime GetSelectedDate(List<string> invalidFields)
            {
                if (int.Parse(fieldsInputData.MailingMode) == (int)MailingMode.Personal)
                {
                    if (DateTime.TryParse(fieldsInputData.SelectedDate.Replace(" ", string.Empty), out DateTime @out)
                        && (@out <= DateTime.Now))
                    {
                        return @out;
                    }
                    else
                    {
                        invalidFields.Add("SelectedDate");
                        return new();
                    }
                }
                else return new();
            }

            int GetRecipientsCount(List<string> invalidFields)
            {
                if (int.TryParse(fieldsInputData.RecipientsCount.Replace(" ", string.Empty), out int @out)
                    && (@out > 0))
                {
                    return @out;
                }
                else
                {
                    invalidFields.Add("RecipientsCount");
                    return new();
                }
            }

            double GetInterestRate(List<string> invalidFields)
            {
                if (double.TryParse(fieldsInputData.InterestRate.Replace(" ", string.Empty).Replace('.', ','), out double @out) && @out >= 0)
                    return @out;
                else
                {
                    invalidFields.Add("InterestRate");
                    return new();
                }
            }

            int GetSendingSpeedForBasicAccounts(List<string> invalidFields)
            {
                if (int.TryParse(fieldsInputData.SendingSpeedForBasicAccounts.Replace(" ", string.Empty), out int @out))
                    return @out;
                else
                {
                    invalidFields.Add("SendingSpeedForBasicAccounts");
                    return new();
                }
            }

            int GetSendingSpeedForPrebanAccounts(List<string> invalidFields)
            {
                if (int.TryParse(fieldsInputData.SendingSpeedForPrebanAccounts.Replace(" ", string.Empty), out int @out))
                    return @out;
                else
                {
                    invalidFields.Add("SendingSpeedForPrebanAccounts");
                    return new();
                }
            }

            string GetExcelDatabasePath(List<string> invalidFields)
            {
                if (!string.IsNullOrEmpty(fieldsInputData.ExcelDatabasePath))
                    return fieldsInputData.ExcelDatabasePath;
                else
                {
                    invalidFields.Add("ExcelDatabasePath");
                    return null;
                }
            }

            int GetMinBankGuaranteeFilter(List<string> invalidFields)
            {
                if (int.TryParse(fieldsInputData.MinBankGuaranteeFilter.Replace(" ", string.Empty), out int @out))
                    return @out;
                else
                {
                    invalidFields.Add("MinBankGuaranteeFilter");
                    return new();
                }
            }

            int GetMaxBankGuaranteeFilter(List<string> invalidFields)
            {
                if (int.TryParse(fieldsInputData.MaxBankGuaranteeFilter.Replace(" ", string.Empty), out int @out))
                    return @out;
                else
                {
                    invalidFields.Add("MaxBankGuaranteeFilter");
                    return new();
                }
            }

            string GetPassword(List<string> invalidFields)
            {
                if (!string.IsNullOrEmpty(fieldsInputData.Password))
                    return fieldsInputData.Password;
                else
                {
                    invalidFields.Add("Password");
                    return null;
                }
            }

            SortingBGType GetSortingBGType(List<string> invalidFields)
            {
                if (uint.TryParse(fieldsInputData.SortingBGType, out uint @out))
                    return (SortingBGType)@out;
                else
                {
                    invalidFields.Add("SortingBGType");
                    return new();
                }
            }

            SortingWinsCountType GetSortingWinsCountType(List<string> invalidFields)
            {
                if (uint.TryParse(fieldsInputData.SortingWinsCountType, out uint @out))
                    return (SortingWinsCountType)@out;
                else
                {
                    invalidFields.Add("SortingWinsCountType");
                    return new();
                }
            }

            List<string> GetPrebanAccountsList()
            {
                return new List<string>(fieldsInputData.PrebanAccountsList
                    .Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x.Contains('@')).Distinct());
            }

            List<string> GetExceptionAccountsList()
            {
                return new List<string>(fieldsInputData.ExceptionAccountsList
                    .Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x.Contains('@')).Distinct());
            }

            List<string> GetBasicAccountsList()
            {
                return new List<string>(fieldsInputData.BasicAccountsList
                    .Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x.Contains('@')).Distinct());
            }
            #endregion
        }

        private static void SaveChanges(SendingOptionsData optionsData)
        {
            if (!Directory.Exists(Program.OPTIONS_DIR))
                Directory.CreateDirectory(Program.OPTIONS_DIR);

            string json = JsonConvert.SerializeObject(optionsData, Formatting.Indented);
            File.WriteAllText(Program.SENDING_OPTIONS_FILE, json);

            Program.sendingOptions = optionsData;
        }

        private static void UpdateSavepoint()
        {
            if (Directory.Exists(Program.SAVEPOINT_DIR))
                Directory.Delete(Program.SAVEPOINT_DIR, recursive: true);

            Directory.CreateDirectory(Program.SAVEPOINT_DIR);

            File.WriteAllText(Program.NUM_SAVEPOINT_FILE, Program.numSavepoint.ToString());

            if (!Directory.Exists(Program.OPTIONS_DIR))
                throw new Exception("\'options\' directory were not found!");
            else
            {
                File.Copy(Program.SENDING_OPTIONS_FILE, Program.SAVEPOINT_SENDING_OPTIONS_FILE);
                File.Copy(Program.MAIL_OPTIONS_FILE, Program.SAVEPOINT_MAIL_OPTIONS_FILE);
            }
        }
    }
}
