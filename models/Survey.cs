using System;
using System.Collections.Generic;

namespace ReefSurvey
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public int StudyAreaId { get; set; }
        public string BatchId { get; set; }
        public string Index { get; set; }
        public DateTime Date { get; set; }
        public string Coordinates { get; set; }
        public int ManagementId { get; set; }
        public int StructureId { get; set; }
        public int SpeciesId { get; set; }
        public double Length { get; set; }
        public int Count { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual Management Management { get; set; }
        public virtual Species Species { get; set; }
        public virtual Structure Structure { get; set; }
        public virtual StudyArea StudyArea { get; set; }
    }
}
