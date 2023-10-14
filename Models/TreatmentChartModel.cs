using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class TreatmentChartModel
    {
        public string patient_id { get; set; }
        public string day { get; set; }
        public string doctor_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string sr_no { get; set; }
        public string drug_id { get; set; }
        public string dose { get; set; }
        public string dilution { get; set; }
        public string route { get; set; }
        public string frequency { get; set; }
        public string admit_time { get; set; }
        public string nurse_id { get; set; }
        public string doctor { get; set; }
        public string risk_type { get; set; }
        public string rbs_time { get; set; }
        public string rbs { get; set; }
        public string rbs_insulin { get; set; }
        public string rbs_nurse { get; set; }
        public string rbs_doctor { get; set; }
        public string discharge_plan { get; set; }
        public string investigation_plan { get; set; }
        public string diet_advice { get; set; }
        public string consultant_note { get; set; }
    }
}