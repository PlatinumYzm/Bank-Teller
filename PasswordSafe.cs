using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Bank_Teller
{
	public static class PasswordSafe
	{
		/// <summary>
		/// 验证密码是否为高频弱密码
		/// 高频弱密码
		/// 123456
		/// 666666
		/// 888888
		/// 999999
		/// 出生年月日
		/// </summary>
		/// <param name="pwd">6位数银行卡密码</param>
		/// <param name="ID">客户证件号码，识别出生年月日</param>
		/// <returns>-2=不是正确的身份证号；-1=不是6位数密码；0=高频弱密码；1=安全可用的密码</returns>
		public static int PwdSafety(string pwd, string ID)
		{
			Regex pwd_reg = new Regex(@"^\d{6}$");
			if (pwd_reg.IsMatch(pwd) != true) return -1;
			string[] pwd_case = { "123456", "666666", "888888", "999999" };
			for (int i = 0; i < pwd_case.Length; i++)
			{
				if (pwd.Equals(pwd_case[i])) return 0;
			}
			Regex reg_ID = new Regex(@"^\d{17}(\d|X|x)");
			if (reg_ID.IsMatch(ID) != true) return -2;

			string birth = ID.Substring(8, 6);
			if (pwd.Equals(birth)) return 0;
			return 1;
		}
	}
}
