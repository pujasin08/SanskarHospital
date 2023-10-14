using SanskarHospital.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanskarHospital.Models
{
    public class CommonBL
    {
        EncryptDecrypt enc = new EncryptDecrypt();
        DataLayer dl = new DataLayer();
        Property p = new Property();
        DataSet ds = new DataSet();
        public SelectList Patientlist()
        {
            p.OnTable = "FetchMasterTable";
            ds = dl.FetchMaster(p);
            List<SelectListItem> PatientList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                PatientList.Add(new SelectListItem { Text = ds.Tables[0].Rows[i]["patient_name"].ToString(), Value = ds.Tables[0].Rows[i]["patient_id"].ToString() });
            }
            SelectList patientlist = new SelectList(PatientList, "Value", "Text");
            return patientlist;
        }
        public SelectList Doctorlist()
        {
            p.OnTable = "FetchMasterTable";
            ds = dl.FetchMaster(p);
            List<SelectListItem> DoctorList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                DoctorList.Add(new SelectListItem { Text = ds.Tables[1].Rows[i]["doctor_name"].ToString(), Value = ds.Tables[1].Rows[i]["doctor_id"].ToString() });
            }
            SelectList doctorlist = new SelectList(DoctorList, "Value", "Text");
            return doctorlist;
        }

        public SelectList Nurselist()
        {
            p.OnTable = "FetchMasterTable";
            ds = dl.FetchMaster(p);
            List<SelectListItem> NurseList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                NurseList.Add(new SelectListItem { Text = ds.Tables[2].Rows[i]["nurse_name"].ToString(), Value = ds.Tables[2].Rows[i]["nurse_id"].ToString() });
            }
            SelectList nurselist = new SelectList(NurseList, "Value", "Text");
            return nurselist;
        }

        public SelectList Druglist()
        {
            p.OnTable = "FetchMasterTable";
            ds = dl.FetchMaster(p);
            List<SelectListItem> DrugList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                DrugList.Add(new SelectListItem { Text = ds.Tables[3].Rows[i]["drug_name"].ToString(), Value = ds.Tables[3].Rows[i]["drug_id"].ToString() });
            }
            SelectList druglist = new SelectList(DrugList, "Value", "Text");
            return druglist;
        }

        public SelectList Surgerylist()
        {
            p.OnTable = "FetchMasterTable";
            ds = dl.FetchMaster(p);
            List<SelectListItem> SurgeryList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
            {
                SurgeryList.Add(new SelectListItem { Text = ds.Tables[4].Rows[i]["surgery_name"].ToString(), Value = ds.Tables[4].Rows[i]["surgery_id"].ToString() });
            }
            SelectList surgerylist = new SelectList(SurgeryList, "Value", "Text");
            return surgerylist;
        }

        public SelectList Anaesthesialist()
        {
            p.OnTable = "FetchMasterTable";
            ds = dl.FetchMaster(p);
            List<SelectListItem> AnaesthesiaList = new List<SelectListItem>();
            for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
            {
                AnaesthesiaList.Add(new SelectListItem { Text = ds.Tables[5].Rows[i]["anaesthesia_name"].ToString(), Value = ds.Tables[5].Rows[i]["anaesthesia_id"].ToString() });
            }
            SelectList anaesthesialist = new SelectList(AnaesthesiaList, "Value", "Text");
            return anaesthesialist;
        }
    }
}