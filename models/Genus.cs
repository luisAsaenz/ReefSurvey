using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Genus
    {
        public Genus()
        {
            Species = new List<Species>();
        }

        public int GenusId { get; set; }
        public int FamilyId { get; set; }
        public string Name { get; set; }

        public virtual Family Family { get; set; }
        public virtual List<Species> Species { get; set; }
    }
}
