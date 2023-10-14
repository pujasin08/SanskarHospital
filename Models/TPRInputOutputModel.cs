using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class TPRInputOutputModel
    {
        public string date { get; set; }
        public string room_no { get; set; }
        public string doctor_id { get; set; }
        public string patient_id { get; set; }
        public string shift_chart { get; set; }
        public string time { get; set; }
        public string temp { get; set; }
        public string pulse { get; set; }
        public string blood_pressure { get; set; }
        public string spo2 { get; set; }
        public string rbs { get; set; }
        public string input_oral { get; set; }
        public string input_iv { get; set; }
        public string output_urine { get; set; }
        public string output_aspiration { get; set; }
    }
}