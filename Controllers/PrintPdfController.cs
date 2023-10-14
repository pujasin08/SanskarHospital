using SanskarHospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanskarHospital.Controllers
{
    public class PrintPdfController : Controller
    {
        // GET: PrintPdf
        DataLayer dl = new DataLayer();
        DataSet ds = new DataSet();
        Property p = new Property();
        CommonBL cb = new CommonBL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatientHistory(string id)
        {
            p.OnTable = "FetchPatientAdmissionPrint";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            PatientAdmission pa = new PatientAdmission();
           // pa.patient_id = "bbbbbb";
            List<PatientAdmission> admissionlist = new List<PatientAdmission>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow item = ds.Tables[0].Rows[0];
                       
                             pa = new PatientAdmission()
                            {
                                patient_id = item["patient_id"].ToString(),
                                patient_name = item["patient_name"].ToString(),
                                patient_address = item["patient_address"].ToString(),
                                arrival_time = item["arrival_time"].ToString(),
                                assesment_time = item["assesment_time"].ToString(),
                                room_no = item["room_no"].ToString(),
                                indoor_no = item["indoor_no"].ToString(),
                                date_of_addmission = item["date_of_addmission"].ToString(),
                                addmission_time = item["addmission_time"].ToString(),
                                discharge_date = item["discharge_date"].ToString(),
                                discharge_time = item["discharge_time"].ToString(),
                                history = item["history"].ToString(),
                                examination = item["examination"].ToString(),
                                diagnosis = item["diagnosis"].ToString(),
                                patient_mobile = item["patient_mobile"].ToString(),
                                patient_sex = item["patient_sex"].ToString(),
                                uhid = item["patient_uhid"].ToString(),
                            };
                     
                       
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(pa);
        }
    }
}