using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class StudyAreas
    {
        public StudyAreas()
        {
            Surveys = new HashSet<Surveys>();
        }

        public int StudyAreaId { get; set; }
        public int SubRegionId { get; set; }
        public string Name { get; set; }

        public virtual SubRegions StudyArea { get; set; }
        public virtual ICollection<Surveys> Surveys { get; set; }
    }
}
