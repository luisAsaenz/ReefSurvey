using System;
using System.Collections.Generic;

namespace ReefSurvey
{
	public class Program
	{
		static void Main(string[] args)
		{
			
			string line = "Gulf of Mexico,Flower Garden Banks,East Bank,2011,GULF-FGBS-0800-1100,6379,8/2/2011,27.91092,-93.60346,FGBNMS,HARD                                              ,Carangidae,Carangoides ruber,Bar Jack,P,45,1";
			
			Parse.Parsetest(line);
		}
	}
}
