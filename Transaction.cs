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
	public partial class Transaction : Form
	{
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		
		public double sbalance;
		public string bal;
		public bool token = false;
		public Transaction()
		{
			InitializeComponent();
			Client.token = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Client.cardID = this.maskedTextBox2.Text;
			if (Client.token == false)
			{
				PasswordInput f9 = new PasswordInput();
				f9.StartPosition = FormStartPosition.CenterParent;
				f9.ShowDialog();
			}
			else
			{
				if (Client.cardID == "")
				{
					MessageBox.Show("请填写付款账号");
					return;
				}
				string rcardID = this.maskedTextBox1.Text;
				if (Client.cardID == "")
				{
					MessageBox.Show("请填写收款账号");
					return;
				}
				string tran_str = this.textBox2.Text;
				double tran = Convert.ToDouble(tran_str.ToString());
				if (tran <= 0)
				{
					MessageBox.Show("汇款金额请输入大于0");
					return;
				}
				string rphone = this.maskedTextBox3.Text;
				string notifi = this.textBox3.Text;

				/*
				 * 数据类型转换
				 * 字符串转换为DateTime日期时间数据类型
				 * 与SQL数据库的DateTime数据类型匹配存储
				*/
				DateTime dt = System.DateTime.Now;
				string tranID = "TR" + dt.ToString();
				DateTimeFormatInfo dtformat = new System.Globalization.DateTimeFormatInfo();
				dtformat.ShortDatePattern = @"yyyy-MM-dd hh:mm:ss";
				dt = Convert.ToDateTime(dt, dtformat);

				string balance_query = string.Format("SELECT Card.Balance FROM Card WHERE CardID='{0}';", Client.cardID);
				string tran_inst = string.Format("INSERT INTO Trans(transID, scard, rcard, tmoney, ttime, rphone, notifi) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", tranID, Client.cardID, rcardID, tran, dt, rphone, notifi);
				string balance_update1 = string.Format("UPDATE Card SET Balance=Balance-{0} WHERE cardID='{1}';", tran, Client.cardID);
				string balance_update2 = string.Format("UPDATE Card SET Balance=Balance+{0} WHERE cardID='{1}';", tran, rcardID);

				using (SqlConnection conn = new SqlConnection(constr))
				{
					Client.cardID = this.maskedTextBox2.Text;
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
					sbalance = Convert.ToDouble(bal);
					this.textBox1.Text = bal;
					if (sbalance < tran)
					{
						string messtr = "转账失败！\n余额：" + sbalance + " 少于转账金额";
						MessageBox.Show(messtr, "转账", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
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
								cmd.CommandText = tran_inst;
								cmd.ExecuteNonQuery();
								cmd.CommandText = balance_update1;
								cmd.ExecuteNonQuery();
								cmd.CommandText = balance_update2;
								cmd.ExecuteNonQuery();
								sqlTran.Commit();
								MessageBox.Show("转账成功！\n点击“当前余额”即可查询账户余额", "转账", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							catch (Exception err)
							{
								sqlTran.Rollback();
								string err_str = string.Format("转账失败！\n点击“当前余额”即可查询账户余额\n\n错误：{0}", err.Message);
								MessageBox.Show(err_str, "转账", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
							bal = cmd_query.ExecuteScalar().ToString();
							sbalance = Convert.ToDouble(bal);
							this.textBox1.Text = bal;
						}
					}
				}
			}
		}

		private void maskedTextBox2_Leave(object sender, EventArgs e)
		{
			Client.cardID  = this.maskedTextBox2.Text;
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
						sbalance = Convert.ToDouble(bal);
						this.textBox1.Text = bal;
					}
					catch (Exception err)
					{
						string err_str = string.Format("查询余额失败！\n\n错误：{0}", err.Message);
						MessageBox.Show(err_str, "转账", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		private void textBox1_Click(object sender, EventArgs e)
		{
			Client.cardID = this.maskedTextBox2.Text;
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
						sbalance = Convert.ToDouble(bal);
						this.textBox1.Text = bal;
					}
					catch (Exception err)
					{
						string err_str = string.Format("查询余额失败！\n\n错误：{0}", err.Message);
						MessageBox.Show(err_str, "转账", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}
	}
}
