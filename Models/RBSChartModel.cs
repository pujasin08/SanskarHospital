using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class RBSChartModel
    {
       public string patient_id { get; set; }
       public string doctor_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string rbs { get; set; }
        public string insuline_given { get; set; }
        public string nurse_id { get; set; }
    }
}