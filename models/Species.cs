using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Species
    {
        public Species()
        {
            Surveys = new HashSet<Surveys>();
        }

        public int SpeciesId { get; set; }
        public int GenusId { get; set; }
        public string LatinName { get; set; }
        public string CommonName { get; set; }
        public string Trophic { get; set; }

        public virtual Genera SpeciesNavigation { get; set; }
        public virtual ICollection<Surveys> Surveys { get; set; }
    }
}
