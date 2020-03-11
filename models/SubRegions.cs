using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class SubRegions
    {
        public int SubRegionId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }

        public virtual Regions SubRegion { get; set; }
        public virtual StudyAreas StudyAreas { get; set; }
    }
}
