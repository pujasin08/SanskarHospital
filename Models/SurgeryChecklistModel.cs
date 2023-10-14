using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class SurgeryChecklistModel
    {
        public string patient_id { get; set; }
        public string surgery_id { get; set; }
        public string doctor_id { get; set; }
        public string anaesthesia_id { get; set; }
        public string surgery_consent { get; set; }
        public string anaesthesia_assessment { get; set; }
        public string pre_op_order { get; set; }
        public string nbm_order { get; set; }
        public string patient_shaving { get; set; }
        public string pre_op_fitness { get; set; }
        public string pre_op_investigation { get; set; }
        public string surgery_note { get; set; }
        public string post_op_order { get; set; }
        public string hpe { get; set; }
    }
}