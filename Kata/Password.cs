using System;
using System.Linq;

namespace Kata
{
	public static class Password
	{
		public static bool CheckPassword(int number)
		{
			var s = number.ToString();
			for (int i = 0; i < s.Length - 1; i += 1)
			{
				if (s[i] == s[i + 1])
				{
					var substring = s.Substring(i + 1);

					if (substring == string.Concat(substring.OrderBy(c => c)))
					{
						return true;
					}

				}

			}

			return false;
		}


		public static bool CheckPasswordAgain(int number)
		{
			var s = number.ToString();
			for (int i = 0; i < s.Length - 1; i += 1)
			{
				if (s[i] == s[i + 1])
				{
					var replace = number.ToString().Replace(new string(new char[] { s[i] }), "");
					if (HasADoubleDigit(replace) && replace.Count(x => x == replace[0]) != replace.Length)
					{
						Console.WriteLine(number);
						return true;
					}
					else
					{
						if (s.Count(x => x == s[i]) == 2)
						{
							Console.WriteLine(number);
							return true;
						}
					}
				}

			}

			return false;
		}

		public static bool HasOnlyIncreasingNumbers(int number)
		{
			var s = number.ToString();
			if (s == string.Concat(s.OrderBy(c => c)))
			{
				return true;
			}

			return false;
		}

		public static bool HasADoubleDigit(int number)
		{
			var s = number.ToString();
			for (int i = 0; i < s.Length - 1; i += 1)
			{
				if (s[i] == s[i + 1])
				{
					return true;
				}

			}

			return false;
		}

		public static bool HasADoubleDigit(string number)
		{
			var s = number.ToString();
			for (int i = 0; i < s.Length - 1; i += 1)
			{
				if (s[i] == s[i + 1])
				{
					return true;
				}

			}

			return false;
		}
	}
}