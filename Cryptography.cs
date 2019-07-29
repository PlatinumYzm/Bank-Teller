using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Bank_Teller
{
	/// <summary>
	/// MD5加密
	/// 将登录密码加密成一个由32个字符组成的哈希散列
	/// </summary>
	public static class Encryption
	{
		public static string Md5(this string text)
		{
			var buffer = Encoding.Default.GetBytes(text);
			var data = MD5.Create().ComputeHash(buffer);
			var stringbuilder = new StringBuilder();
			foreach (var t in data)
			{
				stringbuilder.Append(t.ToString("X2"));
			}
			return stringbuilder.ToString();
		}
	}
}
