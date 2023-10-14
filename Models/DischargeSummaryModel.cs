using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class DischargeSummaryModel
    {
        public string patient_id { get; set; }
        public string indoor_no { get; set; }
        public string room_no { get; set; }
        public string admision_date { get; set; }
        public string admision_time { get; set; }
        public string discharge_date { get; set; }
        public string discharge_time { get; set; }
        public string reference_doctor_1 { get; set; }
        public string reference_doctor_2 { get; set; }
        public string reference_doctor_3 { get; set; }
        public string admission_reason { get; set; }
        public string diagnosis { get; set; }
        public string followup_after_discharge { get; set; }
        public string condition_on_discharge { get; set; }
        public string treatment_on_discharge { get; set; }
        public string treatment_given { get; set; }
        public string brief_history { get; set; }
    }
}