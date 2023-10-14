using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class NurseModel
    {
        public string nurse_id { get; set; }
        public string nurse_name { get; set; }
        public string nurse_mobile { get; set; }
        public string nurse_email { get; set; }
        public string nurse_sex { get; set; }
        public string nurse_address { get; set; }
        public string is_active { get; set; }
        public string is_delete { get; set; }

    }
}