namespace kaspersky_crackme2016_keygen
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
			this.buttonRestorePassword = new System.Windows.Forms.Button();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPass = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonValidateCredentials = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.labelCheckedHashes = new System.Windows.Forms.Label();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.labelHackingHashNumber = new System.Windows.Forms.Label();
			this.labelControlHash = new System.Windows.Forms.Label();
			this.buttonBruteControlHash = new System.Windows.Forms.Button();
			this.labelInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonRestorePassword
			// 
			this.buttonRestorePassword.Enabled = false;
			this.buttonRestorePassword.Location = new System.Drawing.Point(187, 114);
			this.buttonRestorePassword.Name = "buttonRestorePassword";
			this.buttonRestorePassword.Size = new System.Drawing.Size(150, 23);
			this.buttonRestorePassword.TabIndex = 0;
			this.buttonRestorePassword.Text = "Restore Password";
			this.buttonRestorePassword.UseVisualStyleBackColor = true;
			this.buttonRestorePassword.Click += new System.EventHandler(this.buttonRestorePassword_Click);
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(139, 62);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(276, 20);
			this.textBoxEmail.TabIndex = 1;
			this.textBoxEmail.Text = "truecooler@gmail.com";
			// 
			// textBoxPass
			// 
			this.textBoxPass.Location = new System.Drawing.Point(139, 88);
			this.textBoxPass.Name = "textBoxPass";
			this.textBoxPass.Size = new System.Drawing.Size(276, 20);
			this.textBoxPass.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(96, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "email:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(78, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "password:";
			// 
			// buttonValidateCredentials
			// 
			this.buttonValidateCredentials.Enabled = false;
			this.buttonValidateCredentials.Location = new System.Drawing.Point(343, 114);
			this.buttonValidateCredentials.Name = "buttonValidateCredentials";
			this.buttonValidateCredentials.Size = new System.Drawing.Size(111, 23);
			this.buttonValidateCredentials.TabIndex = 5;
			this.buttonValidateCredentials.Text = "Validate credentials";
			this.buttonValidateCredentials.UseVisualStyleBackColor = true;
			this.buttonValidateCredentials.Click += new System.EventHandler(this.buttonValidateCredentials_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 239);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(470, 23);
			this.progressBar1.TabIndex = 6;
			// 
			// labelCheckedHashes
			// 
			this.labelCheckedHashes.AutoSize = true;
			this.labelCheckedHashes.Location = new System.Drawing.Point(42, 156);
			this.labelCheckedHashes.Name = "labelCheckedHashes";
			this.labelCheckedHashes.Size = new System.Drawing.Size(126, 13);
			this.labelCheckedHashes.TabIndex = 7;
			this.labelCheckedHashes.Text = "Хешей проверено: 0 / 0";
			// 
			// progressBar2
			// 
			this.progressBar2.Location = new System.Drawing.Point(12, 268);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(470, 23);
			this.progressBar2.Step = 25;
			this.progressBar2.TabIndex = 8;
			// 
			// labelHackingHashNumber
			// 
			this.labelHackingHashNumber.AutoSize = true;
			this.labelHackingHashNumber.Location = new System.Drawing.Point(42, 169);
			this.labelHackingHashNumber.Name = "labelHackingHashNumber";
			this.labelHackingHashNumber.Size = new System.Drawing.Size(143, 13);
			this.labelHackingHashNumber.TabIndex = 9;
			this.labelHackingHashNumber.Text = "Ожидание запуска брута...";
			// 
			// labelControlHash
			// 
			this.labelControlHash.AutoSize = true;
			this.labelControlHash.Location = new System.Drawing.Point(42, 182);
			this.labelControlHash.Name = "labelControlHash";
			this.labelControlHash.Size = new System.Drawing.Size(283, 13);
			this.labelControlHash.TabIndex = 10;
			this.labelControlHash.Text = "Контрольный хеш: ??????????????????????????????";
			// 
			// buttonBruteControlHash
			// 
			this.buttonBruteControlHash.Location = new System.Drawing.Point(81, 114);
			this.buttonBruteControlHash.Name = "buttonBruteControlHash";
			this.buttonBruteControlHash.Size = new System.Drawing.Size(100, 23);
			this.buttonBruteControlHash.TabIndex = 11;
			this.buttonBruteControlHash.Text = "BruteControlHash";
			this.buttonBruteControlHash.UseVisualStyleBackColor = true;
			this.buttonBruteControlHash.Click += new System.EventHandler(this.buttonBruteControlHash_Click);
			// 
			// labelInfo
			// 
			this.labelInfo.AutoSize = true;
			this.labelInfo.Location = new System.Drawing.Point(78, 9);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(355, 13);
			this.labelInfo.TabIndex = 12;
			this.labelInfo.Text = "Что бы восстановить пароль, сначала взломайте контрольный хеш.";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 316);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.buttonBruteControlHash);
			this.Controls.Add(this.labelControlHash);
			this.Controls.Add(this.labelHackingHashNumber);
			this.Controls.Add(this.progressBar2);
			this.Controls.Add(this.labelCheckedHashes);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.buttonValidateCredentials);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPass);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.buttonRestorePassword);
			this.Name = "Form1";
			this.Text = "Kaspersky crackme2016 keygen by TheCooler";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonRestorePassword;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.TextBox textBoxPass;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonValidateCredentials;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelCheckedHashes;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.Label labelHackingHashNumber;
		private System.Windows.Forms.Label labelControlHash;
		private System.Windows.Forms.Button buttonBruteControlHash;
		private System.Windows.Forms.Label labelInfo;
	}
}

