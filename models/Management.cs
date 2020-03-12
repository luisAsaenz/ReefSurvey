using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Management
    {
        public Management()
        {
            Surveys = new HashSet<Survey>();
        }

        public int ManagementId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
