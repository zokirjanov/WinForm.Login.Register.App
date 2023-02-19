using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Service.Common.Helpers
{
	public class Helper
	{
		public static string ArrayToString(byte[] arr)
		{
			StringBuilder res = new StringBuilder();
			for (int i = 0; i < arr.Length; i++)
			{
				res.Append($"{arr[i]:X2}");
			}
			return res.ToString().ToLower();
		}

		public static int ToSeed(string passw)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(passw);
			int result = BitConverter.ToInt32(SHA256.Create().ComputeHash(bytes), 0);
			return result;
		}
		public static string ImageToString(string path)
		{
			var img = File.ReadAllBytes(path);
			return Convert.ToBase64String(img);
		}
		public static void StringToImage(string str, string path)
		{
			var img = Convert.FromBase64String(str);
			File.WriteAllBytes(path, img);
		}
		public static bool Validate(Valid operand, string s)
		{
			switch ((int)operand)
			{
				case 1:
					return ValidUsername(s);
				case 2:
					return ValidText(s);
				default:
					return false;
			}
		}
		private static bool ValidUsername(string pasw)
		{
			return !(pasw.Contains(" ") || pasw.Length == 0 || pasw.Contains("	"));

		}

		private static bool ValidText(string text)
		{
			return text.Length > 0;
		}

	}
}

public enum Valid
{
	UserPasswordOrName = 1,
}
