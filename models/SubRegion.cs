using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class SubRegion
    {
        public SubRegion()
        {
            StudyAreas = new List<StudyArea>();
        }

        public int SubRegionId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }

        public virtual Region Region { get; set; }
        public virtual List<StudyArea> StudyAreas { get; set; }
    }
}
