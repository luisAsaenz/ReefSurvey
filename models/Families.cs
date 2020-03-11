using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Families
    {
        public int FamilyId { get; set; }
        public string Name { get; set; }

        public virtual Genera Genera { get; set; }
    }
}