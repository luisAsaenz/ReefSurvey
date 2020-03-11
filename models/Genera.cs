using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Genera
    {
        public int GenusId { get; set; }
        public int FamilyId { get; set; }
        public string Name { get; set; }

        public virtual Families Genus { get; set; }
        public virtual Species Species { get; set; }
    }
}
