using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Structure
    {
        public Structure()
        {
            Surveys = new List<Survey>();
        }

        public int StructureId { get; set; }
        public string Type { get; set; }

        public virtual List<Survey> Surveys { get; set; }
    }
}
