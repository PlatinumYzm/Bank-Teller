using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
using System.Threading;

namespace Bank_Teller
{
	
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			/*状态栏的实时时间*/
			this.timer1.Start();
			//Teller.Tellno = "BOC190001";
			//Console.WriteLine(">>"+System.Environment.Version);
		}
		/*Windows验证方式连接数据库，安全性高*/
		public static string connectionString = "server=localhost;database=Bank;integrated security=SSPI";
		SqlConnection mySqlConnection = new SqlConnection(connectionString);

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				mySqlConnection.Open();
				this.toolStripStatusLabel1.Text = "连接SQL数据库成功";
			}
			catch(Exception err)
			{
				this.toolStripStatusLabel1.Text = "连接SQL数据库失败";
			}
			/*
			 * 该连接方式安全性低，容易受到黑客攻击
			string connectionString= "server=localhost;database=Bank;User Id=sa;Password=123456";
			SqlConnection mySqlConnection = new SqlConnection(connectionString);
			try
			{
				mySqlConnection.Open();
			}
			catch (Exception err)
			{
				MessageBox.Show("连接失败，重试请点击确认，否则点击取消","连接失败", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation); 
			}
			*/
		}

		/// <summary>
		/// 登录柜员账号
		/// 未登录柜员账号，则没有权限使用该系统
		/// 
		/// 已创建的柜员账号
		/// 工号:BOC1900001
		/// 密码:123456qwe!
		/// 
		/// 用户也可以自行注册柜员账号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void 登录SQL数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Teller.Tellno != null)
			{
				string login = string.Format("账号'{0}'已登录！", Teller.Tellno);
				MessageBox.Show(login, "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Form2 f2 = new Form2();
			f2.StartPosition = FormStartPosition.CenterScreen;
			f2.ShowDialog();
			this.toolStripStatusLabel3.Text = "欢迎您！" + Teller.Tellno + " " + Teller.Name;
		}

		private void 关闭连接ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if(MessageBox.Show("关闭数据库连接?", "关闭连接" ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
				{
					mySqlConnection.Close();
					this.toolStripStatusLabel1.Text = "断开SQL数据库连接";
				}	
			}
			catch(Exception err)
			{
				MessageBox.Show("关闭连接失败");
			}
		}

		/// <summary>
		/// 双击任务栏图标（中国银行标志）
		/// 激活窗体并给予焦点
		/// 将窗体显示在最上层
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
		}

		/// <summary>
		/// 点击工具栏的退出系统选项
		/// 触发ToolStripMenuItem_Click方法
		/// 询问用户是否退出系统
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("退出系统?\n退出前请保存数据的变更","中国银行柜员系统",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
			{
				mySqlConnection.Close();
				Dispose();
				Application.Exit();
			}
		}

		/// <summary>
		/// 点击窗体右上角的关闭按钮
		/// 触发FormClosing方法
		/// 询问用户是否退出系统
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			if (MessageBox.Show("退出系统?\n退出前请保存数据的变更", "中国银行柜员系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				mySqlConnection.Close();
				e.Cancel = false;
			}
		}

		/// <summary>
		/// 连接数据库
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Console.WriteLine(mySqlConnection.State.ToString());
			if(mySqlConnection.State.ToString()!="Open")
			{
				try
				{
					mySqlConnection.Open();
					MessageBox.Show("连接SQL数据库成功");
					this.toolStripStatusLabel1.Text = "连接SQL数据库成功";
				}
				catch (Exception err)
				{
					MessageBox.Show("连接SQL数据库失败");
				}
			}
			else
			{
				MessageBox.Show("已连接SQL数据库");
			}			
		}

		/// <summary>
		/// 获取当前时间
		/// timer用于时间同步
		/// 每经过1秒，时间自加1秒
		/// 比同步服务器时间更高效率，而且不容易出现跳秒的情况
		/// 时间精准度高
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.toolStripStatusLabel2.Text = "时间:" + DateTime.Now.ToString();
		}

		/// <summary>
		/// 检测当前是否已登录柜员账号
		/// 若未登录
		/// 则无法获取操作业务的权限
		/// 只能查看初始化配置功能
		/// </summary>
		/// <returns></returns>
		private static bool authorization()
		{
			if (Teller.Tellno == null) return false;
			else return true;
		}

		/*
		 * 以下是6个业务图标的触发事件
		 * 登录柜员账户后，
		 * 点击图标，弹出业务窗体；
		 * 未登录柜员账户，
		 * 则弹出模态框提醒用户登录柜员账号
		 */
		private void button1_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				Form4 f4 = new Form4();
				f4.StartPosition = FormStartPosition.CenterScreen;
				f4.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				Withdrawal f5 = new Withdrawal();
				f5.StartPosition = FormStartPosition.CenterScreen;
				f5.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				Establishment f8 = new Establishment();
				f8.StartPosition = FormStartPosition.CenterScreen;
				f8.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				Transaction f6 = new Transaction();
				f6.StartPosition = FormStartPosition.CenterScreen;
				f6.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				LoanApply f7 = new LoanApply();
				f7.StartPosition = FormStartPosition.CenterScreen;
				f7.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				Form11 f11 = new Form11();
				f11.StartPosition = FormStartPosition.CenterScreen;
				f11.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Teller.Tellno == null) {
				MessageBox.Show("当前无账号正在登录！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (MessageBox.Show("注销账号?", "中国银行柜员系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Teller.Tellno = null;
				Teller.Name = null;
				Teller.Gender = null;
				this.toolStripStatusLabel3.Text = "";
			}
		}

		private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (authorization())
			{
				Form10 f10 = new Form10();
				f10.StartPosition = FormStartPosition.CenterScreen;
				f10.ShowDialog();
			}
			else
			{
				MessageBox.Show("请登录柜员账号！", "中国银行柜员系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/// <summary>
		/// 弹出初始化配置教程窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void 初始化ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Init f12 = new Init();
			f12.StartPosition = FormStartPosition.CenterScreen;
			f12.ShowDialog();
		}
	}
}
