
namespace StepperControlEthernet
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.remoteportTextBox = new System.Windows.Forms.TextBox();
            this.remoteadressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.localportTextBox = new System.Windows.Forms.TextBox();
            this.receivedMessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(237, 23);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(81, 35);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Задать параметры";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(264, 128);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "=>";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // remoteportTextBox
            // 
            this.remoteportTextBox.Location = new System.Drawing.Point(117, 31);
            this.remoteportTextBox.Name = "remoteportTextBox";
            this.remoteportTextBox.Size = new System.Drawing.Size(100, 20);
            this.remoteportTextBox.TabIndex = 2;
            // 
            // remoteadressTextBox
            // 
            this.remoteadressTextBox.Location = new System.Drawing.Point(117, 57);
            this.remoteadressTextBox.Name = "remoteadressTextBox";
            this.remoteadressTextBox.Size = new System.Drawing.Size(100, 20);
            this.remoteadressTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Порт получателя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP получателя";
            // 
            // commandTextBox
            // 
            this.commandTextBox.Location = new System.Drawing.Point(12, 128);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(234, 20);
            this.commandTextBox.TabIndex = 5;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(237, 64);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(81, 35);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Закрыть соединение";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Порт отправителя";
            // 
            // localportTextBox
            // 
            this.localportTextBox.Location = new System.Drawing.Point(117, 5);
            this.localportTextBox.Name = "localportTextBox";
            this.localportTextBox.Size = new System.Drawing.Size(100, 20);
            this.localportTextBox.TabIndex = 1;
            // 
            // receivedMessageTextBox
            // 
            this.receivedMessageTextBox.Location = new System.Drawing.Point(12, 174);
            this.receivedMessageTextBox.Name = "receivedMessageTextBox";
            this.receivedMessageTextBox.ReadOnly = true;
            this.receivedMessageTextBox.Size = new System.Drawing.Size(234, 20);
            this.receivedMessageTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 225);
            this.Controls.Add(this.receivedMessageTextBox);
            this.Controls.Add(this.localportTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.commandTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remoteadressTextBox);
            this.Controls.Add(this.remoteportTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.loginButton);
            this.Name = "Form1";
            this.Text = "Lassard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox remoteportTextBox;
        private System.Windows.Forms.TextBox remoteadressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox localportTextBox;
        private System.Windows.Forms.TextBox receivedMessageTextBox;
    }
}

