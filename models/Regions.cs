using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Regions
    {
        public int RegionId { get; set; }
        public string Name { get; set; }

        public virtual SubRegions SubRegions { get; set; }
    }
}
