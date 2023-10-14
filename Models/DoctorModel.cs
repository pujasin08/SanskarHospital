using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class DoctorModel
    {
        public string doctor_id { get; set; }
        public string doctor_name { get; set; }
        public string doctor_mobile { get; set; }
        public string doctor_email { get; set; }
        public string doctor_sex { get; set; }
        public string doctor_specialization { get; set; }
        public string doctor_address { get; set; }
        public string doctor_degree { get; set; }
        public string is_active { get; set; }
        public string is_delete { get; set; }
    }
}