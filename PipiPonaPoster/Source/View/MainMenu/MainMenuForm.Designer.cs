using System;

using Newtonsoft.Json;

namespace PipiPonaPoster.Source.View
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.buttonMailOptions = new System.Windows.Forms.Button();
            this.buttonSendingOptions = new System.Windows.Forms.Button();
            this.groupBoxMailingControlPanel = new System.Windows.Forms.GroupBox();
            this.buttonTerminateMailing = new System.Windows.Forms.Button();
            this.buttonPauseMailing = new System.Windows.Forms.Button();
            this.buttonContinueMailing = new System.Windows.Forms.Button();
            this.buttonStartNewMailing = new System.Windows.Forms.Button();
            this.groupBoxOtherFunctions = new System.Windows.Forms.GroupBox();
            this.buttonSaveMailedRecipients = new System.Windows.Forms.Button();
            this.buttonCalculators = new System.Windows.Forms.Button();
            this.buttonGetTodaySentMails = new System.Windows.Forms.Button();
            this.buttonOpenLogs = new System.Windows.Forms.Button();
            this.groupBoxOutputDataTerminal = new System.Windows.Forms.GroupBox();
            this.textBoxOutputDataTerminal = new System.Windows.Forms.TextBox();
            this.groupBoxMailingInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxMailingInfo3 = new System.Windows.Forms.GroupBox();
            this.labelFailuresCount = new System.Windows.Forms.Label();
            this.labelSuccessCount = new System.Windows.Forms.Label();
            this.labelFailureMailsCountInfo = new System.Windows.Forms.Label();
            this.labelSuccessMailsCountInfo = new System.Windows.Forms.Label();
            this.groupBoxMailingInfo2 = new System.Windows.Forms.GroupBox();
            this.labelTimeLeftUntilEnd = new System.Windows.Forms.Label();
            this.labelMailingStartTime = new System.Windows.Forms.Label();
            this.labelTimeToEndMailingInfo = new System.Windows.Forms.Label();
            this.labelMailingStartTimeInfo = new System.Windows.Forms.Label();
            this.groupBoxMailingInfo1 = new System.Windows.Forms.GroupBox();
            this.labelSendersCount = new System.Windows.Forms.Label();
            this.labelRecipientsCount = new System.Windows.Forms.Label();
            this.labelSendersCountInfo = new System.Windows.Forms.Label();
            this.labelRecipientsCountInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCurrentProcessState = new System.Windows.Forms.GroupBox();
            this.labelCurrentProcess = new System.Windows.Forms.Label();
            this.progressBarCurrentProcess = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelMe = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxMailingControlPanel.SuspendLayout();
            this.groupBoxOtherFunctions.SuspendLayout();
            this.groupBoxOutputDataTerminal.SuspendLayout();
            this.groupBoxMailingInfo.SuspendLayout();
            this.groupBoxMailingInfo3.SuspendLayout();
            this.groupBoxMailingInfo2.SuspendLayout();
            this.groupBoxMailingInfo1.SuspendLayout();
            this.groupBoxCurrentProcessState.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.buttonMailOptions);
            this.groupBoxOptions.Controls.Add(this.buttonSendingOptions);
            this.groupBoxOptions.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOptions.Location = new System.Drawing.Point(14, 14);
            this.groupBoxOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxOptions.Size = new System.Drawing.Size(270, 127);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Параметры";
            // 
            // buttonMailOptions
            // 
            this.buttonMailOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMailOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMailOptions.Location = new System.Drawing.Point(7, 77);
            this.buttonMailOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonMailOptions.Name = "buttonMailOptions";
            this.buttonMailOptions.Size = new System.Drawing.Size(233, 35);
            this.buttonMailOptions.TabIndex = 1;
            this.buttonMailOptions.Text = "Письмо";
            this.buttonMailOptions.UseVisualStyleBackColor = true;
            this.buttonMailOptions.Click += new System.EventHandler(this.ButtonMailOptions_Click);
            // 
            // buttonSendingOptions
            // 
            this.buttonSendingOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendingOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSendingOptions.Location = new System.Drawing.Point(8, 36);
            this.buttonSendingOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSendingOptions.Name = "buttonSendingOptions";
            this.buttonSendingOptions.Size = new System.Drawing.Size(233, 35);
            this.buttonSendingOptions.TabIndex = 0;
            this.buttonSendingOptions.Text = "Рассылка";
            this.buttonSendingOptions.UseVisualStyleBackColor = true;
            this.buttonSendingOptions.Click += new System.EventHandler(this.ButtonSendingOptions_Click);
            // 
            // groupBoxMailingControlPanel
            // 
            this.groupBoxMailingControlPanel.Controls.Add(this.buttonTerminateMailing);
            this.groupBoxMailingControlPanel.Controls.Add(this.buttonPauseMailing);
            this.groupBoxMailingControlPanel.Controls.Add(this.buttonContinueMailing);
            this.groupBoxMailingControlPanel.Controls.Add(this.buttonStartNewMailing);
            this.groupBoxMailingControlPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxMailingControlPanel.Location = new System.Drawing.Point(14, 159);
            this.groupBoxMailingControlPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingControlPanel.Name = "groupBoxMailingControlPanel";
            this.groupBoxMailingControlPanel.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingControlPanel.Size = new System.Drawing.Size(270, 259);
            this.groupBoxMailingControlPanel.TabIndex = 1;
            this.groupBoxMailingControlPanel.TabStop = false;
            this.groupBoxMailingControlPanel.Text = "Панель управления рассылкой";
            // 
            // buttonTerminateMailing
            // 
            this.buttonTerminateMailing.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonTerminateMailing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTerminateMailing.Enabled = false;
            this.buttonTerminateMailing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonTerminateMailing.Location = new System.Drawing.Point(8, 196);
            this.buttonTerminateMailing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonTerminateMailing.Name = "buttonTerminateMailing";
            this.buttonTerminateMailing.Size = new System.Drawing.Size(233, 57);
            this.buttonTerminateMailing.TabIndex = 4;
            this.buttonTerminateMailing.Text = "Полная остановка\r\n(нельзя продолжить позже)";
            this.buttonTerminateMailing.UseVisualStyleBackColor = false;
            this.buttonTerminateMailing.Click += new System.EventHandler(this.ButtonTerminateMailing_Click);
            // 
            // buttonPauseMailing
            // 
            this.buttonPauseMailing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPauseMailing.Enabled = false;
            this.buttonPauseMailing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPauseMailing.Location = new System.Drawing.Point(7, 146);
            this.buttonPauseMailing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPauseMailing.Name = "buttonPauseMailing";
            this.buttonPauseMailing.Size = new System.Drawing.Size(233, 35);
            this.buttonPauseMailing.TabIndex = 3;
            this.buttonPauseMailing.Text = "Пауза";
            this.buttonPauseMailing.UseVisualStyleBackColor = true;
            this.buttonPauseMailing.Click += new System.EventHandler(this.ButtonPauseMailing_Click);
            // 
            // buttonContinueMailing
            // 
            this.buttonContinueMailing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinueMailing.Enabled = false;
            this.buttonContinueMailing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonContinueMailing.Location = new System.Drawing.Point(8, 92);
            this.buttonContinueMailing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonContinueMailing.Name = "buttonContinueMailing";
            this.buttonContinueMailing.Size = new System.Drawing.Size(233, 35);
            this.buttonContinueMailing.TabIndex = 2;
            this.buttonContinueMailing.Text = "Продолжить";
            this.buttonContinueMailing.UseVisualStyleBackColor = true;
            this.buttonContinueMailing.Click += new System.EventHandler(this.ButtonContinueMailing_Click);
            // 
            // buttonStartNewMailing
            // 
            this.buttonStartNewMailing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartNewMailing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStartNewMailing.Location = new System.Drawing.Point(7, 35);
            this.buttonStartNewMailing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonStartNewMailing.Name = "buttonStartNewMailing";
            this.buttonStartNewMailing.Size = new System.Drawing.Size(233, 48);
            this.buttonStartNewMailing.TabIndex = 1;
            this.buttonStartNewMailing.Text = "Начать заново";
            this.buttonStartNewMailing.UseVisualStyleBackColor = true;
            this.buttonStartNewMailing.Click += new System.EventHandler(this.ButtonStartNewMailing_Click);
            // 
            // groupBoxOtherFunctions
            // 
            this.groupBoxOtherFunctions.Controls.Add(this.buttonSaveMailedRecipients);
            this.groupBoxOtherFunctions.Controls.Add(this.buttonCalculators);
            this.groupBoxOtherFunctions.Controls.Add(this.buttonGetTodaySentMails);
            this.groupBoxOtherFunctions.Controls.Add(this.buttonOpenLogs);
            this.groupBoxOtherFunctions.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOtherFunctions.Location = new System.Drawing.Point(14, 424);
            this.groupBoxOtherFunctions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxOtherFunctions.Name = "groupBoxOtherFunctions";
            this.groupBoxOtherFunctions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxOtherFunctions.Size = new System.Drawing.Size(270, 181);
            this.groupBoxOtherFunctions.TabIndex = 2;
            this.groupBoxOtherFunctions.TabStop = false;
            this.groupBoxOtherFunctions.Text = "Прочее";
            // 
            // buttonSaveMailedRecipients
            // 
            this.buttonSaveMailedRecipients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveMailedRecipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveMailedRecipients.Location = new System.Drawing.Point(7, 67);
            this.buttonSaveMailedRecipients.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSaveMailedRecipients.Name = "buttonSaveMailedRecipients";
            this.buttonSaveMailedRecipients.Size = new System.Drawing.Size(233, 29);
            this.buttonSaveMailedRecipients.TabIndex = 4;
            this.buttonSaveMailedRecipients.Text = "Сохранить историю текущей рассылки";
            this.buttonSaveMailedRecipients.UseVisualStyleBackColor = true;
            this.buttonSaveMailedRecipients.Click += new System.EventHandler(this.ButtonSaveMailedRecipients_Click);
            // 
            // buttonCalculators
            // 
            this.buttonCalculators.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCalculators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCalculators.Location = new System.Drawing.Point(8, 102);
            this.buttonCalculators.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCalculators.Name = "buttonCalculators";
            this.buttonCalculators.Size = new System.Drawing.Size(233, 29);
            this.buttonCalculators.TabIndex = 3;
            this.buttonCalculators.Text = "Открыть калькуляторы";
            this.buttonCalculators.UseVisualStyleBackColor = true;
            this.buttonCalculators.Click += new System.EventHandler(this.ButtonCalculators_Click);
            // 
            // buttonGetTodaySentMails
            // 
            this.buttonGetTodaySentMails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGetTodaySentMails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGetTodaySentMails.Location = new System.Drawing.Point(8, 32);
            this.buttonGetTodaySentMails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonGetTodaySentMails.Name = "buttonGetTodaySentMails";
            this.buttonGetTodaySentMails.Size = new System.Drawing.Size(233, 29);
            this.buttonGetTodaySentMails.TabIndex = 2;
            this.buttonGetTodaySentMails.Text = "Кол-во отправленных за сегодня писем";
            this.buttonGetTodaySentMails.UseVisualStyleBackColor = true;
            this.buttonGetTodaySentMails.Click += new System.EventHandler(this.ButtonGetTodaySentMails_Click);
            // 
            // buttonOpenLogs
            // 
            this.buttonOpenLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOpenLogs.Location = new System.Drawing.Point(8, 137);
            this.buttonOpenLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOpenLogs.Name = "buttonOpenLogs";
            this.buttonOpenLogs.Size = new System.Drawing.Size(233, 29);
            this.buttonOpenLogs.TabIndex = 1;
            this.buttonOpenLogs.Text = "Открыть логи";
            this.buttonOpenLogs.UseVisualStyleBackColor = true;
            this.buttonOpenLogs.Click += new System.EventHandler(this.ButtonOpenLogs_Click);
            // 
            // groupBoxOutputDataTerminal
            // 
            this.groupBoxOutputDataTerminal.Controls.Add(this.textBoxOutputDataTerminal);
            this.groupBoxOutputDataTerminal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOutputDataTerminal.Location = new System.Drawing.Point(302, 15);
            this.groupBoxOutputDataTerminal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxOutputDataTerminal.Name = "groupBoxOutputDataTerminal";
            this.groupBoxOutputDataTerminal.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxOutputDataTerminal.Size = new System.Drawing.Size(849, 470);
            this.groupBoxOutputDataTerminal.TabIndex = 3;
            this.groupBoxOutputDataTerminal.TabStop = false;
            this.groupBoxOutputDataTerminal.Text = "Терминал вывода данных";
            // 
            // textBoxOutputDataTerminal
            // 
            this.textBoxOutputDataTerminal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxOutputDataTerminal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxOutputDataTerminal.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxOutputDataTerminal.Location = new System.Drawing.Point(11, 23);
            this.textBoxOutputDataTerminal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxOutputDataTerminal.Multiline = true;
            this.textBoxOutputDataTerminal.Name = "textBoxOutputDataTerminal";
            this.textBoxOutputDataTerminal.ReadOnly = true;
            this.textBoxOutputDataTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutputDataTerminal.Size = new System.Drawing.Size(830, 429);
            this.textBoxOutputDataTerminal.TabIndex = 0;
            // 
            // groupBoxMailingInfo
            // 
            this.groupBoxMailingInfo.Controls.Add(this.groupBoxMailingInfo3);
            this.groupBoxMailingInfo.Controls.Add(this.groupBoxMailingInfo2);
            this.groupBoxMailingInfo.Controls.Add(this.groupBoxMailingInfo1);
            this.groupBoxMailingInfo.Enabled = false;
            this.groupBoxMailingInfo.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxMailingInfo.Location = new System.Drawing.Point(1159, 15);
            this.groupBoxMailingInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo.Name = "groupBoxMailingInfo";
            this.groupBoxMailingInfo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo.Size = new System.Drawing.Size(366, 452);
            this.groupBoxMailingInfo.TabIndex = 4;
            this.groupBoxMailingInfo.TabStop = false;
            this.groupBoxMailingInfo.Text = "Рассылочная статистика";
            // 
            // groupBoxMailingInfo3
            // 
            this.groupBoxMailingInfo3.Controls.Add(this.labelFailuresCount);
            this.groupBoxMailingInfo3.Controls.Add(this.labelSuccessCount);
            this.groupBoxMailingInfo3.Controls.Add(this.labelFailureMailsCountInfo);
            this.groupBoxMailingInfo3.Controls.Add(this.labelSuccessMailsCountInfo);
            this.groupBoxMailingInfo3.Location = new System.Drawing.Point(8, 164);
            this.groupBoxMailingInfo3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo3.Name = "groupBoxMailingInfo3";
            this.groupBoxMailingInfo3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo3.Size = new System.Drawing.Size(342, 63);
            this.groupBoxMailingInfo3.TabIndex = 2;
            this.groupBoxMailingInfo3.TabStop = false;
            // 
            // labelFailuresCount
            // 
            this.labelFailuresCount.AutoSize = true;
            this.labelFailuresCount.Location = new System.Drawing.Point(171, 37);
            this.labelFailuresCount.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelFailuresCount.Name = "labelFailuresCount";
            this.labelFailuresCount.Size = new System.Drawing.Size(15, 17);
            this.labelFailuresCount.TabIndex = 4;
            this.labelFailuresCount.Text = "0";
            // 
            // labelSuccessCount
            // 
            this.labelSuccessCount.AutoSize = true;
            this.labelSuccessCount.Location = new System.Drawing.Point(204, 14);
            this.labelSuccessCount.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelSuccessCount.Name = "labelSuccessCount";
            this.labelSuccessCount.Size = new System.Drawing.Size(15, 17);
            this.labelSuccessCount.TabIndex = 3;
            this.labelSuccessCount.Text = "0";
            // 
            // labelFailureMailsCountInfo
            // 
            this.labelFailureMailsCountInfo.AutoSize = true;
            this.labelFailureMailsCountInfo.Location = new System.Drawing.Point(7, 37);
            this.labelFailureMailsCountInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFailureMailsCountInfo.Name = "labelFailureMailsCountInfo";
            this.labelFailureMailsCountInfo.Size = new System.Drawing.Size(160, 17);
            this.labelFailureMailsCountInfo.TabIndex = 1;
            this.labelFailureMailsCountInfo.Text = "НЕ отправленных писем: ";
            // 
            // labelSuccessMailsCountInfo
            // 
            this.labelSuccessMailsCountInfo.AutoSize = true;
            this.labelSuccessMailsCountInfo.Location = new System.Drawing.Point(7, 14);
            this.labelSuccessMailsCountInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelSuccessMailsCountInfo.Name = "labelSuccessMailsCountInfo";
            this.labelSuccessMailsCountInfo.Size = new System.Drawing.Size(197, 17);
            this.labelSuccessMailsCountInfo.TabIndex = 0;
            this.labelSuccessMailsCountInfo.Text = "Успешно отправленных писем: ";
            // 
            // groupBoxMailingInfo2
            // 
            this.groupBoxMailingInfo2.Controls.Add(this.labelTimeLeftUntilEnd);
            this.groupBoxMailingInfo2.Controls.Add(this.labelMailingStartTime);
            this.groupBoxMailingInfo2.Controls.Add(this.labelTimeToEndMailingInfo);
            this.groupBoxMailingInfo2.Controls.Add(this.labelMailingStartTimeInfo);
            this.groupBoxMailingInfo2.Location = new System.Drawing.Point(8, 93);
            this.groupBoxMailingInfo2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo2.Name = "groupBoxMailingInfo2";
            this.groupBoxMailingInfo2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo2.Size = new System.Drawing.Size(342, 63);
            this.groupBoxMailingInfo2.TabIndex = 1;
            this.groupBoxMailingInfo2.TabStop = false;
            // 
            // labelTimeLeftUntilEnd
            // 
            this.labelTimeLeftUntilEnd.AutoSize = true;
            this.labelTimeLeftUntilEnd.Location = new System.Drawing.Point(233, 37);
            this.labelTimeLeftUntilEnd.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelTimeLeftUntilEnd.Name = "labelTimeLeftUntilEnd";
            this.labelTimeLeftUntilEnd.Size = new System.Drawing.Size(72, 17);
            this.labelTimeLeftUntilEnd.TabIndex = 4;
            this.labelTimeLeftUntilEnd.Text = "00 : 00 : 00";
            // 
            // labelMailingStartTime
            // 
            this.labelMailingStartTime.AutoSize = true;
            this.labelMailingStartTime.Location = new System.Drawing.Point(127, 14);
            this.labelMailingStartTime.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelMailingStartTime.Name = "labelMailingStartTime";
            this.labelMailingStartTime.Size = new System.Drawing.Size(47, 17);
            this.labelMailingStartTime.TabIndex = 3;
            this.labelMailingStartTime.Text = "00 : 00";
            // 
            // labelTimeToEndMailingInfo
            // 
            this.labelTimeToEndMailingInfo.AutoSize = true;
            this.labelTimeToEndMailingInfo.Location = new System.Drawing.Point(7, 37);
            this.labelTimeToEndMailingInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeToEndMailingInfo.Name = "labelTimeToEndMailingInfo";
            this.labelTimeToEndMailingInfo.Size = new System.Drawing.Size(222, 17);
            this.labelTimeToEndMailingInfo.TabIndex = 1;
            this.labelTimeToEndMailingInfo.Text = "Приблизительное время до конца: ";
            // 
            // labelMailingStartTimeInfo
            // 
            this.labelMailingStartTimeInfo.AutoSize = true;
            this.labelMailingStartTimeInfo.Location = new System.Drawing.Point(7, 14);
            this.labelMailingStartTimeInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelMailingStartTimeInfo.Name = "labelMailingStartTimeInfo";
            this.labelMailingStartTimeInfo.Size = new System.Drawing.Size(120, 17);
            this.labelMailingStartTimeInfo.TabIndex = 0;
            this.labelMailingStartTimeInfo.Text = "Начало рассылки: ";
            // 
            // groupBoxMailingInfo1
            // 
            this.groupBoxMailingInfo1.Controls.Add(this.labelSendersCount);
            this.groupBoxMailingInfo1.Controls.Add(this.labelRecipientsCount);
            this.groupBoxMailingInfo1.Controls.Add(this.labelSendersCountInfo);
            this.groupBoxMailingInfo1.Controls.Add(this.labelRecipientsCountInfo);
            this.groupBoxMailingInfo1.Location = new System.Drawing.Point(8, 23);
            this.groupBoxMailingInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo1.Name = "groupBoxMailingInfo1";
            this.groupBoxMailingInfo1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxMailingInfo1.Size = new System.Drawing.Size(342, 63);
            this.groupBoxMailingInfo1.TabIndex = 0;
            this.groupBoxMailingInfo1.TabStop = false;
            // 
            // labelSendersCount
            // 
            this.labelSendersCount.AutoSize = true;
            this.labelSendersCount.Location = new System.Drawing.Point(173, 37);
            this.labelSendersCount.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelSendersCount.Name = "labelSendersCount";
            this.labelSendersCount.Size = new System.Drawing.Size(15, 17);
            this.labelSendersCount.TabIndex = 3;
            this.labelSendersCount.Text = "0";
            // 
            // labelRecipientsCount
            // 
            this.labelRecipientsCount.AutoSize = true;
            this.labelRecipientsCount.Location = new System.Drawing.Point(99, 14);
            this.labelRecipientsCount.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelRecipientsCount.Name = "labelRecipientsCount";
            this.labelRecipientsCount.Size = new System.Drawing.Size(15, 17);
            this.labelRecipientsCount.TabIndex = 2;
            this.labelRecipientsCount.Text = "0";
            // 
            // labelSendersCountInfo
            // 
            this.labelSendersCountInfo.AutoSize = true;
            this.labelSendersCountInfo.Location = new System.Drawing.Point(7, 37);
            this.labelSendersCountInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSendersCountInfo.Name = "labelSendersCountInfo";
            this.labelSendersCountInfo.Size = new System.Drawing.Size(162, 17);
            this.labelSendersCountInfo.TabIndex = 1;
            this.labelSendersCountInfo.Text = "Аккаунтов-отправителей: ";
            // 
            // labelRecipientsCountInfo
            // 
            this.labelRecipientsCountInfo.AutoSize = true;
            this.labelRecipientsCountInfo.Location = new System.Drawing.Point(7, 14);
            this.labelRecipientsCountInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelRecipientsCountInfo.Name = "labelRecipientsCountInfo";
            this.labelRecipientsCountInfo.Size = new System.Drawing.Size(92, 17);
            this.labelRecipientsCountInfo.TabIndex = 0;
            this.labelRecipientsCountInfo.Text = "Получателей: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(1167, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Срок действия ключа активации: до 30.06.2021 (включительно)";
            // 
            // groupBoxCurrentProcessState
            // 
            this.groupBoxCurrentProcessState.Controls.Add(this.labelCurrentProcess);
            this.groupBoxCurrentProcessState.Controls.Add(this.progressBarCurrentProcess);
            this.groupBoxCurrentProcessState.Enabled = false;
            this.groupBoxCurrentProcessState.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxCurrentProcessState.Location = new System.Drawing.Point(302, 492);
            this.groupBoxCurrentProcessState.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxCurrentProcessState.Name = "groupBoxCurrentProcessState";
            this.groupBoxCurrentProcessState.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxCurrentProcessState.Size = new System.Drawing.Size(849, 113);
            this.groupBoxCurrentProcessState.TabIndex = 5;
            this.groupBoxCurrentProcessState.TabStop = false;
            this.groupBoxCurrentProcessState.Text = "Состояние";
            // 
            // labelCurrentProcess
            // 
            this.labelCurrentProcess.AutoSize = true;
            this.labelCurrentProcess.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentProcess.Location = new System.Drawing.Point(8, 39);
            this.labelCurrentProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentProcess.Name = "labelCurrentProcess";
            this.labelCurrentProcess.Size = new System.Drawing.Size(103, 13);
            this.labelCurrentProcess.TabIndex = 1;
            this.labelCurrentProcess.Text = "Текущий процесс:";
            // 
            // progressBarCurrentProcess
            // 
            this.progressBarCurrentProcess.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBarCurrentProcess.Location = new System.Drawing.Point(12, 69);
            this.progressBarCurrentProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarCurrentProcess.MarqueeAnimationSpeed = 10;
            this.progressBarCurrentProcess.Maximum = 1000000000;
            this.progressBarCurrentProcess.Name = "progressBarCurrentProcess";
            this.progressBarCurrentProcess.Size = new System.Drawing.Size(829, 27);
            this.progressBarCurrentProcess.Step = 1;
            this.progressBarCurrentProcess.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1167, 505);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Приложение создано специально для";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1167, 520);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Компании Goszakaz Consulting Group";
            // 
            // linkLabelMe
            // 
            this.linkLabelMe.AutoSize = true;
            this.linkLabelMe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.linkLabelMe.Location = new System.Drawing.Point(1167, 554);
            this.linkLabelMe.Name = "linkLabelMe";
            this.linkLabelMe.Size = new System.Drawing.Size(235, 15);
            this.linkLabelMe.TabIndex = 8;
            this.linkLabelMe.TabStop = true;
            this.linkLabelMe.Text = "Исполнитель: Колот Антон Викторович";
            this.linkLabelMe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelMe_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(1167, 569);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Почтовый ящик: capricavoid7@gmail.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1167, 584);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Быстрая связь (телеграм): @asprikka";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 617);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabelMe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxCurrentProcessState);
            this.Controls.Add(this.groupBoxMailingInfo);
            this.Controls.Add(this.groupBoxOutputDataTerminal);
            this.Controls.Add(this.groupBoxOtherFunctions);
            this.Controls.Add(this.groupBoxMailingControlPanel);
            this.Controls.Add(this.groupBoxOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainMenuForm";
            this.Text = "Главная панель управления (PipiPonaPoster v4.0.0)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxMailingControlPanel.ResumeLayout(false);
            this.groupBoxOtherFunctions.ResumeLayout(false);
            this.groupBoxOutputDataTerminal.ResumeLayout(false);
            this.groupBoxOutputDataTerminal.PerformLayout();
            this.groupBoxMailingInfo.ResumeLayout(false);
            this.groupBoxMailingInfo3.ResumeLayout(false);
            this.groupBoxMailingInfo3.PerformLayout();
            this.groupBoxMailingInfo2.ResumeLayout(false);
            this.groupBoxMailingInfo2.PerformLayout();
            this.groupBoxMailingInfo1.ResumeLayout(false);
            this.groupBoxMailingInfo1.PerformLayout();
            this.groupBoxCurrentProcessState.ResumeLayout(false);
            this.groupBoxCurrentProcessState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Button buttonMailOptions;
        private System.Windows.Forms.Button buttonSendingOptions;
        private System.Windows.Forms.GroupBox groupBoxMailingControlPanel;
        private System.Windows.Forms.Button buttonPauseMailing;
        private System.Windows.Forms.Button buttonContinueMailing;
        private System.Windows.Forms.Button buttonStartNewMailing;
        private System.Windows.Forms.GroupBox groupBoxOtherFunctions;
        private System.Windows.Forms.Button buttonGetTodaySentMails;
        private System.Windows.Forms.Button buttonOpenLogs;
        private System.Windows.Forms.GroupBox groupBoxOutputDataTerminal;
        private System.Windows.Forms.TextBox textBoxOutputDataTerminal;
        private System.Windows.Forms.GroupBox groupBoxMailingInfo;
        private System.Windows.Forms.GroupBox groupBoxCurrentProcessState;
        private System.Windows.Forms.Label labelCurrentProcess;
        private System.Windows.Forms.ProgressBar progressBarCurrentProcess;
        private System.Windows.Forms.GroupBox groupBoxMailingInfo3;
        private System.Windows.Forms.Label labelFailureMailsCountInfo;
        private System.Windows.Forms.Label labelSuccessMailsCountInfo;
        private System.Windows.Forms.GroupBox groupBoxMailingInfo2;
        private System.Windows.Forms.Label labelTimeToEndMailingInfo;
        private System.Windows.Forms.Label labelMailingStartTimeInfo;
        private System.Windows.Forms.GroupBox groupBoxMailingInfo1;
        private System.Windows.Forms.Label labelSendersCountInfo;
        private System.Windows.Forms.Label labelRecipientsCountInfo;
        private System.Windows.Forms.Label labelFailuresCount;
        private System.Windows.Forms.Label labelSuccessCount;
        private System.Windows.Forms.Label labelTimeLeftUntilEnd;
        private System.Windows.Forms.Label labelMailingStartTime;
        private System.Windows.Forms.Label labelSendersCount;
        private System.Windows.Forms.Label labelRecipientsCount;
        private System.Windows.Forms.Button buttonTerminateMailing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCalculators;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelMe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSaveMailedRecipients;
    }
}

