using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.MailOptions;

namespace PipiPonaPoster.Source.View
{
    public partial class MailOptionsForm : Form, IMailOptionsView
    {
        public event EventHandler SaveOptionsChanges;

        private readonly List<TextBox> formFields = new();

        public MailOptionsForm()
        {
            InitializeComponent();

            foreach (Control c in this.Controls)
                if (c is TextBox t) formFields.Add(t);
        }

        public void Open() => this.ShowDialog();

        public void ShowExistingSettings(MailOptionsData settings)
        {
            if (settings == null)
                return;

            textBoxFontSize.Text = settings.FontSize.ToString();
            textBoxFontStyle.Text = settings.FontStyle;
            textBoxMailTopic.Text = settings.MailTopic;
            textBoxFirstImage.Text = settings.FirstImagePath;
            textBoxSecondImage.Text = settings.SecondImagePath;
            textBoxFirstMailText.Text = settings.FirstMailText;
            textBoxSecondMailText.Text = settings.SecondMailText;
        }

        public MailOptionsDataString GetRequiredFieldsInputData() => new()
        {
            FontSize = textBoxFontSize.Text,
            FontStyle = textBoxFontStyle.Text,
            MailTopic = textBoxMailTopic.Text,
            FirstImagePath = textBoxFirstImage.Text,
            SecondImagePath = textBoxSecondImage.Text,
            FirstMailText = textBoxFirstMailText.Text,
            SecondMailText = textBoxSecondMailText.Text
        };

        public void HandleSaveChangesResponse(OptionsSaveChangesResponse response)
        {
            // Ошибок нет и предупреждение проигнорировано
            if (response.HasErrors == false && response.HasWarning == false)
                this.Close();
            // Есть ошибки, предупреждение не грает роли
            else if (response.HasErrors == true)
                OnFieldsValidationError(response.InvalidFields);

            // В случае, если предпреждение принято к сведению и ошибок нет, то окно просто НЕ закрывается
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
                    "FontSize" => textBoxFontSize,
                    "FontStyle" => textBoxFontStyle,
                    "MailTopic" => textBoxMailTopic,
                    "FirstImagePath" => textBoxFirstImage,
                    "SecondImagePath" => textBoxSecondImage,
                    _ => throw new Exception($"Such field was not found: {field}")
                };

                Invoke(new Action(() => control.BackColor = Color.LightGoldenrodYellow));
            }
        }

        private void ButtonChooseFirstImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.textBoxFirstImage.Text = openFileDialog.FileName;
        }

        private void ButtonChooseSecondImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.textBoxSecondImage.Text = openFileDialog.FileName;
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
    }
}
