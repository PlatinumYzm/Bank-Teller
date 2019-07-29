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
	public partial class LoanApply : Form
	{
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		public string userID;
		public string cardID;
		public int cycle_code;
		public int cycle;
		public int ins_code;
		public double ins;
		public string total_str;
		public double total;
		public LoanApply()
		{
			InitializeComponent();
			Client.token = false;
			this.comboBox1.SelectedIndex = this.comboBox1.Items.IndexOf("20年(240期)");
			this.comboBox2.SelectedIndex = this.comboBox2.Items.IndexOf("基准利率 4.90%");
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			double repay_t = calc_loan(sender, e);
			this.textBox2.Text = repay_t.ToString();
			double repay_m = calc_repay(sender, e);
			this.textBox3.Text = repay_m.ToString();
		}

		private void textBox2_Click(object sender, EventArgs e)
		{
			double repay_t = calc_loan(sender, e);
			this.textBox2.Text = repay_t.ToString();
			double repay_m = calc_repay(sender, e);
			this.textBox3.Text = repay_m.ToString();
		}

		private void textBox2_Enter(object sender, EventArgs e)
		{
			double repay_t = calc_loan(sender, e);
			this.textBox2.Text = repay_t.ToString();
			double repay_m = calc_repay(sender, e);
			this.textBox3.Text = repay_m.ToString();
		}

		private void textBox3_Click(object sender, EventArgs e)
		{
			double repay_t = calc_loan(sender, e);
			this.textBox2.Text = repay_t.ToString();
			double repay_m = calc_repay(sender, e);
			this.textBox3.Text = repay_m.ToString();
		}

		private void textBox3_Enter(object sender, EventArgs e)
		{
			double repay_t = calc_loan(sender, e);
			this.textBox2.Text = repay_t.ToString();
			double repay_m = calc_repay(sender, e);
			this.textBox3.Text = repay_m.ToString();
		}

		/// <summary>
		/// 计算月均还款
		/// [公式] 月均还款 = [贷款本金×月利率×（1+月利率）^还款月数]/[（1+月利率）^还款月数－1]
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns>月均还款金额</returns>
		private double calc_repay(object sender, EventArgs e)
		{
			cycle_code = this.comboBox1.SelectedIndex;
			switch (cycle_code)
			{
				case 0:
					cycle = 12;
					break;
				case 1:
					cycle = 60;
					break;
				case 2:
					cycle = 120;
					break;
				case 3:
					cycle = 240;
					break;
				case 4:
					cycle = 360;
					break;
			}
			ins_code = this.comboBox2.SelectedIndex;
			/* 
			 * 注意
			 * 公式所用的利率为月利率
			 * 需要将年利率/12f
			 */
			switch (ins_code)
			{
				case 0:
					ins = 0.0325/12f;
					break;
				case 1:
					ins = 0.0417/12f;
					break;
				case 2:
					ins = 0.049/12f;
					break;
				case 3:
					ins = 0.0539/12f;
					break;
			}
			total_str = this.textBox1.Text;
			total = Convert.ToDouble(total_str);
			double repay;
			/* 公式
			 * 每月还款 X= (Ab(1+b)^m ) / (1+b)^m-1
			 */
			repay = (total * ins * Math.Pow(1 + ins, cycle)) / (Math.Pow(1 + ins, cycle) - 1);
			return repay;
		}

		/// <summary>
		/// 计算本息还款总额
		/// [公式] 还款总额 = 贷款本金 + 月均还款*还款期数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns>还款总金额</returns>
		private double calc_loan(object sender, EventArgs e)
		{
			double repay_m=calc_repay(sender, e);
			total_str = this.textBox1.Text;
			total = Convert.ToDouble(total_str);
			cycle_code = this.comboBox1.SelectedIndex;
			switch (cycle_code)
			{
				case 0:
					cycle = 12;
					break;
				case 1:
					cycle = 60;
					break;
				case 2:
					cycle = 120;
					break;
				case 3:
					cycle = 240;
					break;
				case 4:
					cycle = 360;
					break;
			}
			double interest = cycle * repay_m;
			double repay_t = interest + total;
			return repay_t;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Client.userID = this.maskedTextBox1.Text;
			Client.cardID = this.maskedTextBox2.Text;
			if (total <= 0)
			{
				MessageBox.Show("贷款金额大于0", "贷款申请", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (Client.token == false)
			{
				PasswordInput f9 = new PasswordInput();
				f9.StartPosition = FormStartPosition.CenterParent;
				f9.ShowDialog();
			}
			else
			{
				string loan_inst = string.Format("INSERT INTO Loan(userID,cardID,cycle,interest,total) VALUES('{0}','{1}','{2}','{3}','{4}');", Client.userID, Client.cardID, cycle, ins, total);
				using (SqlConnection conn = new SqlConnection(constr))
				{
					conn.Open();
					SqlTransaction sqlTran;
					using (SqlCommand cmd = conn.CreateCommand())
					{
						sqlTran = conn.BeginTransaction();
						cmd.Connection = conn;
						cmd.Transaction = sqlTran;
						try
						{
							cmd.CommandText = loan_inst;
							cmd.ExecuteNonQuery();
							sqlTran.Commit();
							MessageBox.Show("贷款申请提交成功！\n请留意贷款审批状态", "贷款申请", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						catch (Exception err)
						{
							sqlTran.Rollback();
							string err_str = string.Format("贷款申请提交失败！\n\n错误：{0}", err.Message);
							MessageBox.Show(err_str, "贷款申请", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}


			
		}
	}
}
