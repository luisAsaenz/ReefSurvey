using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Managements
    {
        public Managements()
        {
            Surveys = new HashSet<Surveys>();
        }

        public int ManagementId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Surveys> Surveys { get; set; }
    }
}
