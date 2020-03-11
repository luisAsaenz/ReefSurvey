using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Region
    {
        public Region()
        {
            SubRegions = new List<SubRegion>();
        }

        public int RegionId { get; set; }
        public string Name { get; set; }

        public virtual List<SubRegion> SubRegions { get; set; }
    }
}
