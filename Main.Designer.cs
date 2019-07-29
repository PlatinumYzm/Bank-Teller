namespace Bank_Teller
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.登录账号 = new System.Windows.Forms.ToolStripMenuItem();
			this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.关闭连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.贷款审批 = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.button7 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.贷款审批,
            this.初始化ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1006, 31);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录账号,
            this.注销ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.关闭连接ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.文件ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(107, 27);
			this.文件ToolStripMenuItem.Text = "登录与连接";
			// 
			// 登录账号
			// 
			this.登录账号.Name = "登录账号";
			this.登录账号.Size = new System.Drawing.Size(205, 28);
			this.登录账号.Text = "登录账号";
			this.登录账号.Click += new System.EventHandler(this.登录SQL数据库ToolStripMenuItem_Click);
			// 
			// 注销ToolStripMenuItem
			// 
			this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
			this.注销ToolStripMenuItem.Size = new System.Drawing.Size(205, 28);
			this.注销ToolStripMenuItem.Text = "注销账号";
			this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 28);
			this.toolStripMenuItem1.Text = "连接数据库";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// 关闭连接ToolStripMenuItem
			// 
			this.关闭连接ToolStripMenuItem.Name = "关闭连接ToolStripMenuItem";
			this.关闭连接ToolStripMenuItem.Size = new System.Drawing.Size(205, 28);
			this.关闭连接ToolStripMenuItem.Text = "关闭数据库连接";
			this.关闭连接ToolStripMenuItem.Click += new System.EventHandler(this.关闭连接ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(205, 28);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// 贷款审批
			// 
			this.贷款审批.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
			this.贷款审批.Name = "贷款审批";
			this.贷款审批.Size = new System.Drawing.Size(90, 27);
			this.贷款审批.Text = "贷款审批";
			this.贷款审批.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "中国银行柜员系统";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 9F);
			this.label2.Location = new System.Drawing.Point(1118, 189);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 15);
			this.label2.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("宋体", 14F);
			this.button1.ForeColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(197, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 150);
			this.button1.TabIndex = 2;
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("宋体", 14F);
			this.button2.ForeColor = System.Drawing.SystemColors.Control;
			this.button2.Location = new System.Drawing.Point(432, 176);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 150);
			this.button2.TabIndex = 3;
			this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 24F);
			this.label3.Location = new System.Drawing.Point(308, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(417, 40);
			this.label3.TabIndex = 5;
			this.label3.Text = "中国银行柜员系统首页";
			// 
			// button3
			// 
			this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("宋体", 14F);
			this.button3.ForeColor = System.Drawing.SystemColors.Control;
			this.button3.Location = new System.Drawing.Point(197, 412);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(150, 150);
			this.button3.TabIndex = 5;
			this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 16F);
			this.label4.Location = new System.Drawing.Point(236, 329);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 27);
			this.label4.TabIndex = 8;
			this.label4.Text = "存款";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 16F);
			this.label5.Location = new System.Drawing.Point(468, 329);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 27);
			this.label5.TabIndex = 9;
			this.label5.Text = "取款";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 16F);
			this.label6.Location = new System.Drawing.Point(236, 566);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 27);
			this.label6.TabIndex = 10;
			this.label6.Text = "开户";
			// 
			// button5
			// 
			this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
			this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Font = new System.Drawing.Font("宋体", 14F);
			this.button5.ForeColor = System.Drawing.SystemColors.Control;
			this.button5.Location = new System.Drawing.Point(666, 176);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(150, 150);
			this.button5.TabIndex = 4;
			this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 16F);
			this.label8.Location = new System.Drawing.Point(710, 329);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 27);
			this.label8.TabIndex = 13;
			this.label8.Text = "转账";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
			this.statusStrip1.Location = new System.Drawing.Point(0, 699);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1006, 22);
			this.statusStrip1.TabIndex = 17;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(175, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(180, 3, 0, 2);
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(175, 17);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(120, 3, 0, 2);
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
			// 
			// button7
			// 
			this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
			this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.Font = new System.Drawing.Font("宋体", 14F);
			this.button7.ForeColor = System.Drawing.SystemColors.Control;
			this.button7.Location = new System.Drawing.Point(432, 412);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(150, 150);
			this.button7.TabIndex = 6;
			this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 16F);
			this.label1.Location = new System.Drawing.Point(446, 566);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 27);
			this.label1.TabIndex = 19;
			this.label1.Text = "贷款申请";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("宋体", 16F);
			this.label10.Location = new System.Drawing.Point(710, 566);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(66, 27);
			this.label10.TabIndex = 21;
			this.label10.Text = "设置";
			// 
			// button8
			// 
			this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
			this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button8.Font = new System.Drawing.Font("宋体", 14F);
			this.button8.ForeColor = System.Drawing.SystemColors.Control;
			this.button8.Location = new System.Drawing.Point(666, 412);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(150, 150);
			this.button8.TabIndex = 7;
			this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// 初始化ToolStripMenuItem
			// 
			this.初始化ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
			this.初始化ToolStripMenuItem.Name = "初始化ToolStripMenuItem";
			this.初始化ToolStripMenuItem.Size = new System.Drawing.Size(73, 27);
			this.初始化ToolStripMenuItem.Text = "初始化";
			this.初始化ToolStripMenuItem.Click += new System.EventHandler(this.初始化ToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.menuStrip1);
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "中国银行柜员系统";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 登录账号;
		private System.Windows.Forms.ToolStripMenuItem 关闭连接ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 贷款审批;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 初始化ToolStripMenuItem;
	}
}

