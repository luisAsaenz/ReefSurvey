﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReefSurvey
{
    class Parse
    {
        public static string[] Parsetest(string line)
        {
            string[] result = new string[17];
            string[] words = line.Split(',');

            int i = 0;
            foreach (var word in words)
            {
                word.TrimEnd();
                result[i] = word;
                i++;
            }

            foreach (var s in result)
            {
                s.TrimEnd();
                Console.Write($"{s},");
            }
            return result;

        }
    }
}
