using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class StudyArea
    {
        public StudyArea()
        {
            Surveys = new List<Survey>();
        }

        public int StudyAreaId { get; set; }
        public int SubRegionId { get; set; }
        public string Name { get; set; }

        public virtual SubRegion SubRegion { get; set; }
        public virtual List<Survey> Surveys { get; set; }
    }
}
