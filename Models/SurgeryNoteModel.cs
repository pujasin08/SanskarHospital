using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class SurgeryNoteModel
    {
        public string date { get; set; }
        public string time { get; set; }
        public string doctor_id { get; set; }
        public string anaesthetist_name { get; set; }
        public string patient_id { get; set; }
        public string diagnosis_pre_op { get; set; }
        public string diagnosis_post_op { get; set; }
        public string indoor_no { get; set; }
        public string proce_dure { get; set; }
        public string steps { get; set; }
        public string pre_assessment_time { get; set; }
        public string pre_assessment_pulse { get; set; }
        public string pre_assessment_bp { get; set; }
        public string pre_assessment_spo2 { get; set; }
        public string pre_assessment_iv { get; set; }
        public string pre_assessment_output { get; set; }
        public string pre_assessment_bloodloss { get; set; }
        public string findings { get; set; }
        public string drains { get; set; }
        public string complication { get; set; }
        public string advice { get; set; }
        public string post_time { get; set; }
        public string post_temp { get; set; }
        public string post_pulse { get; set; }
        public string post_bp { get; set; }
        public string post_spo2 { get; set; }
    }
}