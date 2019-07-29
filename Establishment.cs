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
	public partial class Establishment : Form
	{
		public Establishment()
		{
			InitializeComponent();
			/*
			 * 标题“开户”的提示信息
			 * 鼠标移近标题“开户”
			 * 即可看到提示内容
			 */
			ToolTip toolTip1 = new ToolTip();
			toolTip1.InitialDelay = 1000;
			toolTip1.ReshowDelay = 500;
			toolTip1.ShowAlways = true;
			toolTip1.IsBalloon = true;
			toolTip1.ToolTipIcon = ToolTipIcon.Info;
			toolTip1.ToolTipTitle = "开户激活";
			toolTip1.SetToolTip(this.label1, "客户需要提供本人身份证件和待激活的银行卡；\n委托激活银行卡，需要提供委托人和被委托人的身份证件以及委托说明书；\n未成年客户办理业务，需要提供本人以及监护人的身份证件。");
		}
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		public string userID="";
		public string cardID="";
		public string pwd="";
		private string pwd_md5;
		public string name="";
		public string phone="";
		public string gender="";
		private void button1_Click(object sender, EventArgs e)
		{
			userID = this.maskedTextBox1.Text;
			cardID = this.maskedTextBox2.Text;
			pwd = this.maskedTextBox9.Text;
			name = this.textBox1.Text;
			phone = this.textBox2.Text;
			if (userID == "")
			{
				MessageBox.Show("请填写证件号码");
				return;
			}
			if (cardID == "")
			{
				MessageBox.Show("请填写账户号码");
				return;
			}
			
			if (this.maskedTextBox10.Text.Equals(pwd) != true)
			{
				this.label14.Text = "密码与确认密码不一致";
				this.label14.ForeColor = Color.Red;
				this.maskedTextBox10.BackColor = Color.LightCoral;
				this.maskedTextBox9.BackColor = Color.LightCoral;
				return;
			}
			if (name == "")
			{
				MessageBox.Show("请填写姓名");
				return;
			}
			if (this.radioButton1.Checked) gender = this.radioButton1.Text;
			else if (this.radioButton2.Checked) gender = this.radioButton2.Text;
			else gender = "";
			if (gender == "")
			{
				MessageBox.Show("请选择性别");
				return;
			}
			int check = PasswordSafe.PwdSafety(pwd, userID);
			if (check == -1)
			{
				MessageBox.Show("密码请输入6位数字", "开户", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (check == -2)
			{
				MessageBox.Show("请输入正确的身份证件号", "开户", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (check == 0)
			{
				MessageBox.Show("设置密码过简单！\n容易被破解！\n请勿使用出生日期、123456等简单密码！", "开户", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			pwd_md5 = pwd.Md5();
			string inst_Card = string.Format("INSERT INTO Card(cardID, userID, Pwd) VALUES('{0}','{1}','{2}');", cardID, userID, pwd_md5);
			string inst_Account = string.Format("INSERT INTO Account(userID, Name, Phone, Gender) VALUES('{0}','{1}','{2}','{3}');", userID, name,phone,gender);
			string SELECT_Account = string.Format("SELECT * FROM Account WHERE userID='{0}';", userID);
			using (SqlConnection conn=new SqlConnection(constr))
			{
				conn.Open();
				SqlTransaction sqlTran;
				using(SqlCommand cmd = conn.CreateCommand())
				{
					sqlTran = conn.BeginTransaction();
					cmd.Connection = conn;
					cmd.Transaction = sqlTran;
					try
					{
						cmd.CommandText = SELECT_Account;
						if ((int)cmd.ExecuteNonQuery() == -1)
						{
							cmd.CommandText = inst_Account;
							cmd.ExecuteNonQuery();
						}

						cmd.CommandText = inst_Card;
						cmd.ExecuteNonQuery();
						sqlTran.Commit();
						MessageBox.Show("开户激活成功！\n请注意密码的保密，安全用卡！", "开户", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(Exception err)
					{
						sqlTran.Rollback();
						string err_str = string.Format("开户激活失败！\n该账户已激活，请直接使用！\n\n错误：{0}", err.Message);
						MessageBox.Show(err_str, "开户", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						Console.Error.WriteLine("错误："+err.Message);
					}
				}
			}
		}
		private void maskedTextBox9_Click(object sender, EventArgs e)
		{
			this.maskedTextBox9.BackColor = Color.White;
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

		private void maskedTextBox10_Click(object sender, EventArgs e)
		{
			this.maskedTextBox10.BackColor = Color.White;
			this.label14.Text = "";
		}
	}
}
