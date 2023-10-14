using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class ItemModel
    {
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string patient_id { get; set; }
        public string quantity { get; set; }
        public string checking { get; set; }
        public string id { get; set; }
    }
}