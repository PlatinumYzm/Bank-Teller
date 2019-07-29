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

namespace Bank_Teller
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		public static string connectionString = "server=localhost;database=Bank;integrated security=SSPI";
		SqlConnection mySqlConnection = new SqlConnection(connectionString);

		private void button2_Click(object sender, EventArgs e)
		{
			Form3 f3 = new Form3();
			f3.StartPosition = FormStartPosition.CenterParent;
			f3.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string tellno = this.textBox1.Text;
			/*
			 * 密码字符串加密后
			 * 与数据库存储的密码匹配
			 * 匹配成功，说明输入密码正确
			 * 匹配失败，说明输入密码错误
			 */
			string pwd = this.textBox2.Text.Md5();
			string query = string.Format("SELECT Teller.PWD FROM Teller where TellID='{0}';", tellno);
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = query;
				cmd.Connection = conn;
				try
				{
					conn.Open();
					if(pwd.Equals(cmd.ExecuteScalar()))
					{
						if(MessageBox.Show("欢迎使用中国银行柜员系统", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
						{
							string query_user = string.Format("SELECT * FROM Teller where TellID='{0}';", tellno);
							SqlCommand cmd_user = new SqlCommand();
							cmd_user.CommandText = query_user;
							cmd_user.Connection = conn;
							SqlDataReader r = cmd_user.ExecuteReader();
							while (r.Read() == true)
							{
								Teller.Tellno = r[0].ToString();
								Teller.Name= r[2].ToString();
								Teller.Gender = r[3].ToString();
							}
							this.Close();
							return;
						}
					}
					else
					{
						MessageBox.Show("密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}
				catch (Exception err)
				{
					string err_str = string.Format("密码错误！\n\n错误：{0}", err.Message);
					MessageBox.Show(err_str, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}
	}
}
