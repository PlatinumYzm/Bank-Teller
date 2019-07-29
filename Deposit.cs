using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Bank_Teller
{
	public partial class Form4 : Form
	{
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		
		public string bal;
		public double balance;
		public bool token = false;
		public Form4()
		{
			InitializeComponent();
			Client.token = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			/*
			 * 由于账户存款余额涉及用户的个人隐私
			 * 查询余额和存款前
			 * 客户必须输入账号的密码
			 * 未通过密码验证，则无法使用存款、查询余额功能
			 */
			Client.cardID = this.maskedTextBox1.Text;
			if (Client.token == false)
			{
				PasswordInput f9 = new PasswordInput();
				f9.StartPosition = FormStartPosition.CenterParent;
				f9.ShowDialog();
			}
			else
			{
				string depo_str = this.maskedTextBox2.Text;
				double depo = Convert.ToDouble(depo_str);
				if (Client.cardID == "")
				{
					MessageBox.Show("请填写账户号码");
					return;
				}
				if (depo <= 0)
				{
					MessageBox.Show("存款金额请输入大于0");
					return;
				}

				/*
				 * 数据类型转换
				 * 字符串转换为DateTime日期时间数据类型
				 * 与SQL数据库的DateTime数据类型匹配存储
				*/
				DateTime dt = System.DateTime.Now;
				string depoID = "DE" + dt.ToString();
				DateTimeFormatInfo dtformat = new System.Globalization.DateTimeFormatInfo();
				dtformat.ShortDatePattern = @"yyyy-MM-dd hh:mm:ss";
				dt = Convert.ToDateTime(dt, dtformat);
				string depo_inst = string.Format("INSERT INTO Deposit(depoID, cardID, dtime, dmoney) VALUES('{0}','{1}','{2}','{3}');", depoID, Client.cardID, dt, depo);
				string balance_query = string.Format("SELECT Card.Balance FROM Card WHERE cardID='{0}';",Client.cardID);
				string balance_update = string.Format("UPDATE Card SET Balance=Balance+{0} WHERE cardID='{1}';", depo, Client.cardID);
				using (SqlConnection conn = new SqlConnection(constr))
				{
					conn.Open();
					/* 使用SQL事务SqlTransaction
					 * 当处理存款、取款、转账等业务时
					 * 若数据库的修改没有完全执行，则回滚事务
					 * 以免出现日志异常
					 * 便于日志数据的追踪
					 */
					SqlTransaction sqlTran;
					SqlCommand cmd_select = new SqlCommand();
					cmd_select.CommandText = balance_query;
					cmd_select.Connection = conn;
					bal = cmd_select.ExecuteScalar().ToString();
					this.textBox1.Text = bal;
					using (SqlCommand cmd = conn.CreateCommand())
					{
						/* 使用SQL事务SqlTransaction
						 * 当处理存款、取款、转账等业务时
						* 若数据库的修改没有完全执行，则回滚事务
						* 以免出现日志异常
						* 便于日志数据的追踪
						*/
						sqlTran = conn.BeginTransaction();
						cmd.Connection = conn;
						cmd.Transaction = sqlTran;
						try
						{
							cmd.CommandText = depo_inst;
							cmd.ExecuteNonQuery();
							cmd.CommandText = balance_update;
							cmd.ExecuteNonQuery();
							sqlTran.Commit();
							MessageBox.Show("存款成功！\n点击“当前余额”即可查询账户余额", "存款", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						catch (Exception err)
						{
							sqlTran.Rollback();
							string err_str = string.Format("存款失败！\n点击“当前余额”即可查询账户余额\n\n错误：{0}", err.Message);
							MessageBox.Show(err_str, "存款", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							Console.WriteLine(err.Message);
						}
						bal = cmd_select.ExecuteScalar().ToString();
						balance = Convert.ToDouble(bal);
						this.textBox1.Text = bal;
					}
				}
			}
		}

		private void textBox1_Click(object sender, EventArgs e)
		{
			/*
			 * 当客户通过密码验证后
			 * 点击余额文本框，即可查询余额
			 */
			Client.cardID = this.maskedTextBox1.Text;
			if (Client.token == false)
			{
				PasswordInput f9 = new PasswordInput();
				f9.StartPosition = FormStartPosition.CenterParent;
				f9.ShowDialog();
			}
			else
			{
				using (SqlConnection conn = new SqlConnection(constr))
				{
					string balance_query = string.Format("SELECT Card.Balance FROM Card WHERE CardID='{0}';", Client.cardID);
					SqlCommand cmd_query = new SqlCommand();
					cmd_query.CommandText = balance_query;
					cmd_query.Connection = conn;
					try
					{
						conn.Open();
						string bal = cmd_query.ExecuteScalar().ToString();
						this.textBox1.Text = bal;
					}
					catch (Exception err)
					{
						Console.WriteLine(err.Message);
					}
				}
			}
		}

		/// <summary>
		/// 移出账户号码输入框后
		/// 弹出密码输入窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void maskedTextBox1_Leave(object sender, EventArgs e)
		{
			Client.cardID = this.maskedTextBox1.Text;
			if (Client.token == false)
			{
				PasswordInput f9 = new PasswordInput();
				f9.StartPosition = FormStartPosition.CenterParent;
				f9.ShowDialog();
			}
			else
			{
				string cardID = this.maskedTextBox1.Text;
				using (SqlConnection conn = new SqlConnection(constr))
				{
					string balance_query = string.Format("SELECT Card.Balance FROM Card WHERE CardID='{0}';", Client.cardID);
					SqlCommand cmd_query = new SqlCommand();
					cmd_query.CommandText = balance_query;
					cmd_query.Connection = conn;
					try
					{
						conn.Open();
						string bal = cmd_query.ExecuteScalar().ToString();
						this.textBox1.Text = bal;
					}
					catch (Exception err)
					{
						Console.WriteLine(err.Message);
					}
				}
			}
		}
	}
}
