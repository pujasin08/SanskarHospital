using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanskarHospital.Models;

namespace SanskarHospital.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        DataLayer dl = new DataLayer();
        DataSet ds = new DataSet();
        Property p = new Property();
        CommonBL cb = new CommonBL();
        public ActionResult PatientAdmission()
        {
            p.OnTable = "FetchAdmission";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<PatientAdmission> admissionlist = new List<PatientAdmission>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            PatientAdmission pa = new PatientAdmission()
                            {
                                patient_id = item["patient_id"].ToString(),
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
                            };
                            admissionlist.Add(pa);
                        }
                        ViewBag.admissionlist = admissionlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }
        public ActionResult PatientAdmissionList()
        {
            p.OnTable = "FetchAdmission";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<PatientAdmission> admissionlist = new List<PatientAdmission>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            PatientAdmission pa = new PatientAdmission()
                            {
                                patient_id = item["patient_id"].ToString(),
                                patient_name = item["patient_name"].ToString(),
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
                            };
                            admissionlist.Add(pa);
                        }
                        ViewBag.admissionlist = admissionlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult PatientAdmission(PatientAdmission m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_patient_addmission(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Patient/PatientAdmission");
        }
        public ActionResult PatientInvestigation()
        {
            p.OnTable = "FetchInvestigation";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.DoctorList = cb.Doctorlist();
            List<PatientInvestigation> investigationlist = new List<PatientInvestigation>();
            if(ds != null)
            {
                try
                {
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        foreach(DataRow item in ds.Tables[0].Rows)
                        {
                            PatientInvestigation pi = new PatientInvestigation()
                            {
                                doctor_id = item["doctor_id"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                date = item["date"].ToString(),
                                hb = item["hb"].ToString(),
                                tc = item["tc"].ToString(),
                                dc = item["doctor_id"].ToString(),
                                esr = item["esr"].ToString(),
                                pc = item["pc"].ToString(),
                                smer = item["smer"].ToString(),
                                urine = item["urine"].ToString(),
                                stool = item["stool"].ToString(),
                                rbs = item["rbs"].ToString(),
                                creatinine = item["creatinine"].ToString(),
                                na = item["na"].ToString(),
                                k = item["k"].ToString(),
                                ca = item["ca"].ToString(),
                                s_billi = item["s_billi"].ToString(),
                                sgpt = item["sgpt"].ToString(),
                                s_alk_po4_ase = item["s_alk_po4_ase"].ToString(),
                                a_alk_po4_ase = item["a_alk_po4_ase"].ToString(),
                                s_amylase = item["s_amylase"].ToString(),
                                s_lipase = item["s_lipase"].ToString(),
                                s_protein = item["s_protein"].ToString(),
                                ecg = item["ecg"].ToString(),
                                cxr = item["cxr"].ToString(),
                                usg_sonography = item["usg_sonography"].ToString(),
                                ct_mr = item["ct_mr"].ToString(),
                                others = item["others"].ToString(),
                            };
                            investigationlist.Add(pi);
                        }
                        ViewBag.investigationlist = investigationlist;
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            return View();
        }
        public ActionResult PatientInvestigationList()
        {
            p.OnTable = "FetchInvestigation";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.DoctorList = cb.Doctorlist();
            List<PatientInvestigation> investigationlist = new List<PatientInvestigation>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            PatientInvestigation pi = new PatientInvestigation()
                            {
                                doctor_id = item["doctor_id"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                date = item["date"].ToString(),
                                hb = item["hb"].ToString(),
                                tc = item["tc"].ToString(),
                                dc = item["doctor_id"].ToString(),
                                esr = item["esr"].ToString(),
                                pc = item["pc"].ToString(),
                                smer = item["smer"].ToString(),
                                urine = item["urine"].ToString(),
                                stool = item["stool"].ToString(),
                                rbs = item["rbs"].ToString(),
                                creatinine = item["creatinine"].ToString(),
                                na = item["na"].ToString(),
                                k = item["k"].ToString(),
                                ca = item["ca"].ToString(),
                                s_billi = item["s_billi"].ToString(),
                                sgpt = item["sgpt"].ToString(),
                                s_alk_po4_ase = item["s_alk_po4_ase"].ToString(),
                                a_alk_po4_ase = item["a_alk_po4_ase"].ToString(),
                                s_amylase = item["s_amylase"].ToString(),
                                s_lipase = item["s_lipase"].ToString(),
                                s_protein = item["s_protein"].ToString(),
                                ecg = item["ecg"].ToString(),
                                cxr = item["cxr"].ToString(),
                                usg_sonography = item["usg_sonography"].ToString(),
                                ct_mr = item["ct_mr"].ToString(),
                                others = item["others"].ToString(),
                            };
                            investigationlist.Add(pi);
                        }
                        ViewBag.investigationlist = investigationlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult PatientInvestigation(PatientInvestigation m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_patient_investigation(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Patient/PatientInvestigation");
        }
    }
}