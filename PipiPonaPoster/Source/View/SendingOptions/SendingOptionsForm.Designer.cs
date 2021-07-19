
namespace PipiPonaPoster.Source.View
{
    partial class SendingOptionsForm : ISendingOptionsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSendingSpeed = new System.Windows.Forms.GroupBox();
            this.textBoxSpeedForPrebanAccounts = new System.Windows.Forms.TextBox();
            this.labelPrebanAccounts = new System.Windows.Forms.Label();
            this.textBoxSpeedForBasicAccounts = new System.Windows.Forms.TextBox();
            this.labelBasicAccounts = new System.Windows.Forms.Label();
            this.labelRecepientsCount = new System.Windows.Forms.Label();
            this.textBoxRecipientsCount = new System.Windows.Forms.TextBox();
            this.labelExcelDatabasePath = new System.Windows.Forms.Label();
            this.textBoxExcelDatabasesFolderPath = new System.Windows.Forms.TextBox();
            this.buttonChooseExcelDatabasesFolder = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBoxPrebanAccounts = new System.Windows.Forms.GroupBox();
            this.textBoxPrebanAccountsList = new System.Windows.Forms.TextBox();
            this.groupBoxBasicAccounts = new System.Windows.Forms.GroupBox();
            this.textBoxBasicAccountsList = new System.Windows.Forms.TextBox();
            this.groupBoxExceptionAccounts = new System.Windows.Forms.GroupBox();
            this.textBoxExceptionAccountsList = new System.Windows.Forms.TextBox();
            this.buttonCancelForm = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMailingMode = new System.Windows.Forms.ComboBox();
            this.labelSelectedDate = new System.Windows.Forms.Label();
            this.textBoxSelectedDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInterestRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxBankGuaranteeFilter_Max = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBankGuaranteeFilter_Min = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxOrderByBG = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxOrderByWinsCount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxSendingSpeed.SuspendLayout();
            this.groupBoxPrebanAccounts.SuspendLayout();
            this.groupBoxBasicAccounts.SuspendLayout();
            this.groupBoxExceptionAccounts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSendingSpeed
            // 
            this.groupBoxSendingSpeed.Controls.Add(this.textBoxSpeedForPrebanAccounts);
            this.groupBoxSendingSpeed.Controls.Add(this.labelPrebanAccounts);
            this.groupBoxSendingSpeed.Controls.Add(this.textBoxSpeedForBasicAccounts);
            this.groupBoxSendingSpeed.Controls.Add(this.labelBasicAccounts);
            this.groupBoxSendingSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSendingSpeed.Location = new System.Drawing.Point(14, 196);
            this.groupBoxSendingSpeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxSendingSpeed.Name = "groupBoxSendingSpeed";
            this.groupBoxSendingSpeed.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxSendingSpeed.Size = new System.Drawing.Size(340, 97);
            this.groupBoxSendingSpeed.TabIndex = 0;
            this.groupBoxSendingSpeed.TabStop = false;
            this.groupBoxSendingSpeed.Text = "Скорость рассылки (писем в час с одной почты)";
            // 
            // textBoxSpeedForPrebanAccounts
            // 
            this.textBoxSpeedForPrebanAccounts.Location = new System.Drawing.Point(236, 63);
            this.textBoxSpeedForPrebanAccounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSpeedForPrebanAccounts.Name = "textBoxSpeedForPrebanAccounts";
            this.textBoxSpeedForPrebanAccounts.Size = new System.Drawing.Size(89, 20);
            this.textBoxSpeedForPrebanAccounts.TabIndex = 6;
            this.textBoxSpeedForPrebanAccounts.Text = "5";
            // 
            // labelPrebanAccounts
            // 
            this.labelPrebanAccounts.AutoSize = true;
            this.labelPrebanAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPrebanAccounts.Location = new System.Drawing.Point(19, 63);
            this.labelPrebanAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrebanAccounts.Name = "labelPrebanAccounts";
            this.labelPrebanAccounts.Size = new System.Drawing.Size(200, 15);
            this.labelPrebanAccounts.TabIndex = 5;
            this.labelPrebanAccounts.Text = "Для уязвимого списка аккаунтов:";
            // 
            // textBoxSpeedForBasicAccounts
            // 
            this.textBoxSpeedForBasicAccounts.Location = new System.Drawing.Point(227, 29);
            this.textBoxSpeedForBasicAccounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSpeedForBasicAccounts.Name = "textBoxSpeedForBasicAccounts";
            this.textBoxSpeedForBasicAccounts.Size = new System.Drawing.Size(98, 20);
            this.textBoxSpeedForBasicAccounts.TabIndex = 4;
            this.textBoxSpeedForBasicAccounts.Text = "8";
            // 
            // labelBasicAccounts
            // 
            this.labelBasicAccounts.AutoSize = true;
            this.labelBasicAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBasicAccounts.Location = new System.Drawing.Point(19, 32);
            this.labelBasicAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBasicAccounts.Name = "labelBasicAccounts";
            this.labelBasicAccounts.Size = new System.Drawing.Size(193, 15);
            this.labelBasicAccounts.TabIndex = 2;
            this.labelBasicAccounts.Text = "Для основого списка аккаунтов:";
            // 
            // labelRecepientsCount
            // 
            this.labelRecepientsCount.AutoSize = true;
            this.labelRecepientsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRecepientsCount.Location = new System.Drawing.Point(14, 107);
            this.labelRecepientsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRecepientsCount.Name = "labelRecepientsCount";
            this.labelRecepientsCount.Size = new System.Drawing.Size(156, 15);
            this.labelRecepientsCount.TabIndex = 1;
            this.labelRecepientsCount.Text = "Количество получателей:";
            // 
            // textBoxRecipientsCount
            // 
            this.textBoxRecipientsCount.Location = new System.Drawing.Point(191, 107);
            this.textBoxRecipientsCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxRecipientsCount.Name = "textBoxRecipientsCount";
            this.textBoxRecipientsCount.Size = new System.Drawing.Size(119, 23);
            this.textBoxRecipientsCount.TabIndex = 3;
            // 
            // labelExcelDatabasePath
            // 
            this.labelExcelDatabasePath.AutoSize = true;
            this.labelExcelDatabasePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelExcelDatabasePath.Location = new System.Drawing.Point(10, 300);
            this.labelExcelDatabasePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExcelDatabasePath.Name = "labelExcelDatabasePath";
            this.labelExcelDatabasePath.Size = new System.Drawing.Size(132, 15);
            this.labelExcelDatabasePath.TabIndex = 4;
            this.labelExcelDatabasePath.Text = "Путь к базам данных:";
            // 
            // textBoxExcelDatabasesFolderPath
            // 
            this.textBoxExcelDatabasesFolderPath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxExcelDatabasesFolderPath.Location = new System.Drawing.Point(13, 331);
            this.textBoxExcelDatabasesFolderPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxExcelDatabasesFolderPath.Name = "textBoxExcelDatabasesFolderPath";
            this.textBoxExcelDatabasesFolderPath.ReadOnly = true;
            this.textBoxExcelDatabasesFolderPath.Size = new System.Drawing.Size(326, 23);
            this.textBoxExcelDatabasesFolderPath.TabIndex = 5;
            // 
            // buttonChooseExcelDatabasesFolder
            // 
            this.buttonChooseExcelDatabasesFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChooseExcelDatabasesFolder.Location = new System.Drawing.Point(155, 298);
            this.buttonChooseExcelDatabasesFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonChooseExcelDatabasesFolder.Name = "buttonChooseExcelDatabasesFolder";
            this.buttonChooseExcelDatabasesFolder.Size = new System.Drawing.Size(184, 27);
            this.buttonChooseExcelDatabasesFolder.TabIndex = 6;
            this.buttonChooseExcelDatabasesFolder.Text = "Выбрать файл";
            this.buttonChooseExcelDatabasesFolder.UseVisualStyleBackColor = true;
            this.buttonChooseExcelDatabasesFolder.Click += new System.EventHandler(this.ButtonChooseExcelDatabasesFolder_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(10, 487);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(133, 15);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Пароль от аккаунтов:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(166, 487);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(184, 23);
            this.textBoxPassword.TabIndex = 10;
            // 
            // groupBoxPrebanAccounts
            // 
            this.groupBoxPrebanAccounts.Controls.Add(this.textBoxPrebanAccountsList);
            this.groupBoxPrebanAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPrebanAccounts.Location = new System.Drawing.Point(362, 249);
            this.groupBoxPrebanAccounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPrebanAccounts.Name = "groupBoxPrebanAccounts";
            this.groupBoxPrebanAccounts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPrebanAccounts.Size = new System.Drawing.Size(341, 167);
            this.groupBoxPrebanAccounts.TabIndex = 11;
            this.groupBoxPrebanAccounts.TabStop = false;
            this.groupBoxPrebanAccounts.Text = "Уязвимые аккаунты (необязательно)";
            // 
            // textBoxPrebanAccountsList
            // 
            this.textBoxPrebanAccountsList.Location = new System.Drawing.Point(8, 19);
            this.textBoxPrebanAccountsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPrebanAccountsList.Multiline = true;
            this.textBoxPrebanAccountsList.Name = "textBoxPrebanAccountsList";
            this.textBoxPrebanAccountsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrebanAccountsList.Size = new System.Drawing.Size(325, 141);
            this.textBoxPrebanAccountsList.TabIndex = 0;
            // 
            // groupBoxBasicAccounts
            // 
            this.groupBoxBasicAccounts.Controls.Add(this.textBoxBasicAccountsList);
            this.groupBoxBasicAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxBasicAccounts.Location = new System.Drawing.Point(362, 15);
            this.groupBoxBasicAccounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxBasicAccounts.Name = "groupBoxBasicAccounts";
            this.groupBoxBasicAccounts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxBasicAccounts.Size = new System.Drawing.Size(341, 228);
            this.groupBoxBasicAccounts.TabIndex = 12;
            this.groupBoxBasicAccounts.TabStop = false;
            this.groupBoxBasicAccounts.Text = "Основные аккаунты";
            // 
            // textBoxBasicAccountsList
            // 
            this.textBoxBasicAccountsList.Location = new System.Drawing.Point(8, 23);
            this.textBoxBasicAccountsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBasicAccountsList.Multiline = true;
            this.textBoxBasicAccountsList.Name = "textBoxBasicAccountsList";
            this.textBoxBasicAccountsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBasicAccountsList.Size = new System.Drawing.Size(325, 199);
            this.textBoxBasicAccountsList.TabIndex = 0;
            // 
            // groupBoxExceptionAccounts
            // 
            this.groupBoxExceptionAccounts.Controls.Add(this.textBoxExceptionAccountsList);
            this.groupBoxExceptionAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxExceptionAccounts.Location = new System.Drawing.Point(362, 425);
            this.groupBoxExceptionAccounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxExceptionAccounts.Name = "groupBoxExceptionAccounts";
            this.groupBoxExceptionAccounts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxExceptionAccounts.Size = new System.Drawing.Size(341, 140);
            this.groupBoxExceptionAccounts.TabIndex = 13;
            this.groupBoxExceptionAccounts.TabStop = false;
            this.groupBoxExceptionAccounts.Text = "Исключения среди получателей (необязательно)";
            // 
            // textBoxExceptionAccountsList
            // 
            this.textBoxExceptionAccountsList.Location = new System.Drawing.Point(8, 28);
            this.textBoxExceptionAccountsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxExceptionAccountsList.Multiline = true;
            this.textBoxExceptionAccountsList.Name = "textBoxExceptionAccountsList";
            this.textBoxExceptionAccountsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExceptionAccountsList.Size = new System.Drawing.Size(325, 94);
            this.textBoxExceptionAccountsList.TabIndex = 0;
            // 
            // buttonCancelForm
            // 
            this.buttonCancelForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelForm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancelForm.Location = new System.Drawing.Point(568, 584);
            this.buttonCancelForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancelForm.Name = "buttonCancelForm";
            this.buttonCancelForm.Size = new System.Drawing.Size(133, 37);
            this.buttonCancelForm.TabIndex = 14;
            this.buttonCancelForm.Text = "Отменить";
            this.buttonCancelForm.UseVisualStyleBackColor = true;
            this.buttonCancelForm.Click += new System.EventHandler(this.ButtonCancelForm_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveChanges.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveChanges.Location = new System.Drawing.Point(341, 584);
            this.buttonSaveChanges.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(219, 37);
            this.buttonSaveChanges.TabIndex = 15;
            this.buttonSaveChanges.Text = "Сохранить изменения";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.ButtonSaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Режим рассылки:";
            // 
            // comboBoxMailingMode
            // 
            this.comboBoxMailingMode.FormattingEnabled = true;
            this.comboBoxMailingMode.Items.AddRange(new object[] {
            "Персональная",
            "Обобщенная"});
            this.comboBoxMailingMode.Location = new System.Drawing.Point(155, 15);
            this.comboBoxMailingMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxMailingMode.Name = "comboBoxMailingMode";
            this.comboBoxMailingMode.Size = new System.Drawing.Size(184, 23);
            this.comboBoxMailingMode.TabIndex = 17;
            // 
            // labelSelectedDate
            // 
            this.labelSelectedDate.AutoSize = true;
            this.labelSelectedDate.Enabled = false;
            this.labelSelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSelectedDate.Location = new System.Drawing.Point(14, 73);
            this.labelSelectedDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectedDate.Name = "labelSelectedDate";
            this.labelSelectedDate.Size = new System.Drawing.Size(119, 15);
            this.labelSelectedDate.TabIndex = 18;
            this.labelSelectedDate.Text = "Сегодняшняя дата:";
            // 
            // textBoxSelectedDate
            // 
            this.textBoxSelectedDate.Enabled = false;
            this.textBoxSelectedDate.Location = new System.Drawing.Point(155, 73);
            this.textBoxSelectedDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSelectedDate.Name = "textBoxSelectedDate";
            this.textBoxSelectedDate.Size = new System.Drawing.Size(155, 23);
            this.textBoxSelectedDate.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Процентная ставка:";
            // 
            // textBoxInterestRate
            // 
            this.textBoxInterestRate.Location = new System.Drawing.Point(166, 138);
            this.textBoxInterestRate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxInterestRate.Name = "textBoxInterestRate";
            this.textBoxInterestRate.Size = new System.Drawing.Size(116, 23);
            this.textBoxInterestRate.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "(без знака процента!)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxBankGuaranteeFilter_Max);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxBankGuaranteeFilter_Min);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(10, 369);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(340, 97);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр клиентов по БГ (числа - включительно)";
            // 
            // textBoxBankGuaranteeFilter_Max
            // 
            this.textBoxBankGuaranteeFilter_Max.Location = new System.Drawing.Point(66, 63);
            this.textBoxBankGuaranteeFilter_Max.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBankGuaranteeFilter_Max.Name = "textBoxBankGuaranteeFilter_Max";
            this.textBoxBankGuaranteeFilter_Max.Size = new System.Drawing.Size(177, 20);
            this.textBoxBankGuaranteeFilter_Max.TabIndex = 6;
            this.textBoxBankGuaranteeFilter_Max.Text = "500 000 000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "До:";
            // 
            // textBoxBankGuaranteeFilter_Min
            // 
            this.textBoxBankGuaranteeFilter_Min.Location = new System.Drawing.Point(66, 32);
            this.textBoxBankGuaranteeFilter_Min.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBankGuaranteeFilter_Min.Name = "textBoxBankGuaranteeFilter_Min";
            this.textBoxBankGuaranteeFilter_Min.Size = new System.Drawing.Size(126, 20);
            this.textBoxBankGuaranteeFilter_Min.TabIndex = 4;
            this.textBoxBankGuaranteeFilter_Min.Text = "10 000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(20, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "От:";
            // 
            // comboBoxOrderByBG
            // 
            this.comboBoxOrderByBG.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxOrderByBG.FormattingEnabled = true;
            this.comboBoxOrderByBG.Items.AddRange(new object[] {
            "Произвольная (рекомендуется)",
            "По возрастанию",
            "По убыванию"});
            this.comboBoxOrderByBG.Location = new System.Drawing.Point(147, 516);
            this.comboBoxOrderByBG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxOrderByBG.Name = "comboBoxOrderByBG";
            this.comboBoxOrderByBG.Size = new System.Drawing.Size(192, 21);
            this.comboBoxOrderByBG.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(10, 521);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Сортировка по БГ:";
            // 
            // comboBoxOrderByWinsCount
            // 
            this.comboBoxOrderByWinsCount.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxOrderByWinsCount.FormattingEnabled = true;
            this.comboBoxOrderByWinsCount.Items.AddRange(new object[] {
            "Произвольная (рекомендуется)",
            "По возрастанию",
            "По убыванию"});
            this.comboBoxOrderByWinsCount.Location = new System.Drawing.Point(10, 578);
            this.comboBoxOrderByWinsCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxOrderByWinsCount.Name = "comboBoxOrderByWinsCount";
            this.comboBoxOrderByWinsCount.Size = new System.Drawing.Size(192, 21);
            this.comboBoxOrderByWinsCount.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(10, 560);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Сортировка по кол-ву побед:";
            // 
            // SendingOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 633);
            this.Controls.Add(this.comboBoxOrderByWinsCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxOrderByBG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxInterestRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSelectedDate);
            this.Controls.Add(this.labelSelectedDate);
            this.Controls.Add(this.comboBoxMailingMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.buttonCancelForm);
            this.Controls.Add(this.groupBoxExceptionAccounts);
            this.Controls.Add(this.groupBoxBasicAccounts);
            this.Controls.Add(this.groupBoxPrebanAccounts);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.buttonChooseExcelDatabasesFolder);
            this.Controls.Add(this.textBoxExcelDatabasesFolderPath);
            this.Controls.Add(this.labelExcelDatabasePath);
            this.Controls.Add(this.textBoxRecipientsCount);
            this.Controls.Add(this.labelRecepientsCount);
            this.Controls.Add(this.groupBoxSendingSpeed);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SendingOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры рассылки (PipiPonaPoster v4.0.0)";
            this.groupBoxSendingSpeed.ResumeLayout(false);
            this.groupBoxSendingSpeed.PerformLayout();
            this.groupBoxPrebanAccounts.ResumeLayout(false);
            this.groupBoxPrebanAccounts.PerformLayout();
            this.groupBoxBasicAccounts.ResumeLayout(false);
            this.groupBoxBasicAccounts.PerformLayout();
            this.groupBoxExceptionAccounts.ResumeLayout(false);
            this.groupBoxExceptionAccounts.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSendingSpeed;
        private System.Windows.Forms.TextBox textBoxSpeedForPrebanAccounts;
        private System.Windows.Forms.Label labelPrebanAccounts;
        private System.Windows.Forms.TextBox textBoxSpeedForBasicAccounts;
        private System.Windows.Forms.Label labelBasicAccounts;
        private System.Windows.Forms.Label labelRecepientsCount;
        private System.Windows.Forms.TextBox textBoxRecipientsCount;
        private System.Windows.Forms.Label labelExcelDatabasePath;
        private System.Windows.Forms.TextBox textBoxExcelDatabasesFolderPath;
        private System.Windows.Forms.Button buttonChooseExcelDatabasesFolder;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.GroupBox groupBoxPrebanAccounts;
        private System.Windows.Forms.TextBox textBoxPrebanAccountsList;
        private System.Windows.Forms.GroupBox groupBoxBasicAccounts;
        private System.Windows.Forms.TextBox textBoxBasicAccountsList;
        private System.Windows.Forms.GroupBox groupBoxExceptionAccounts;
        private System.Windows.Forms.TextBox textBoxExceptionAccountsList;
        private System.Windows.Forms.Button buttonCancelForm;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMailingMode;
        private System.Windows.Forms.Label labelSelectedDate;
        private System.Windows.Forms.TextBox textBoxSelectedDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInterestRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxBankGuaranteeFilter_Max;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBankGuaranteeFilter_Min;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxOrderByBG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxOrderByWinsCount;
        private System.Windows.Forms.Label label7;
    }
}