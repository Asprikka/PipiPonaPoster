
namespace PipiPonaPoster.Source.View
{
    partial class ActivationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKeyInput = new System.Windows.Forms.TextBox();
            this.buttonActivate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(87, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПОЛЕ ДЛЯ КЛЮЧА АКТИВАЦИИ";
            // 
            // textBoxKeyInput
            // 
            this.textBoxKeyInput.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxKeyInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBoxKeyInput.Location = new System.Drawing.Point(87, 51);
            this.textBoxKeyInput.Name = "textBoxKeyInput";
            this.textBoxKeyInput.PasswordChar = '*';
            this.textBoxKeyInput.Size = new System.Drawing.Size(288, 32);
            this.textBoxKeyInput.TabIndex = 1;
            this.textBoxKeyInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonActivate
            // 
            this.buttonActivate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonActivate.Location = new System.Drawing.Point(121, 89);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(220, 43);
            this.buttonActivate.TabIndex = 2;
            this.buttonActivate.Text = "Активировать";
            this.buttonActivate.UseVisualStyleBackColor = true;
            this.buttonActivate.Click += new System.EventHandler(this.ButtonActivate_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.RosyBrown;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(12, 149);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(447, 108);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "ПРЕДУПРЕЖДЕНИЕ!!!\r\n\r\nПРИЛОЖЕНИЕ ВКЛЮЧАЕТ В СЕБЯ МЕРЫ ПРЕДОТВРАЩАЮЩИЕ УЩЕРБ ПРОГРА" +
    "ММЕ.\r\nПОЭТОМУ НАСТОЯТЕЛЬНО НЕ РЕКОМЕНДУЕТСЯ КАК-ЛИБО ВЛИЯТЬ НА ВАЖНЫЕ ПРОГРАММНЫ" +
    "Е ФАЙЛЫ!";
            // 
            // ActivationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(471, 267);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonActivate);
            this.Controls.Add(this.textBoxKeyInput);
            this.Controls.Add(this.label1);
            this.Name = "ActivationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно активации продукта (PipiPona Poster v4.0.0)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKeyInput;
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.TextBox textBox1;
    }
}