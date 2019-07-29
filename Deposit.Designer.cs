namespace Bank_Teller
{
	partial class Form4
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
			this.label3 = new System.Windows.Forms.Label();
			this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 18F);
			this.label3.Location = new System.Drawing.Point(352, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 30);
			this.label3.TabIndex = 6;
			this.label3.Text = "存款";
			// 
			// maskedTextBox1
			// 
			this.maskedTextBox1.Font = new System.Drawing.Font("宋体", 16F);
			this.maskedTextBox1.Location = new System.Drawing.Point(282, 155);
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(344, 38);
			this.maskedTextBox1.TabIndex = 31;
			this.maskedTextBox1.Leave += new System.EventHandler(this.maskedTextBox1_Leave);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("宋体", 16F);
			this.label11.Location = new System.Drawing.Point(122, 158);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(120, 27);
			this.label11.TabIndex = 30;
			this.label11.Text = "账户号码";
			// 
			// maskedTextBox2
			// 
			this.maskedTextBox2.Font = new System.Drawing.Font("宋体", 16F);
			this.maskedTextBox2.Location = new System.Drawing.Point(282, 228);
			this.maskedTextBox2.Name = "maskedTextBox2";
			this.maskedTextBox2.Size = new System.Drawing.Size(344, 38);
			this.maskedTextBox2.TabIndex = 33;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 16F);
			this.label1.Location = new System.Drawing.Point(122, 231);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 27);
			this.label1.TabIndex = 32;
			this.label1.Text = "存款金额";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.Control;
			this.button2.Font = new System.Drawing.Font("宋体", 16F);
			this.button2.Location = new System.Drawing.Point(295, 415);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(203, 50);
			this.button2.TabIndex = 34;
			this.button2.Text = "提交";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 16F);
			this.label2.Location = new System.Drawing.Point(122, 301);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 27);
			this.label2.TabIndex = 35;
			this.label2.Text = "存款余额";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("宋体", 16F);
			this.textBox1.Location = new System.Drawing.Point(282, 298);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(344, 38);
			this.textBox1.TabIndex = 36;
			this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 12F);
			this.label4.Location = new System.Drawing.Point(278, 339);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(229, 20);
			this.label4.TabIndex = 37;
			this.label4.Text = "(点击文本框，查询余额)";
			// 
			// Form4
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 553);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.maskedTextBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.maskedTextBox1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form4";
			this.Text = "中国银行柜员系统";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox maskedTextBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.MaskedTextBox maskedTextBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
	}
}