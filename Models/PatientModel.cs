using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class PatientModel
    {
        public string patient_id { get; set; }
        public string patient_uhid { get; set; }
        public string patient_name { get; set; }
        public string patient_address { get; set; }
        public string patient_mobile { get; set; }
        public string patient_sex { get; set; }
        public string patient_dob { get; set; }
        public string patient_identification_mark { get; set; }
        public string patient_marital_status { get; set; }
        public string patient_habit { get; set; }
        public string patient_blood_group { get; set; }
        public string is_active { get; set; }
        public string is_delete { get; set; }
    }

    public class PatientAdmission : PatientModel
    {
      //  public string patient_id { get; set; }
        public string arrival_time { get; set; }
        public string assesment_time { get; set; }
        public string room_no { get; set; }
        public string indoor_no { get; set; }
        public string date_of_addmission { get; set; }
        public string addmission_time { get; set; }
        public string discharge_date { get; set; }
        public string discharge_time { get; set; }
        public string history { get; set; }
        public string examination { get; set; }
        public string diagnosis { get; set; }   
        public string uhid { get; set; }   
        //public string patient_mobile { get; set; }
        //public string patient_sex { get; set; }
    }
    public class PatientInvestigation
    {
        public string doctor_id { get; set; }
        public string patient_id { get; set; }
        public string date { get; set; }
        public string hb { get; set; }
        public string tc { get; set; }
        public string dc { get; set; }
        public string esr { get; set; }
        public string pc { get; set; }
        public string smer { get; set; }
        public string urine { get; set; }
        public string stool { get; set; }
        public string rbs { get; set; }
        public string creatinine { get; set; }
        public string na { get; set; }
        public string k { get; set; }
        public string ca { get; set; }
        public string s_billi { get; set; }
        public string sgpt { get; set; }
        public string s_alk_po4_ase { get; set; }
        public string a_alk_po4_ase { get; set; }
        public string s_amylase { get; set; }
        public string s_lipase { get; set; }
        public string s_protein { get; set; }
        public string ecg { get; set; }
        public string cxr { get; set; }
        public string usg_sonography { get; set; }
        public string ct_mr { get; set; }
        public string others { get; set; }
    }
}