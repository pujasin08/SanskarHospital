using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class DoctorProgressNoteModel
    {
        public string patient_id { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public string patient_complain { get; set; }
        public string temp { get; set; }
        public string pulse { get; set; }
        public string bp { get; set; }
        public string spo2 { get; set; }
        public string time { get; set; }
        public string shift { get; set; }
    }
}