using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.SendingOptions;
using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.View
{
    public partial class SendingOptionsForm : Form, ISendingOptionsView
    {
        public event EventHandler SaveOptionsChanges;

        private readonly List<TextBox> formFields = new();

        public SendingOptionsForm()
        {
            InitializeComponent();

            comboBoxMailingMode.SelectedIndexChanged += ComboBoxMailingMode_SelectedIndexChanged;
            comboBoxMailingMode.SelectedIndex = (int)MailingMode.Generic; // Обобщенная рассылка по умолчанию

            foreach (Control c in this.Controls)
                if (c is TextBox t) formFields.Add(t);
        }

        public void Open() => this.ShowDialog();

        public void ShowExistingSettings(SendingOptionsData settings)
        {
            if (settings == null)
                return;

            comboBoxOrderByBG.SelectedIndex = (int)settings.SortingBGType;
            comboBoxOrderByWinsCount.SelectedIndex = (int)settings.SortingWinsCountType;
            comboBoxMailingMode.SelectedIndex = (int)settings.MailingMode;
            textBoxSelectedDate.Text = settings.SelectedDate.ToString("dd.MM.yyyy");
            textBoxInterestRate.Text = $"{settings.InterestRate:.##}";
            textBoxRecipientsCount.Text = settings.RecipientsCount.ToString();
            textBoxSpeedForBasicAccounts.Text = settings.SendingSpeedForBasicAccounts.ToString();
            textBoxSpeedForPrebanAccounts.Text = settings.SendingSpeedForPrebanAccounts.ToString();
            textBoxExcelDatabasePath.Text = settings.ExcelDatabasePath;
            textBoxBankGuaranteeFilter_Min.Text = settings.MinBankGuaranteeFilter.ToString();
            textBoxBankGuaranteeFilter_Max.Text = settings.MaxBankGuaranteeFilter.ToString();
            textBoxPassword.Text = settings.Password;
            textBoxBasicAccountsList.Text = string.Join("\r\n", settings.BasicAccountsList);
            textBoxPrebanAccountsList.Text = string.Join("\r\n", settings.PrebanAccountsList);
            textBoxExceptionAccountsList.Text = string.Join("\r\n", settings.ExceptionAccountsList);
        }

        public SendingOptionsDataString GetRequiredFieldsInputData() => new()
        {
            MailingMode = comboBoxMailingMode.SelectedIndex.ToString(),
            SelectedDate = textBoxSelectedDate.Text,
            RecipientsCount = textBoxRecipientsCount.Text,
            InterestRate = textBoxInterestRate.Text,
            SendingSpeedForBasicAccounts = textBoxSpeedForBasicAccounts.Text,
            SendingSpeedForPrebanAccounts = textBoxSpeedForPrebanAccounts.Text,
            ExcelDatabasePath = textBoxExcelDatabasePath.Text,
            MinBankGuaranteeFilter = textBoxBankGuaranteeFilter_Min.Text,
            MaxBankGuaranteeFilter = textBoxBankGuaranteeFilter_Max.Text,
            Password = textBoxPassword.Text,
            SortingBGType = comboBoxOrderByBG.SelectedIndex.ToString(),
            SortingWinsCountType = comboBoxOrderByWinsCount.SelectedIndex.ToString(),
            PrebanAccountsList = textBoxPrebanAccountsList.Text,
            ExceptionAccountsList = textBoxExceptionAccountsList.Text,
            BasicAccountsList = textBoxBasicAccountsList.Text
        };

        public void HandleSaveChangesResponse(OptionsSaveChangesResponse response)
        {
            // Ошибок нет и предупреждение проигнорировано
            if (response.HasErrors == false && response.HasWarning == false)
                this.Close();
            // Есть ошибки, предупреждение не грает роли
            else if (response.HasErrors == true)
                OnFieldsValidationError(response.InvalidFields);

            // В случае, если предпреждение принято к сведению и ошибок нет, то окно просто не закрывается
        }

        private void OnFieldsValidationError(List<string> invalidFields)
        {
            const string messageText = "Проверьте выделенные желтым поля на корректность введённых данных и их наличие";
            
            HighlightInvalidFields(invalidFields);
            MessageBox.Show(messageText, "(!) ОШИБКА (!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HighlightInvalidFields(List<string> invalidFields)
        {
            foreach (string field in invalidFields)
            {
                Control control = field switch
                {
                    "MailingMode" => comboBoxMailingMode,
                    "SelectedDate" => textBoxSelectedDate,
                    "RecipientsCount" => textBoxRecipientsCount,
                    "InterestRate" => textBoxInterestRate,
                    "SendingSpeedForBasicAccounts" => textBoxSpeedForBasicAccounts,
                    "SendingSpeedForPrebanAccounts" => textBoxSpeedForPrebanAccounts,
                    "ExcelDatabasePath" => textBoxExcelDatabasePath,
                    "MinBankGuaranteeFilter" => textBoxBankGuaranteeFilter_Min,
                    "MaxBankGuaranteeFilter" => textBoxBankGuaranteeFilter_Max,
                    "Password" => textBoxPassword,
                    "SortingBGType" => comboBoxOrderByBG,
                    "SortingWinsCountType" => comboBoxOrderByWinsCount,
                    "PrebanAccountsList" => textBoxPrebanAccountsList,
                    "ExceptionAccountsList" => textBoxExceptionAccountsList,
                    "BasicAccountsList" => textBoxBasicAccountsList,
                    _ => throw new Exception($"Such field was not found: {field}")
                };

                Invoke(new Action(() => control.BackColor = Color.LightGoldenrodYellow));
            }
        }

        private void ButtonChooseExcelDatabase_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK & openFileDialog.FileName.Contains(".xlsx"))
                this.textBoxExcelDatabasePath.Text = openFileDialog.FileName;
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            CancelTextBoxesErrorHighlighting();
            SaveOptionsChanges.Invoke(sender, e);
        }

        private void CancelTextBoxesErrorHighlighting()
        {
            foreach (TextBox tb in formFields)
                if (tb.BackColor == Color.LightGoldenrodYellow)
                    tb.BackColor = Color.White;
        }

        private void ButtonCancelForm_Click(object sender, EventArgs e) => this.Close();

        private void ComboBoxMailingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // поставить Персональную рассылку
            if (comboBoxMailingMode.SelectedIndex == (int)MailingMode.Personal)
            {
                textBoxSelectedDate.Enabled = true;
                labelSelectedDate.Enabled = true;
            }
            // поставить Обобщеную рассылку
            else
            {
                textBoxSelectedDate.Enabled = false;
                labelSelectedDate.Enabled = false;
            }
        }
    }
}
