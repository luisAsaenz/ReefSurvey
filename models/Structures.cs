using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Structures
    {
        public Structures()
        {
            Surveys = new HashSet<Surveys>();
        }

        public int StructureId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Surveys> Surveys { get; set; }
    }
}
