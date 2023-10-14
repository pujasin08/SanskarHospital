using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class NursingAssessmentModel
    {
        public string patient_id { get; set; }
        public string date { get; set; }
        public string unit { get; set; }
        public string arrival_time { get; set; }
        public string assessment_time { get; set; }
        public string nurse_id { get; set; }
        public string admitted_form { get; set; }
        public string patient_arrived { get; set; }
        public string hight { get; set; }
        public string weight { get; set; }
        public string unable_weight { get; set; }
        public string estimatted_weight { get; set; }
        public string reason { get; set; }
        public string temp { get; set; }
        public string pulse { get; set; }
        public string respiration { get; set; }
        public string bp { get; set; }
        public string spo2 { get; set; }
        public string loc { get; set; }
        public string ho_allergy { get; set; }
        public string dentures { get; set; }
        public string spactacles { get; set; }
        public string id_belt { get; set; }
        public string id_colour { get; set; }
        public string vulnerable { get; set; }
        public string bedsore { get; set; }
        public string bedsore_details { get; set; }
    }
}