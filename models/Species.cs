using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Species
    {
        public Species()
        {
            Surveys = new List<Survey>();
        }

        public int SpeciesId { get; set; }
        public int GenusId { get; set; }
        public string LatinName { get; set; }
        public string CommonName { get; set; }
        public string Trophic { get; set; }

        public virtual Genus Genus { get; set; }
        public virtual List<Survey> Surveys { get; set; }
    }
}
