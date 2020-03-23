using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReefSurvey
{
	public class Parse
	{
		public static string[] Line(string line)
		{
			string[] result = new string[17];
			string[] words = line.Split(',');

			int i = 0;
			foreach (var word in words)
			{
				result[i] = word.Trim();
				i++;
			}

			return result;
		}
	}
}
