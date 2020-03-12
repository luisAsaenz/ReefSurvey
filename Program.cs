using System;
using System.Linq;

namespace ReefSurvey
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var db = new ReefSurveyContext())
			{
				var region = new Region();
				region.Name = "London";
				db.Add(region);
				db.SaveChanges();

				var r = db.Regions.First(a => a.Name == "London");

				Console.WriteLine("HI!");
				Console.WriteLine(region.Name);
				;

				/*
				 * 1. REGION
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - GET REGION ID
				 * 
				 * 2. SUBREGION
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - SET REGION = REGION ID
				 * - GET SUBREGION ID
				 * 
				 * 3. STUDY AREA
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - SET SUBREGION = SUBREGION ID
				 * 
				 * 4. SURVEY YEAR
				 * - SKIP
				 * 
				 * 5. BATCH CODE
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - SET BATCH = BATCH CODE
				 * 
				 * 6. SURVEY INDEX
				 * - SET SURVEY INDEX
				 * 
				 * 7. SURVEY DATE
				 * - SET SURVEY DATE
				 * 
				 * 8. LATITUDE, 9. LONGITUDE
				 * - SET COORDINATES (LATITUDE, LONGITUDE)
				 * 
				 * 10. MANAGEMENT
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - SET MANAGEMENT = MANAGEMENT ID
				 * 
				 * 11. STRUCTURE
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - SET STRUCTURE = STRUCTURE ID
				 * 
				 * 12. FAMILY
				 * - CHECK IF IN DATABASE
				 *   - INSERT IF NOT
				 * - SET FAMILY = FAMILY ID
				 * 
				 * 13. SPECIES
				 * - SPLIT INTO GENUS/SPECIES
				 * - CHECK IF GENUS EXISTS
				 *   - INSERT IF NOT
				 * - SET GENUS = GENUS ID
				 * - CHECK IF SPECIES EXISTS
				 *   - INSERT IF NOT
				 * - SET SPECIES = SPECIES ID
				 * 
				 * 14. TROPHIC
				 * - SET TROPHIC = TROPHIC
				 * 
				 * 15. FISH LENGTH
				 * - SET FISH LENGTH = FISH LENGTH
				 * 
				 * 16. FISH COUNT
				 * - SET FISH COUNT = FISH COUNT
				 */
			}
		}
	}
}
