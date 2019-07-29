namespace Bank_Teller
{
	partial class Transaction
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transaction));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("宋体", 16F);
			this.textBox1.Location = new System.Drawing.Point(249, 192);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(344, 38);
			this.textBox1.TabIndex = 3;
			this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 16F);
			this.label2.Location = new System.Drawing.Point(89, 195);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 27);
			this.label2.TabIndex = 53;
			this.label2.Text = "当前余额";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Font = new System.Drawing.Font("宋体", 16F);
			this.button1.Location = new System.Drawing.Point(265, 475);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(203, 50);
			this.button1.TabIndex = 52;
			this.button1.Text = "提交";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// maskedTextBox1
			// 
			this.maskedTextBox1.Font = new System.Drawing.Font("宋体", 16F);
			this.maskedTextBox1.Location = new System.Drawing.Point(249, 70);
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(344, 38);
			this.maskedTextBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 16F);
			this.label1.Location = new System.Drawing.Point(89, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 27);
			this.label1.TabIndex = 50;
			this.label1.Text = "收款账号";
			// 
			// maskedTextBox2
			// 
			this.maskedTextBox2.Font = new System.Drawing.Font("宋体", 16F);
			this.maskedTextBox2.Location = new System.Drawing.Point(249, 126);
			this.maskedTextBox2.Name = "maskedTextBox2";
			this.maskedTextBox2.Size = new System.Drawing.Size(344, 38);
			this.maskedTextBox2.TabIndex = 2;
			this.maskedTextBox2.Leave += new System.EventHandler(this.maskedTextBox2_Leave);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("宋体", 16F);
			this.label11.Location = new System.Drawing.Point(89, 129);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(120, 27);
			this.label11.TabIndex = 48;
			this.label11.Text = "付款账号";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 18F);
			this.label3.Location = new System.Drawing.Point(328, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 30);
			this.label3.TabIndex = 47;
			this.label3.Text = "转账";
			// 
			// textBox2
			// 
			this.textBox2.Font = new System.Drawing.Font("宋体", 16F);
			this.textBox2.Location = new System.Drawing.Point(249, 260);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(344, 38);
			this.textBox2.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 16F);
			this.label4.Location = new System.Drawing.Point(89, 263);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 27);
			this.label4.TabIndex = 55;
			this.label4.Text = "汇款金额";
			// 
			// maskedTextBox3
			// 
			this.maskedTextBox3.Font = new System.Drawing.Font("宋体", 16F);
			this.maskedTextBox3.Location = new System.Drawing.Point(249, 321);
			this.maskedTextBox3.Mask = "000-0000-0000";
			this.maskedTextBox3.Name = "maskedTextBox3";
			this.maskedTextBox3.Size = new System.Drawing.Size(344, 38);
			this.maskedTextBox3.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 16F);
			this.label5.Location = new System.Drawing.Point(89, 324);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 27);
			this.label5.TabIndex = 58;
			this.label5.Text = "收款手机*";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 16F);
			this.label6.Location = new System.Drawing.Point(89, 388);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 27);
			this.label6.TabIndex = 59;
			this.label6.Text = "短信通知*";
			// 
			// textBox3
			// 
			this.textBox3.Font = new System.Drawing.Font("宋体", 16F);
			this.textBox3.Location = new System.Drawing.Point(249, 385);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(344, 38);
			this.textBox3.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 11F);
			this.label7.Location = new System.Drawing.Point(90, 438);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(410, 19);
			this.label7.TabIndex = 61;
			this.label7.Text = "短信通知费：0.2元/条，资费由移动运营商定价";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 12F);
			this.label8.Location = new System.Drawing.Point(245, 233);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(229, 20);
			this.label8.TabIndex = 62;
			this.label8.Text = "(点击文本框，查询余额)";
			// 
			// Form6
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 553);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.maskedTextBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.maskedTextBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.maskedTextBox2);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form6";
			this.Text = "中国银行柜员系统";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MaskedTextBox maskedTextBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MaskedTextBox maskedTextBox2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox maskedTextBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
	}
}