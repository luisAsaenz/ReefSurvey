using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Family
    {
        public Family()
        {
            Genera = new List<Genus>();
        }

        public int FamilyId { get; set; }
        public string Name { get; set; }

        public virtual List<Genus> Genera { get; set; }
    }
}
