using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReefSurvey
{
    class Parse
    {
       public static void Parsetest()
       {
            string phrase = "The quick brown cow";
            string[] words = phrase.Split(' ');

            foreach (var word in words) ;
            {
                System.Console.WriteLine($"<{words}>");
            }

       }
            
            

    }
}
