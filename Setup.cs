using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Bank_Teller
{
	
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 注册柜员账号
		/// 工号长度最多16位，由数字和字母组成
		/// 密码长度为8~16位，利用正则表达式规则判断密码的安全等级
		/// 弱密码：仅由数字组成
		/// 中密码：由数字和大小写字母组成
		/// 强密码：由数字、大小写字母和特殊字符~!@#$%^&*()_.组成
		/// 若输入的密码不满足密码规则，则弹出消息窗口显示相应错误
		/// 密码与确认密码不一致时，输入框的底色为红色，文本栏Label提示用户修改
		/// 输入弱密码时，输入框和Label的颜色为黄色；
		/// 输入中密码时，输入框和Label的颜色为橙色；
		/// 输入强密码时，输入框和Label的颜色为绿色；
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			if(this.textBox2.Text.Equals(this.textBox3.Text)==false)
			{
				this.label4.Text = "密码与确认密码不一致";
				this.label4.ForeColor = Color.Red;
				this.textBox2.BackColor = Color.LightCoral;
				this.textBox3.BackColor = Color.LightCoral;
				return;
			}
			int check = PwdCheck(this.textBox2.Text);
			if (check == 0)
			{
				if (this.textBox2.Text.Length < 8)
				{
					MessageBox.Show("密码长度不能小于8！", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				else if (this.textBox2.Text.Length > 16)
				{
					MessageBox.Show("密码长度不能大于16！", "Error");
				}
				else MessageBox.Show("未识别的字符！\n密码由8~16位数字、大小写字母或特殊字符!@#$%^&*组成", "Error");
			}
			else if(check ==1)
			{
				this.label4.Text = "弱密码";
				this.label4.ForeColor = Color.Black;
				this.label4.BackColor = Color.FromArgb(255, 224, 240, 135);
				this.textBox2.BackColor = Color.FromArgb(255, 224, 240, 135);
				this.textBox3.BackColor = Color.FromArgb(255, 224, 240, 135);
			}
			else if (check == 2)
			{
				this.label4.Text = "中密码";
				this.label4.ForeColor = Color.Black;
				this.label4.BackColor = Color.FromArgb(255, 255, 153, 0);
				this.textBox2.BackColor = Color.FromArgb(255, 255, 153, 0);
				this.textBox3.BackColor = Color.FromArgb(255, 255, 153, 0);
			}
			else if (check == 3)
			{
				this.label4.Text = "强密码";
				this.label4.ForeColor = Color.Black;
				this.label4.BackColor = Color.FromArgb(255, 51, 204, 0);
				this.textBox2.BackColor = Color.FromArgb(255, 51, 204, 0);
				this.textBox3.BackColor = Color.FromArgb(255, 51, 204, 0);
			}

			/*
			 * 将柜员的账号注册信息（工号、登录密码）保存到数据库
			 * 用于登录柜员系统
			 */

			 if(check!=0)
			{
				bool flag = true;
				string Tellno = this.textBox1.Text;
				if (Tellno == "")
				{
					MessageBox.Show("请填写工号");
					flag = false;
				}
				string temp = this.textBox2.Text;
				string pwd_MD5 = temp.Md5();
				string name = textBox4.Text;
				if (name == "")
				{
					MessageBox.Show("请填写姓名");
					flag = false;
				}
				string gender="";
				if (radioButton1.Checked) gender = "男";
				else if (radioButton2.Checked) gender = "女";
				else
				{
					MessageBox.Show("请填写性别");
					flag = false;
				}
				if (flag)
				{
					string connectionString = "server=localhost;database=Bank;integrated security=SSPI";
					string setup = string.Format("INSERT INTO Teller values('{0}','{1}','{2}','{3}');", Tellno, pwd_MD5, name, gender);
					using (SqlConnection conn = new SqlConnection(connectionString))
					{
						SqlCommand cmd = new SqlCommand();
						cmd.CommandText = setup;
						cmd.Connection = conn;
						try
						{
							conn.Open();
							int number = cmd.ExecuteNonQuery();
							if (number != 0)
							{
								if (MessageBox.Show("请使用工号和密码登录柜员系统", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
								{
									this.Close();
								}
							}
							else
								MessageBox.Show("注册失败");
						}
						catch (Exception err)
						{
							string err_str = string.Format("注册失败！\n\n错误：{0}", err.Message);
							MessageBox.Show(err_str,"注册失败",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						}
					}
				}
				
			}
			
		}

		/// <summary>
		/// 验证密码是否匹配正则表达式描述的规则
		/// </summary>
		/// <param name="text">匹配输入密码，判断密码的安全等级</param>
		/// <returns>密码是否匹配，匹配的等级</returns>
		private int PwdCheck(string text)
		{
			Regex reg_weak = new Regex(@"^(?=.*\d).{8,16}$");
			Regex reg_medium = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z]).{8,16}$");
			Regex reg_strong = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^]).{8,16}$");
			Match res = reg_strong.Match(text);
			if (reg_strong.IsMatch(text)) return 3;
			if (reg_medium.IsMatch(text)) return 2;
			if (reg_weak.IsMatch(text)) return 1;
			return 0;
			//if (res.Count > 0) return true;
			// false;
			throw new NotImplementedException();
		}

		private void textBox2_Click(object sender, EventArgs e)
		{
			this.textBox2.BackColor=Color.White;
		}

		private void textBox2_Enter(object sender, EventArgs e)
		{
			this.textBox2.BackColor = Color.White;
		}

		private void textBox3_Enter(object sender, EventArgs e)
		{
			this.textBox3.BackColor = Color.White;
		}

		private void textBox3_Click(object sender, EventArgs e)
		{
			this.textBox3.BackColor = Color.White;
		}
	}
}
