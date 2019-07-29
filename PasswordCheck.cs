using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Bank_Teller
{
	
	public static class PasswordCheck
	{
		/// <summary>
		/// 验证密码是否匹配正则表达式描述的规则
		/// </summary>
		/// <param name="text">匹配输入密码，判断密码的安全等级</param>
		/// <returns>密码是否匹配，匹配的等级</returns>
		public static int PwdCheck(this string text)
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
	}
}
