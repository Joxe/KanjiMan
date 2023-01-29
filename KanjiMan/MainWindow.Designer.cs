namespace KanjiMan {
	partial class MainWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.InputTextBox = new System.Windows.Forms.TextBox();
			this.KanjiLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SubmitButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.TranslationBox = new System.Windows.Forms.ListBox();
			this.RomajiBox = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.CorrectLabel = new System.Windows.Forms.Label();
			this.AttemptsLabel = new System.Windows.Forms.Label();
			this.PercentLabel = new System.Windows.Forms.Label();
			this.ResultLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// InputTextBox
			// 
			this.InputTextBox.Location = new System.Drawing.Point(12, 62);
			this.InputTextBox.Name = "InputTextBox";
			this.InputTextBox.Size = new System.Drawing.Size(614, 23);
			this.InputTextBox.TabIndex = 0;
			this.InputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// KanjiLabel
			// 
			this.KanjiLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.KanjiLabel.AutoSize = true;
			this.KanjiLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.KanjiLabel.Location = new System.Drawing.Point(201, 9);
			this.KanjiLabel.Name = "KanjiLabel";
			this.KanjiLabel.Size = new System.Drawing.Size(39, 32);
			this.KanjiLabel.TabIndex = 1;
			this.KanjiLabel.Text = "今";
			this.KanjiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(191, 32);
			this.label2.TabIndex = 2;
			this.label2.Text = "Input Romaji for:";
			// 
			// SubmitButton
			// 
			this.SubmitButton.Location = new System.Drawing.Point(713, 61);
			this.SubmitButton.Name = "SubmitButton";
			this.SubmitButton.Size = new System.Drawing.Size(75, 23);
			this.SubmitButton.TabIndex = 3;
			this.SubmitButton.Text = "Submit";
			this.SubmitButton.UseVisualStyleBackColor = true;
			this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(154, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 32);
			this.label3.TabIndex = 5;
			this.label3.Text = "Romaji";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label5.Location = new System.Drawing.Point(541, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 32);
			this.label5.TabIndex = 6;
			this.label5.Text = "Translations";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(632, 61);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Skip";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// TranslationBox
			// 
			this.TranslationBox.Enabled = false;
			this.TranslationBox.FormattingEnabled = true;
			this.TranslationBox.ItemHeight = 15;
			this.TranslationBox.Location = new System.Drawing.Point(405, 179);
			this.TranslationBox.Name = "TranslationBox";
			this.TranslationBox.Size = new System.Drawing.Size(383, 259);
			this.TranslationBox.TabIndex = 8;
			// 
			// RomajiBox
			// 
			this.RomajiBox.Enabled = false;
			this.RomajiBox.FormattingEnabled = true;
			this.RomajiBox.ItemHeight = 15;
			this.RomajiBox.Location = new System.Drawing.Point(12, 179);
			this.RomajiBox.Name = "RomajiBox";
			this.RomajiBox.Size = new System.Drawing.Size(375, 259);
			this.RomajiBox.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(684, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 15);
			this.label4.TabIndex = 10;
			this.label4.Text = "Attempts";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(684, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 15);
			this.label6.TabIndex = 11;
			this.label6.Text = "Correct";
			// 
			// CorrectLabel
			// 
			this.CorrectLabel.AutoSize = true;
			this.CorrectLabel.Location = new System.Drawing.Point(765, 26);
			this.CorrectLabel.Name = "CorrectLabel";
			this.CorrectLabel.Size = new System.Drawing.Size(13, 15);
			this.CorrectLabel.TabIndex = 13;
			this.CorrectLabel.Text = "0";
			// 
			// AttemptsLabel
			// 
			this.AttemptsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AttemptsLabel.AutoSize = true;
			this.AttemptsLabel.Location = new System.Drawing.Point(765, 9);
			this.AttemptsLabel.Name = "AttemptsLabel";
			this.AttemptsLabel.Size = new System.Drawing.Size(13, 15);
			this.AttemptsLabel.TabIndex = 12;
			this.AttemptsLabel.Text = "0";
			this.AttemptsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// PercentLabel
			// 
			this.PercentLabel.AutoSize = true;
			this.PercentLabel.Location = new System.Drawing.Point(755, 41);
			this.PercentLabel.Name = "PercentLabel";
			this.PercentLabel.Size = new System.Drawing.Size(23, 15);
			this.PercentLabel.TabIndex = 15;
			this.PercentLabel.Text = "0%";
			// 
			// ResultLabel
			// 
			this.ResultLabel.AutoSize = true;
			this.ResultLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ResultLabel.Location = new System.Drawing.Point(12, 97);
			this.ResultLabel.Name = "ResultLabel";
			this.ResultLabel.Size = new System.Drawing.Size(285, 32);
			this.ResultLabel.TabIndex = 17;
			this.ResultLabel.Text = "Correct! 今 romaji is \'ima\'";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ResultLabel);
			this.Controls.Add(this.PercentLabel);
			this.Controls.Add(this.CorrectLabel);
			this.Controls.Add(this.AttemptsLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.RomajiBox);
			this.Controls.Add(this.TranslationBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SubmitButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.KanjiLabel);
			this.Controls.Add(this.InputTextBox);
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox InputTextBox;
		private Label KanjiLabel;
		private Label label2;
		private Button SubmitButton;
		private Label label3;
		private Label label5;
		private Button button2;
		private ListBox TranslationBox;
		private ListBox RomajiBox;
		private Label label4;
		private Label label6;
		private Label CorrectLabel;
		private Label AttemptsLabel;
		private Label PercentLabel;
		private Label ResultLabel;
	}
}