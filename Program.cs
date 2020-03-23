using System;
using System.Collections.Generic;
using System.Linq;

namespace ReefSurvey
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var db = new ReefSurveyContext())
			{
				Reader.ReadAll();

				int i = 0;
				foreach (string line in Reader.AllLines)
				{
					string[] csv = Parse.Line(line);

					string region = csv[0];
					string subRegion = csv[1];
					string studyArea = csv[2];
					string surveyYear = csv[3];
					string batchCode = csv[4];
					string surveyIndex = csv[5];
					string surveyDate = csv[6];
					string latitude = csv[7];
					string longitude = csv[8];
					string management = csv[9];
					string structureType = csv[10];
					string family = csv[11];
					string scientificName = csv[12];
					string commonName = csv[13];
					string trophic = csv[14];
					string fishLength = csv[15];
					string fishCount = csv[16];

					// Is this an empty row?
					if (String.IsNullOrEmpty(region))
					{
						continue;
					}


					/*
					 * 1. REGION
					 * - CHECK IF IN DATABASE
					 *   - INSERT IF NOT
					 * - GET REGION ID
					 */

					try
					{
						// Check if in database.
						var exists = db.Regions.First(a => a.Name == region);
					}
					catch
					{
						// Not in database.
						var newItem = new Region();
						newItem.Name = region;
						Console.WriteLine($"- ADDING {newItem.Name}");
						db.Add(newItem);
						db.SaveChanges();
					}

					int regionId = db.Regions.First(a => a.Name == region).RegionId;

					/* 2. SUBREGION
					* - CHECK IF IN DATABASE
					*   - INSERT IF NOT
					* - SET REGION = REGION ID
					* - GET SUBREGION ID
					*/

					try
					{
						// Check if in database.
						var exists = db.SubRegions.First(a => a.Name == subRegion);
					}
					catch
					{
						// Not in database.
						var newItem = new SubRegion();
						newItem.RegionId = regionId;
						newItem.Name = subRegion;
						Console.WriteLine($"- ADDING {newItem.Name}");
						db.Add(newItem);
						db.SaveChanges();
					}

					int subRegionId = db.SubRegions.First(a => a.Name == subRegion).SubRegionId;

					/* 3. STUDY AREA
					* - CHECK IF IN DATABASE
					*   - INSERT IF NOT
					* - SET SUBREGION = SUBREGION ID
					*/

					try
					{
						// Check if in database.
						var exists = db.StudyAreas.First(a => a.Name == studyArea);
					}
					catch
					{
						// Not in database.
						var newItem = new StudyArea();
						newItem.SubRegionId = subRegionId;
						newItem.Name = studyArea;
						Console.WriteLine($"- ADDING {newItem.Name}");
						db.Add(newItem);
						db.SaveChanges();
					}

					int studyAreaId = db.StudyAreas.First(a => a.Name == studyArea).StudyAreaId;

					/* 4. SURVEY YEAR
					* - SKIP
					*/

					/* 5. BATCH CODE
					* - CHECK IF IN DATABASE
					*   - INSERT IF NOT
					* - SET BATCH = BATCH CODE
					*/

					try
					{
						// Check if in database.
						var exists = db.Batches.First(a => a.BatchId == batchCode);
					}
					catch
					{
						// Not in database.
						var newItem = new Batch();
						newItem.BatchId = batchCode;
						Console.WriteLine($"- ADDING {newItem.BatchId}");
						db.Add(newItem);
						db.SaveChanges();
					}

					string batchId = db.Batches.First(a => a.BatchId == batchCode).BatchId;

					/* 6. SURVEY INDEX
					* - SET SURVEY INDEX
					*/

					string index = surveyIndex;

					/* 7. SURVEY DATE
					* - SET SURVEY DATE
					*/

					string date = surveyDate;

					/* 8. LATITUDE, 9. LONGITUDE
					* - SET COORDINATES (LATITUDE, LONGITUDE)
					*/

					string coordinates = $"({latitude}, {longitude})";

					/* 10. MANAGEMENT
					* - CHECK IF IN DATABASE
					*   - INSERT IF NOT
					* - SET MANAGEMENT = MANAGEMENT ID
					*/

					try
					{
						// Check if in database.
						var exists = db.Managements.First(a => a.Name == management);
					}
					catch
					{
						// Not in database.
						var newItem = new Management();
						newItem.Name = management;
						Console.WriteLine($"- ADDING {newItem.Name}");
						db.Add(newItem);
						db.SaveChanges();
					}

					int managementId = db.Managements.First(a => a.Name == management).ManagementId;

					/* 11. STRUCTURE
					* - CHECK IF IN DATABASE
					*   - INSERT IF NOT
					* - SET STRUCTURE = STRUCTURE ID
					*/

					try
					{
						// Check if in database.
						var exists = db.Structures.First(a => a.Type == structureType);
					}
					catch
					{
						// Not in database.
						var newItem = new Structure();
						newItem.Type = (structureType != "NOT ENTERED") ? structureType : null;
						Console.WriteLine($"- ADDING {structureType}");
						db.Add(newItem);
						db.SaveChanges();
					}

					int structureId = db.Structures.First(a => a.Type == structureType).StructureId;

					/* 12. FAMILY
					* - CHECK IF IN DATABASE
					*   - INSERT IF NOT
					* - SET FAMILY = FAMILY ID
					*/

					try
					{
						// Check if in database.
						var exists = db.Families.First(a => a.Name == family);
					}
					catch
					{
						// Not in database.
						var newItem = new Family();
						newItem.Name = family;
						Console.WriteLine($"- ADDING {family}");
						db.Add(newItem);
						db.SaveChanges();
					}

					int familyId = db.Families.First(a => a.Name == family).FamilyId;

					/* 13. SPECIES
					* - SPLIT INTO GENUS/SPECIES
					* - CHECK IF GENUS EXISTS
					*   - INSERT IF NOT
					* - SET GENUS = GENUS ID
					* - CHECK IF SPECIES EXISTS
					*   - INSERT IF NOT
					* - SET SPECIES = SPECIES ID
					* - SET TROPHIC = TROPHIC
					*/

					string[] splitSpecies = scientificName.Split(' ');
					string genus = splitSpecies[0];
					string species = splitSpecies[1];

					try
					{
						// Check if in database.
						var exists = db.Genera.First(a => a.Name == genus);
					}
					catch
					{
						// Not in database.
						var newItem = new Genus();
						newItem.FamilyId = familyId;
						newItem.Name = genus;
						db.Add(newItem);
						db.SaveChanges();
					}

					int genusId = db.Genera.First(a => a.Name == genus).GenusId;

					try
					{
						// Check if in database.
						var exists = db.Species.First(a => a.LatinName == species);
					}
					catch
					{
						// Not in database.
						var newItem = new Species();
						newItem.GenusId = genusId;
						newItem.LatinName = species;
						newItem.CommonName = commonName;
						newItem.Trophic = trophic;
						db.Add(newItem);
						db.SaveChanges();
					}

					int speciesId = db.Species.First(a => a.LatinName == species).SpeciesId;

					// Finally, add the survey.
					var survey = new Survey();
					survey.StudyAreaId = studyAreaId;
					survey.BatchId = batchId;
					survey.Index = index;
					survey.Date = DateTime.Parse(date);
					survey.Coordinates = coordinates;
					survey.ManagementId = managementId;
					survey.StructureId = structureId;
					survey.SpeciesId = speciesId;
					survey.Length = double.Parse(fishLength);
					survey.Count = int.Parse(fishCount);
					db.Add(survey);
					db.SaveChanges();

					if (++i % 1000 == 0)
					{
						Console.WriteLine($"{i} entries have been written so far!");
					}
				}
			}
		}
	}
}