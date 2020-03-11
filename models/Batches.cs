using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Batches
    {
        public Batches()
        {
            Surveys = new HashSet<Surveys>();
        }

        public string BatchId { get; set; }

        public virtual ICollection<Surveys> Surveys { get; set; }
    }
}
