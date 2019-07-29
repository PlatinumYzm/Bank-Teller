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
	public partial class PasswordInput : Form
	{
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		public string cardID;
		public string userID;
		public string pwd;
		
		public PasswordInput()
		{
			InitializeComponent();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		public string str;
		private void button1_Click(object sender, EventArgs e)
		{
			if (Client.chance > 0)
			{
				using (SqlConnection conn = new SqlConnection(constr))
				{
					pwd = this.textBox1.Text;
					string pwd_md5 = pwd.Md5();
					string query = string.Format("SELECT Card.Pwd FROM Card WHERE cardID='{0}';", Client.cardID);
					SqlCommand cmd_query = new SqlCommand();
					cmd_query.CommandText = query;
					cmd_query.Connection = conn;
					try
					{
						conn.Open();
						string res = cmd_query.ExecuteScalar().ToString();
						if (pwd_md5.Equals(res))
						{
							Client.token = true;
							MessageBox.Show("密码正确", "输入密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
							this.Close();
							return;
						}
						else
						{
							str = string.Format("密码错误！\n请重新输入\n剩余输入次数：{0}", Client.chance);
							Client.chance = Client.chance - 1;
							MessageBox.Show(str, "输入密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
					}
					catch (Exception err)
					{
						string err_str = string.Format("账户查询失败！请重新输入账户号码！\n\n错误：{0}", err.Message);
						MessageBox.Show(err_str, "输入密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						Console.WriteLine(err.Message);
					}
				}
			}
			else
			{
				MessageBox.Show("密码错误超过5次！\n请重置密码！", "输入密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
