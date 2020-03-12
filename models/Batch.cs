using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Batch
    {
        public Batch()
        {
            Surveys = new List<Survey>();
        }

        public string BatchId { get; set; }

        public virtual List<Survey> Surveys { get; set; }
    }
}
