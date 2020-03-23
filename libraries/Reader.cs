using System;
using System.Collections.Generic;
using System.IO;

namespace ReefSurvey
{
	class Reader
	{
		public static List<string> AllLines= new List<string>();

		public static void ReadAll()
		{
			string[] files = new string[]
			{
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBS-0800-1100\Fish Dump.csv",
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBS-0900-0600\Fish dump.csv",
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBS-0900-0700\Fish Dump.csv",
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBS-0900-1000\Fish Dump.csv",
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBS-0900-1200\Fish Dump.csv",
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBT-0809-1100\Fish Dump.csv",
				@"C:\Users\natha\Desktop\Classwork\ReefSurvey\external\survey\1-data\FGBT-1000-1200\Fish Dump.csv"
			};
			int counter = 0;

			Dictionary<int, string> file1 = FilesToDict(files, 0, counter);
			FileReader(file1);

			Dictionary<int, string> file2 = FilesToDict(files, 1, counter);
			FileReader(file2);

			Dictionary<int, string> file3 = FilesToDict(files, 2, counter);
			FileReader(file3);

			Dictionary<int, string> file4 = FilesToDict(files, 3, counter);
			FileReader(file4);

			Dictionary<int, string> file5 = FilesToDict(files, 4, counter);
			FileReader(file5);

			Dictionary<int, string> file6 = FilesToDict(files, 5, counter);
			FileReader(file6);

			Dictionary<int, string> file7 = FilesToDict(files, 6, counter);
			FileReader(file7);
		}

		private static void FileReader(Dictionary<int, string> file)
		{
			for (int i = 1; i < file.Count; i++)
			{
				//Console.WriteLine(file[i]);
				AllLines.Add(file[i]);
			}
		}

		private static Dictionary<int, string> FilesToDict(string[] files, int i, int counter)
		{
			string line;
			Dictionary<int, string> lineData = new Dictionary<int, string>();

			StreamReader sr = new StreamReader(files[i]);
			while ((line = sr.ReadLine()) != null)
			{
				lineData.Add(counter, line);
				counter++;
			}
			return lineData;
		}
	}
}
