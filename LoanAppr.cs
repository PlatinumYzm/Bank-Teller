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
	public partial class Form10 : Form
	{
		public static string constr = "server=localhost;database=Bank;integrated security=SSPI";
		public Form10()
		{
			InitializeComponent();
		}

		DataTable table;
		SqlDataAdapter adapter;

		private void Form10_Load(object sender, EventArgs e)
		{
			/*
			 * 使用SqlDataAdapter对象模型
			 * 获取贷款申请表Loan
			 * 调用Update()方法更新贷款申请表Loan
			 */
			SqlConnection conn = new SqlConnection(constr);
			adapter = new SqlDataAdapter("SELECT * FROM Loan;", conn);
			SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
			adapter.InsertCommand = builder.GetInsertCommand();
			adapter.DeleteCommand = builder.GetDeleteCommand();
			adapter.UpdateCommand = builder.GetUpdateCommand();
			table = new DataTable();
			adapter.Fill(table);
			dataGridView1.DataSource = table;
			for (int i = 0; i <= 4; i++)
			{
				table.Columns[i].ReadOnly = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.EndEdit();
			try
			{
				adapter.Update(table);
				MessageBox.Show("审批提交成功！", "贷款审批", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception err)
			{
				string fail_str = string.Format("审批提交失败！\n{0}", err.Message);
				MessageBox.Show(fail_str, "贷款审批", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Form10_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			if (MessageBox.Show("退出贷款审批?\n退出前请注意业务数据的保存与提交", "贷款审批", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				e.Cancel = false;
			}
		}
	}
}
