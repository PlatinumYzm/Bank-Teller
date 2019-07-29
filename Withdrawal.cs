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
using System.Globalization;

namespace Bank_Teller
{
	public partial class Withdrawal : Form
	{
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		public string cardID;
		public double balance;
		public string bal;
		public bool token = false;
		public Withdrawal()
		{
			InitializeComponent();
			Client.token = false;
		}

		private void textBox1_Click(object sender, EventArgs e)
		{
			/*
			 * 查询余额
			 * 客户需要通过密码验证后
			 * 才能获得查询余额和转账的权限
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
						bal = cmd_query.ExecuteScalar().ToString();
						this.textBox1.Text = bal;
					}
					catch (Exception err)
					{
						string err_str = string.Format("查询余额失败！\n\n错误：{0}", err.Message);
						MessageBox.Show(err_str, "取款", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Client.cardID = this.maskedTextBox1.Text;
			Client.userID = this.maskedTextBox2.Text;
			if (Client.token == false)
			{
				PasswordInput f9 = new PasswordInput();
				f9.StartPosition = FormStartPosition.CenterParent;
				f9.ShowDialog();
			}
			else
			{
				string with_str = this.maskedTextBox2.Text;
				double with = Convert.ToDouble(with_str);
				if (Client.cardID == "")
				{
					MessageBox.Show("请填写账户号码");
					return;
				}
				if (with <= 0)
				{
					MessageBox.Show("取款金额请输入大于0");
					return;
				}
				/*
				 * 数据类型转换
				 * 字符串转换为DateTime日期时间数据类型
				 * 与SQL数据库的DateTime数据类型匹配存储
				*/
				DateTime dt = System.DateTime.Now;
				string withID = "WT" + dt.ToString();
				DateTimeFormatInfo dtformat = new System.Globalization.DateTimeFormatInfo();
				dtformat.ShortDatePattern = @"yyyy-MM-dd hh:mm:ss";
				dt = Convert.ToDateTime(dt, dtformat);

				string balance_query = string.Format("SELECT Card.Balance FROM Card WHERE CardID='{0}';",Client.cardID);
				string with_inst = string.Format("INSERT INTO Withdrawal(withID, cardID, wtime, wmoney) VALUES('{0}','{1}','{2}','{3}');", withID, Client.cardID, dt, with);
				string balance_update = string.Format("UPDATE Card SET Balance=Balance-{0} WHERE cardID='{1}';", with, Client.cardID);
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
					SqlCommand cmd_query = new SqlCommand();
					cmd_query.CommandText = balance_query;
					cmd_query.Connection = conn;
					bal = cmd_query.ExecuteScalar().ToString();
					balance = Convert.ToDouble(bal);
					this.textBox1.Text = bal;
					if (balance < with)
					{
						string messtr = "取款失败！\n余额：" + balance + " 少于取款金额";
						MessageBox.Show(messtr, "取款", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						using (SqlCommand cmd = conn.CreateCommand())
						{
							sqlTran = conn.BeginTransaction();
							cmd.Connection = conn;
							cmd.Transaction = sqlTran;
							try
							{
								cmd.CommandText = with_inst;
								cmd.ExecuteNonQuery();
								cmd.CommandText = balance_update;
								cmd.ExecuteNonQuery();
								sqlTran.Commit();
								MessageBox.Show("取款成功！\n点击“当前余额”即可查询账户余额", "取款", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							catch (Exception err)
							{
								sqlTran.Rollback();
								string err_str = string.Format("取款失败！\n点击“当前余额”即可查询账户余额\n\n错误：{0}", err.Message);
								MessageBox.Show(err_str, "取款", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
							bal = cmd_query.ExecuteScalar().ToString();
							balance = Convert.ToDouble(bal);
							this.textBox1.Text = bal;
						}
					}
				}
			}
		}

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
						string err_str = string.Format("查询余额失败！\n\n错误：{0}", err.Message);
						MessageBox.Show(err_str, "取款", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
				
		}
	}
}
