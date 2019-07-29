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
using System.Reflection;
using System.Text.RegularExpressions;

namespace Bank_Teller
{
	public partial class Form11 : Form
	{
		public Form11()
		{
			InitializeComponent();
		}

		public static string connectionString = "server=localhost;database=Bank;integrated security=SSPI";
		
		private void button2_Click(object sender, EventArgs e)
		{
			string ID = this.maskedTextBox3.Text;
			if (ID == "")
			{
				MessageBox.Show("请填写证件号码");
				return;
			}
			string Name = this.maskedTextBox1.Text;
			if (Name == "")
			{
				MessageBox.Show("请填写姓名");
				return;
			}
			string Phone = this.maskedTextBox2.Text;
			if (Phone == "")
			{
				MessageBox.Show("请填写手机号码");
				return;
			}
			string Gender = "";
			if (this.radioButton1.Checked) Gender = "男";
			else if (this.radioButton2.Checked) Gender = "女";
			else
			{
				MessageBox.Show("请填写性别");
				return;
			}
			/*
			 * 短日期ShortDate
			 * 输入字符串"1998-04-13"
			 * 输出短日期1998-04-13
			 * 对应SQL的数据类型Date
			 */
			string birth = this.maskedTextBox4.Text;
			if (birth == "")
			{
				MessageBox.Show("请填写出生日期");
				return;
			}

			/*
			 * 数据类型转换
			 * 字符串转换为DateTime短日期数据类型
			 * 与SQL数据库的Date数据类型匹配存储
			 */
			DateTime dt;
			DateTimeFormatInfo dtformat = new DateTimeFormatInfo();
			dtformat.ShortDatePattern = @"yyyy-MM-dd";
			dt = Convert.ToDateTime(birth, dtformat);
			Console.WriteLine(dt.ToString("d", dtformat));

			string job = this.maskedTextBox5.Text;
			if (job == "")
			{
				MessageBox.Show("请填写职业");
				return;
			}
			string degree = this.maskedTextBox6.Text;
			if (degree == "")
			{
				MessageBox.Show("请填写学历");
				return;
			}
			string commit = string.Format("UPDATE Account SET Name='{0}',Phone='{1}', Gender='{2}', Birth='{3}', Job='{4}',Degree='{5}' where userID={6};", Name, Phone, Gender, dt, job, degree, ID);
			using (SqlConnection mySqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = commit;
				cmd.Connection = mySqlConnection;
				try
				{
					mySqlConnection.Open();
					int number = cmd.ExecuteNonQuery();
					if (number != 0)
					{
						if (MessageBox.Show("账户个人信息已更改", "更改信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
						{
							this.Close();
						}
					}
					else
					{
						MessageBox.Show("账户个人信息更改失败", "更改信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				catch (Exception err)
				{
					string err_str = string.Format("账户个人信息更改失败!\n\n错误：{0}", err.Message);
					MessageBox.Show("账户个人信息更改失败", "更改信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}
	
		private void button1_Click(object sender, EventArgs e)
		{
			string ID = this.maskedTextBox7.Text;
			if (ID == "")
			{
				MessageBox.Show("请填写证件号码");
				return;
			}
			string CardID = this.maskedTextBox8.Text;
			if (CardID == "")
			{
				MessageBox.Show("请填写账户号码");
				return;
			}

			if (this.maskedTextBox9.Text.Equals(this.maskedTextBox10.Text) != true)
			{
				this.label14.Text = "密码与确认密码不一致";
				this.label14.ForeColor = Color.Red;
				this.maskedTextBox10.BackColor = Color.LightCoral;
				this.maskedTextBox9.BackColor = Color.LightCoral;
				return;
			}

			string pwd = this.maskedTextBox9.Text;
			int check = PasswordSafe.PwdSafety(pwd, ID);
			if (check == -1)
			{
				MessageBox.Show("密码请输入6位数字", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (check == -2)
			{
				MessageBox.Show("请输入正确的身份证件号", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (check == 0)
			{
				MessageBox.Show("设置密码过简单！\n容易被破解！\n请勿使用出生日期、123456等简单密码！", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			
			string pwd_md5 = pwd.Md5();
			string query = string.Format("Select Card.Pwd FROM Card WHERE cardID='{0}' AND userID='{1}';", CardID, ID);
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd_query = new SqlCommand();
				cmd_query.CommandText = query;
				cmd_query.Connection = conn;
				try
				{
					conn.Open();
					string res = cmd_query.ExecuteScalar().ToString();
					if (res == "")
					{
						MessageBox.Show("提供的证件名下没有该账户\n请重新输入正确的证件号码和账户号码", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else if (pwd_md5.Equals(res))
					{
						MessageBox.Show("新密码不能与旧密码一致", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						string inst = string.Format("UPDATE Card SET Pwd='{0}' WHERE cardID='{1}' AND userID='{2}';", pwd_md5, CardID, ID);
						SqlCommand cmd_inst = new SqlCommand();
						cmd_inst.CommandText = inst;
						cmd_inst.Connection = conn;
						if ((int)cmd_inst.ExecuteNonQuery() != 0)
						{
							MessageBox.Show("密码更改成功！\n请牢记新密码，注意保密！", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
							Client.chance = 5;
						}
						else
						{
							MessageBox.Show("密码更改失败！", "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
				}
				catch (Exception err)
				{
					string err_str = string.Format("密码更改失败！\n\n错误：{0}", err.Message);
					MessageBox.Show(err_str, "更改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void maskedTextBox9_Click(object sender, EventArgs e)
		{
			this.maskedTextBox9.BackColor = Color.White;
			this.label14.Text = "";
		}

		private void maskedTextBox10_Click(object sender, EventArgs e)
		{
			this.maskedTextBox10.BackColor = Color.White;
			this.label14.Text = "";
		}

		private void maskedTextBox9_Enter(object sender, EventArgs e)
		{
			this.maskedTextBox9.BackColor = Color.White;
			this.label14.Text = "";
		}

		private void maskedTextBox10_Enter(object sender, EventArgs e)
		{
			this.maskedTextBox10.BackColor = Color.White;
			this.label14.Text = "";
		}
	}
}
