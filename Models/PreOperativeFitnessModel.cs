using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class PreOperativeFitnessModel
    {
        public string date { get; set; }
        public string patient_id { get; set; }
        public string h_o_doe { get; set; }
        public string h_o_hbp { get; set; }
        public string h_o_mejor_medical { get; set; }
        public string h_o_blood_transfusion { get; set; }
        public string temp { get; set; }
        public string pulse { get; set; }
        public string bp { get; set; }
        public string r_s_bil { get; set; }
        public string no_rales { get; set; }
        public string s1s2 { get; set; }
        public string nogallop { get; set; }
        public string p_a_soft { get; set; }
        public string liver_spleen { get; set; }
        public string cns_conscious { get; set; }
        public string ecg { get; set; }
        public string pre_of { get; set; }
    }
}