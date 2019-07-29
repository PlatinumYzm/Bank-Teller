using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Teller
{
	/// <summary>
	/// Tellno:柜员账号
	/// Name:姓名
	/// Gender:性别
	/// </summary>
	public static class Teller
	{
		public static string Tellno;
		public static string Name;
		public static string Gender;
	}

	/// <summary>
	/// userID:客户的证件号码，18位身份证号
	/// cardID:客户的账户号码，19位银行账户
	/// token:密码验证状态，false表示未通过账户密码验证；true表示已通过账户密码验证
	/// chance:输入密码试错次数，初始值为5
	/// </summary>
	public static class Client
	{
		public static string userID;
		public static string cardID;
		public static bool token = false;
		public static int chance=5;
	}
}
