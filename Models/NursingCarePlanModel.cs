using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class NursingCarePlanModel
    {
        public string patient_id { get; set; }
        public string nursing_diagnosis { get; set; }
        public string date { get; set; }
        public string nursing_care_plan { get; set; }
        public string nursing_interventions { get; set; }
        public string outcomes { get; set; }
        public string duty_shift { get; set; }
        public string nurse_id { get; set; }
    }
}