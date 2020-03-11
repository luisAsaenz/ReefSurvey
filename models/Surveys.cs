using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public partial class Surveys
    {
        public int SurveyId { get; set; }
        public int StudyAreaId { get; set; }
        public string BatchId { get; set; }
        public int Index { get; set; }
        public DateTime Date { get; set; }
        public string Coordinates { get; set; }
        public int ManagementId { get; set; }
        public int StructureId { get; set; }
        public int SpeciesId { get; set; }
        public double Length { get; set; }
        public int Count { get; set; }

        public virtual Batches Batch { get; set; }
        public virtual Managements Management { get; set; }
        public virtual Species Species { get; set; }
        public virtual Structures Structure { get; set; }
        public virtual StudyAreas StudyArea { get; set; }
    }
}
