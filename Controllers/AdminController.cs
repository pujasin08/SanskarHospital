using SanskarHospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanskarHospital.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataLayer dl = new DataLayer();
        DataSet ds = new DataSet();
        Property p = new Property();
        CommonBL cb = new CommonBL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Patient(string id)
        {
            p.OnTable = "FetchPatient";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            PatientModel Info = new PatientModel();
            List<PatientModel> patientlist = new List<PatientModel>();
            if(ds != null)
            {
                try
                {
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        foreach(DataRow item in ds.Tables[0].Rows)
                        {
                            PatientModel pm = new PatientModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                patient_uhid = item["patient_uhid"].ToString(),
                                patient_name = item["patient_name"].ToString(),
                                patient_address = item["patient_address"].ToString(),
                                patient_mobile = item["patient_mobile"].ToString(),
                                patient_sex = item["patient_sex"].ToString(),
                                patient_dob = item["patient_dob"].ToString(),
                                patient_identification_mark = item["patient_identification_mark"].ToString(),
                                patient_marital_status = item["patient_marital_status"].ToString(),
                                patient_habit = item["patient_habit"].ToString(),
                                patient_blood_group = item["patient_blood_group"].ToString(),
                                is_active = item["is_active"].ToString(),
                            };
                            patientlist.Add(pm);
                        }
                        ViewBag.patientlist = patientlist;
                    }
                    if(ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow i = ds.Tables[1].Rows[0];
                        Info = new PatientModel()
                        {
                            patient_id = i["patient_id"].ToString(),
                            patient_uhid = i["patient_uhid"].ToString(),
                            patient_name = i["patient_name"].ToString(),
                            patient_address = i["patient_address"].ToString(),
                            patient_mobile = i["patient_mobile"].ToString(),
                            patient_sex = i["patient_sex"].ToString(),
                            patient_dob = i["patient_dob"].ToString(),
                            patient_identification_mark = i["patient_identification_mark"].ToString(),
                            patient_marital_status = i["patient_marital_status"].ToString(),
                            patient_habit = i["patient_habit"].ToString(),
                            patient_blood_group = i["patient_blood_group"].ToString(),
                            is_active = i["is_active"].ToString(),
                        };
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }

        public ActionResult PatientList(string id)
        {
            p.OnTable = "FetchPatient";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            PatientModel Info = new PatientModel();
            List<PatientModel> patientlist = new List<PatientModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            PatientModel pm = new PatientModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                patient_uhid = item["patient_uhid"].ToString(),
                                patient_name = item["patient_name"].ToString(),
                                patient_address = item["patient_address"].ToString(),
                                patient_mobile = item["patient_mobile"].ToString(),
                                patient_sex = item["patient_sex"].ToString(),
                                patient_dob = item["patient_dob"].ToString(),
                                patient_identification_mark = item["patient_identification_mark"].ToString(),
                                patient_marital_status = item["patient_marital_status"].ToString(),
                                patient_habit = item["patient_habit"].ToString(),
                                patient_blood_group = item["patient_blood_group"].ToString(),
                                is_active = item["is_active"].ToString(),
                            };
                            patientlist.Add(pm);
                        }
                        ViewBag.patientlist = patientlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }

        [HttpPost]
        public ActionResult Patient(PatientModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_patient(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/Patient");
        }
        public JsonResult DeletePatient(string id)
        {
            Property p = new Property();
            string msg = "";
            try
            {
                dl.runQry("Update [HospitalERP].[patient_tbl] set is_delete = '1' where patient_id='" + id + "'");
                msg = "DataRemove";
            }
            catch (Exception)
            {

            }
            finally
            {

            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Doctor(string id)
        {
            p.OnTable = "FetchDoctor";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            DoctorModel Info = new DoctorModel();
            List<DoctorModel> doctorlist = new List<DoctorModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DoctorModel pm = new DoctorModel()
                            {
                                doctor_id = item["doctor_id"].ToString(),
                                doctor_name = item["doctor_name"].ToString(),
                                doctor_mobile = item["doctor_mobile"].ToString(),
                                doctor_email = item["doctor_email"].ToString(),
                                doctor_sex = item["doctor_sex"].ToString(),
                                doctor_specialization = item["doctor_specialization"].ToString(),
                                doctor_address = item["doctor_address"].ToString(),
                                doctor_degree = item["doctor_degree"].ToString(),
                                is_active = item["is_active"].ToString(),
                            };
                            doctorlist.Add(pm);
                        }
                        ViewBag.doctorlist = doctorlist;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow i = ds.Tables[1].Rows[0];
                        Info = new DoctorModel()
                        {
                            doctor_id = i["doctor_id"].ToString(),
                            doctor_name = i["doctor_name"].ToString(),
                            doctor_mobile = i["doctor_mobile"].ToString(),
                            doctor_email = i["doctor_email"].ToString(),
                            doctor_sex = i["doctor_sex"].ToString(),
                            doctor_specialization = i["doctor_specialization"].ToString(),
                            doctor_address = i["doctor_address"].ToString(),
                            doctor_degree = i["doctor_degree"].ToString(),
                            is_active = i["is_active"].ToString(),
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }
        public ActionResult DoctorList(string id)
        {
            p.OnTable = "FetchDoctor";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            DoctorModel Info = new DoctorModel();
            List<DoctorModel> doctorlist = new List<DoctorModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DoctorModel pm = new DoctorModel()
                            {
                                doctor_id = item["doctor_id"].ToString(),
                                doctor_name = item["doctor_name"].ToString(),
                                doctor_mobile = item["doctor_mobile"].ToString(),
                                doctor_email = item["doctor_email"].ToString(),
                                doctor_sex = item["doctor_sex"].ToString(),
                                doctor_specialization = item["doctor_specialization"].ToString(),
                                doctor_address = item["doctor_address"].ToString(),
                                doctor_degree = item["doctor_degree"].ToString(),
                                is_active = item["is_active"].ToString(),
                            };
                            doctorlist.Add(pm);
                        }
                        ViewBag.doctorlist = doctorlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }

        [HttpPost]
        public ActionResult Doctor(DoctorModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_doctor(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/Doctor");
        }
        public JsonResult DeleteDoctor(string id)
        {
            Property p = new Property();
            string msg = "";
            try
            {
                dl.runQry("Update [HospitalERP].[doctor_tbl] set is_delete = '1' where doctor_id='" + id + "'");
                msg = "DataRemove";
            }
            catch (Exception)
            {

            }
            finally
            {

            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nurse(string id)
        {
            p.OnTable = "FetchNurse";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            NurseModel Info = new NurseModel();
            List<NurseModel> nurselist = new List<NurseModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            NurseModel pm = new NurseModel()
                            {
                                nurse_id = item["nurse_id"].ToString(),
                                nurse_name = item["nurse_name"].ToString(),
                                nurse_mobile = item["nurse_mobile"].ToString(),
                                nurse_email = item["nurse_email"].ToString(),
                                nurse_sex = item["nurse_sex"].ToString(),
                                nurse_address = item["nurse_address"].ToString(),
                                is_active = item["is_active"].ToString(),
                            };
                            nurselist.Add(pm);
                        }
                        ViewBag.nurselist = nurselist;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow i = ds.Tables[1].Rows[0];
                        Info = new NurseModel()
                        {
                            nurse_id = i["nurse_id"].ToString(),
                            nurse_name = i["nurse_name"].ToString(),
                            nurse_mobile = i["nurse_mobile"].ToString(),
                            nurse_email = i["nurse_email"].ToString(),
                            nurse_sex = i["nurse_sex"].ToString(),
                            nurse_address = i["nurse_address"].ToString(),
                            is_active = i["is_active"].ToString(),
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }
        public ActionResult NurseList(string id)
        {
            p.OnTable = "FetchNurse";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            NurseModel Info = new NurseModel();
            List<NurseModel> nurselist = new List<NurseModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            NurseModel pm = new NurseModel()
                            {
                                nurse_id = item["nurse_id"].ToString(),
                                nurse_name = item["nurse_name"].ToString(),
                                nurse_mobile = item["nurse_mobile"].ToString(),
                                nurse_email = item["nurse_email"].ToString(),
                                nurse_sex = item["nurse_sex"].ToString(),
                                nurse_address = item["nurse_address"].ToString(),
                                is_active = item["is_active"].ToString(),
                            };
                            nurselist.Add(pm);
                        }
                        ViewBag.nurselist = nurselist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }

        [HttpPost]
        public ActionResult Nurse(NurseModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_nurse(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/Nurse");
        }
        public JsonResult DeleteNurse(string id)
        {
            Property p = new Property();
            string msg = "";
            try
            {
                dl.runQry("Update [HospitalERP].[nurse_tbl] set is_delete = '1' where nurse_id='" + id + "'");
                msg = "DataRemove";
            }
            catch (Exception)
            {

            }
            finally
            {

            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Drug(string id)
        {
            p.OnTable = "FetchDrug";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            DrugModel Info = new DrugModel();
            List<DrugModel> druglist = new List<DrugModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DrugModel pm = new DrugModel()
                            {
                                drug_id = item["drug_id"].ToString(),
                                drug_name = item["drug_name"].ToString(),
                            };
                            druglist.Add(pm);
                        }
                        ViewBag.druglist = druglist;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow i = ds.Tables[1].Rows[0];
                        Info = new DrugModel()
                        {
                            drug_id = i["drug_id"].ToString(),
                            drug_name = i["drug_name"].ToString(),
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }
        public ActionResult DrugList(string id)
        {
            p.OnTable = "FetchDrug";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            DrugModel Info = new DrugModel();
            List<DrugModel> druglist = new List<DrugModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DrugModel pm = new DrugModel()
                            {
                                drug_id = item["drug_id"].ToString(),
                                drug_name = item["drug_name"].ToString(),
                            };
                            druglist.Add(pm);
                        }
                        ViewBag.druglist = druglist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(Info);
        }

        [HttpPost]
        public ActionResult Drug(DrugModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_drug(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/Drug");
        }
        public JsonResult DeleteDrug(string id)
        {
            Property p = new Property();
            string msg = "";
            try
            {
                dl.runQry("delete from [HospitalERP].[drug_tbl] where drug_id='" + id + "'");
                msg = "DataRemove";
            }
            catch (Exception)
            {

            }
            finally
            {

            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TreatmentChart()
        {
            p.OnTable = "FetchTreatmentChart";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.NurseList = cb.Nurselist();
            ViewBag.DrugList = cb.Druglist();
            List<TreatmentChartModel> treatmentchartlist = new List<TreatmentChartModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            TreatmentChartModel pa = new TreatmentChartModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                day = item["day"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                date = item["date"].ToString(),
                                time = item["time"].ToString(),
                                sr_no = item["sr_no"].ToString(),
                                drug_id = item["drug_id"].ToString(),
                                dose = item["dose"].ToString(),
                                dilution = item["dilution"].ToString(),
                                route = item["route"].ToString(),
                                frequency = item["frequency"].ToString(),
                                admit_time = item["admit_time"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),
                                doctor = item["doctor"].ToString(),
                                risk_type = item["risk_type"].ToString(),
                                rbs_time = item["rbs_time"].ToString(),
                                rbs = item["rbs"].ToString(),
                                rbs_insulin = item["rbs_insulin"].ToString(),
                                rbs_nurse = item["rbs_nurse"].ToString(),
                                rbs_doctor = item["rbs_doctor"].ToString(),
                                discharge_plan = item["discharge_plan"].ToString(),
                                investigation_plan = item["investigation_plan"].ToString(),
                                diet_advice = item["diet_advice"].ToString(),
                                consultant_note = item["consultant_note"].ToString(),
                            };
                            treatmentchartlist.Add(pa);
                        }
                        ViewBag.treatmentchartlist = treatmentchartlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult TreatmentChartList()
        {
            p.OnTable = "FetchTreatmentChart";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.NurseList = cb.Nurselist();
            ViewBag.DrugList = cb.Druglist();
            List<TreatmentChartModel> treatmentchartlist = new List<TreatmentChartModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            TreatmentChartModel pa = new TreatmentChartModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                day = item["day"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                date = item["date"].ToString(),
                                time = item["time"].ToString(),
                                sr_no = item["sr_no"].ToString(),
                                drug_id = item["drug_id"].ToString(),
                                dose = item["dose"].ToString(),
                                dilution = item["dilution"].ToString(),
                                route = item["route"].ToString(),
                                frequency = item["frequency"].ToString(),
                                admit_time = item["admit_time"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),
                                doctor = item["doctor"].ToString(),
                                risk_type = item["risk_type"].ToString(),
                                rbs_time = item["rbs_time"].ToString(),
                                rbs = item["rbs"].ToString(),
                                rbs_insulin = item["rbs_insulin"].ToString(),
                                rbs_nurse = item["rbs_nurse"].ToString(),
                                rbs_doctor = item["rbs_doctor"].ToString(),
                                discharge_plan = item["discharge_plan"].ToString(),
                                investigation_plan = item["investigation_plan"].ToString(),
                                diet_advice = item["diet_advice"].ToString(),
                                consultant_note = item["consultant_note"].ToString(),
                            };
                            treatmentchartlist.Add(pa);
                        }
                        ViewBag.treatmentchartlist = treatmentchartlist;
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
        public ActionResult TreatmentChart(TreatmentChartModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_treatment_chart(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/TreatmentChart");
        }

        public ActionResult DoctorProgressNote()
        {
            p.OnTable = "Fetch_Doctor_Progress_Note";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<DoctorProgressNoteModel> doctorprogressnotelist = new List<DoctorProgressNoteModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DoctorProgressNoteModel pa = new DoctorProgressNoteModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                location = item["location"].ToString(),
                                date = item["date"].ToString(),
                                patient_complain = item["patient_complain"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                bp = item["bp"].ToString(),
                                spo2 = item["spo2"].ToString(),
                                time = item["time"].ToString(),
                                shift = item["shift"].ToString(),

                            };
                            doctorprogressnotelist.Add(pa);
                        }
                        ViewBag.doctorprogressnotelist = doctorprogressnotelist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult DoctorProgressNoteList()
        {
            p.OnTable = "Fetch_Doctor_Progress_Note";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<DoctorProgressNoteModel> doctorprogressnotelist = new List<DoctorProgressNoteModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DoctorProgressNoteModel pa = new DoctorProgressNoteModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                location = item["location"].ToString(),
                                date = item["date"].ToString(),
                                patient_complain = item["patient_complain"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                bp = item["bp"].ToString(),
                                spo2 = item["spo2"].ToString(),
                                time = item["time"].ToString(),
                                shift = item["shift"].ToString(),

                            };
                            doctorprogressnotelist.Add(pa);
                        }
                        ViewBag.doctorprogressnotelist = doctorprogressnotelist;
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
        public ActionResult DoctorProgressNote(DoctorProgressNoteModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_doctor_progress_note(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/DoctorProgressNote");
        }

        public ActionResult RBSChart()
        {
            p.OnTable = "Fetch_rbs_Chart";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.NurseList = cb.Nurselist();
            List<RBSChartModel> rbschartlist = new List<RBSChartModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            RBSChartModel pa = new RBSChartModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                date = item["date"].ToString(),
                                time = item["time"].ToString(),
                                rbs = item["rbs"].ToString(),
                                insuline_given = item["insuline_given"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),

                            };
                            rbschartlist.Add(pa);
                        }
                        ViewBag.rbschartlist = rbschartlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult RBSChartList()
        {
            p.OnTable = "Fetch_rbs_Chart";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.NurseList = cb.Nurselist();
            List<RBSChartModel> rbschartlist = new List<RBSChartModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            RBSChartModel pa = new RBSChartModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                date = item["date"].ToString(),
                                time = item["time"].ToString(),
                                rbs = item["rbs"].ToString(),
                                insuline_given = item["insuline_given"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),

                            };
                            rbschartlist.Add(pa);
                        }
                        ViewBag.rbschartlist = rbschartlist;
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
        public ActionResult RBSChart(RBSChartModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_rbs_chart(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/RBSChart");
        }
        public ActionResult NursingAssessment()
        {
            p.OnTable = "Fetch_Nursing_Assessment";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.NurseList = cb.Nurselist();
            List<NursingAssessmentModel> nursingassessmentlist = new List<NursingAssessmentModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            NursingAssessmentModel pa = new NursingAssessmentModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                date = item["date"].ToString(),
                                unit = item["unit"].ToString(),
                                arrival_time = item["arrival_time"].ToString(),
                                assessment_time = item["assessment_time"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),
                                admitted_form = item["admitted_form"].ToString(),
                                patient_arrived = item["patient_arrived"].ToString(),
                                hight = item["hight"].ToString(),
                                weight = item["weight"].ToString(),
                                unable_weight = item["unable_weight"].ToString(),
                                estimatted_weight = item["estimatted_weight"].ToString(),
                                reason = item["reason"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                respiration = item["respiration"].ToString(),
                                bp = item["bp"].ToString(),
                                spo2 = item["spo2"].ToString(),
                                loc = item["loc"].ToString(),
                                ho_allergy = item["ho_allergy"].ToString(),
                                dentures = item["dentures"].ToString(),
                                spactacles = item["spactacles"].ToString(),
                                id_belt = item["id_belt"].ToString(),
                                id_colour = item["id_colour"].ToString(),
                                vulnerable = item["vulnerable"].ToString(),
                                bedsore = item["bedsore"].ToString(),
                                bedsore_details = item["bedsore_details"].ToString(),

                            };
                            nursingassessmentlist.Add(pa);
                        }
                        ViewBag.nursingassessmentlist = nursingassessmentlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult NursingAssessmentList()
        {
            p.OnTable = "Fetch_Nursing_Assessment";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.NurseList = cb.Nurselist();
            List<NursingAssessmentModel> nursingassessmentlist = new List<NursingAssessmentModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            NursingAssessmentModel pa = new NursingAssessmentModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                date = item["date"].ToString(),
                                unit = item["unit"].ToString(),
                                arrival_time = item["arrival_time"].ToString(),
                                assessment_time = item["assessment_time"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),
                                admitted_form = item["admitted_form"].ToString(),
                                patient_arrived = item["patient_arrived"].ToString(),
                                hight = item["hight"].ToString(),
                                weight = item["weight"].ToString(),
                                unable_weight = item["unable_weight"].ToString(),
                                estimatted_weight = item["estimatted_weight"].ToString(),
                                reason = item["reason"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                respiration = item["respiration"].ToString(),
                                bp = item["bp"].ToString(),
                                spo2 = item["spo2"].ToString(),
                                loc = item["loc"].ToString(),
                                ho_allergy = item["ho_allergy"].ToString(),
                                dentures = item["dentures"].ToString(),
                                spactacles = item["spactacles"].ToString(),
                                id_belt = item["id_belt"].ToString(),
                                id_colour = item["id_colour"].ToString(),
                                vulnerable = item["vulnerable"].ToString(),
                                bedsore = item["bedsore"].ToString(),
                                bedsore_details = item["bedsore_details"].ToString(),

                            };
                            nursingassessmentlist.Add(pa);
                        }
                        ViewBag.nursingassessmentlist = nursingassessmentlist;
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
        public ActionResult NursingAssessment(NursingAssessmentModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_nursing_assessment(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/NursingAssessment");
        }

        public ActionResult NursingCarePlan()
        {
            p.OnTable = "FetchNursingCarePlan";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.NurseList = cb.Nurselist();
            List<NursingCarePlanModel> nursingcareplanlist = new List<NursingCarePlanModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            NursingCarePlanModel pa = new NursingCarePlanModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                nursing_diagnosis = item["nursing_diagnosis"].ToString(),
                                date = item["date"].ToString(),
                                nursing_care_plan = item["nursing_care_plan"].ToString(),
                                nursing_interventions = item["nursing_interventions"].ToString(),
                                outcomes = item["outcomes"].ToString(),
                                duty_shift = item["duty_shift"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),

                            };
                            nursingcareplanlist.Add(pa);
                        }
                        ViewBag.nursingcareplanlist = nursingcareplanlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult NursingCarePlanList()
        {
            p.OnTable = "FetchNursingCarePlan";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.NurseList = cb.Nurselist();
            List<NursingCarePlanModel> nursingcareplanlist = new List<NursingCarePlanModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            NursingCarePlanModel pa = new NursingCarePlanModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                nursing_diagnosis = item["nursing_diagnosis"].ToString(),
                                date = item["date"].ToString(),
                                nursing_care_plan = item["nursing_care_plan"].ToString(),
                                nursing_interventions = item["nursing_interventions"].ToString(),
                                outcomes = item["outcomes"].ToString(),
                                duty_shift = item["duty_shift"].ToString(),
                                nurse_id = item["nurse_id"].ToString(),

                            };
                            nursingcareplanlist.Add(pa);
                        }
                        ViewBag.nursingcareplanlist = nursingcareplanlist;
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
        public ActionResult NursingCarePlan(NursingCarePlanModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_nursing_care_paln(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/NursingCarePlan");
        }

        public ActionResult TPRInputOutput()
        {
            p.OnTable = "FetchTPRInputOutput";
            ds = dl.FetchMaster(p);
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.PatientList = cb.Patientlist();
            List<TPRInputOutputModel> tprlist = new List<TPRInputOutputModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            TPRInputOutputModel pa = new TPRInputOutputModel()
                            {
                                date = item["date"].ToString(),
                                room_no = item["room_no"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                shift_chart = item["shift_chart"].ToString(),
                                time = item["time"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                blood_pressure = item["blood_pressure"].ToString(),
                                spo2 = item["spo2"].ToString(),
                                rbs = item["rbs"].ToString(),
                                input_oral = item["input_oral"].ToString(),
                                input_iv = item["input_iv"].ToString(),
                                output_urine = item["output_urine"].ToString(),
                                output_aspiration = item["output_aspiration"].ToString(),

                            };
                            tprlist.Add(pa);
                        }
                        ViewBag.tprlist = tprlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult TPRInputOutputList()
        {
            p.OnTable = "FetchTPRInputOutput";
            ds = dl.FetchMaster(p);
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.PatientList = cb.Patientlist();
            List<TPRInputOutputModel> tprlist = new List<TPRInputOutputModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            TPRInputOutputModel pa = new TPRInputOutputModel()
                            {
                                date = item["date"].ToString(),
                                room_no = item["room_no"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                shift_chart = item["shift_chart"].ToString(),
                                time = item["time"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                blood_pressure = item["blood_pressure"].ToString(),
                                spo2 = item["spo2"].ToString(),
                                rbs = item["rbs"].ToString(),
                                input_oral = item["input_oral"].ToString(),
                                input_iv = item["input_iv"].ToString(),
                                output_urine = item["output_urine"].ToString(),
                                output_aspiration = item["output_aspiration"].ToString(),

                            };
                            tprlist.Add(pa);
                        }
                        ViewBag.tprlist = tprlist;
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
        public ActionResult TPRInputOutput(TPRInputOutputModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_tpr_input_output(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/TPRInputOutput");
        }

        public ActionResult MRDChecklist()
        {
            p.OnTable = "FetchMRDChecklist";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<MRDChecklistModel> mrdlist = new List<MRDChecklistModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            MRDChecklistModel pa = new MRDChecklistModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                ipd_number = item["ipd_number"].ToString(),
                                discharge_summary = item["discharge_summary"].ToString(),
                                casesheet = item["casesheet"].ToString(),
                                dr_continuation_sheet = item["dr_continuation_sheet"].ToString(),
                                consent_from_for_procedures = item["consent_from_for_procedures"].ToString(),
                                pre_operative_checklist = item["pre_operative_checklist"].ToString(),
                                pre_operative_surgeon = item["pre_operative_surgeon"].ToString(),
                                pre_anaesthesia_evalution = item["pre_anaesthesia_evalution"].ToString(),
                                anaesthesia_formulation_care_plan = item["anaesthesia_formulation_care_plan"].ToString(),
                                intra_anaesthesia_record = item["intra_anaesthesia_record"].ToString(),
                                post_anaesthesia_record = item["post_anaesthesia_record"].ToString(),
                                post_operative_surgeon = item["post_operative_surgeon"].ToString(),
                                tpr_chart = item["tpr_chart"].ToString(),
                                intake_output_chart = item["intake_output_chart"].ToString(),
                                drug_chart = item["drug_chart"].ToString(),
                                nurse_note = item["nurse_note"].ToString(),
                                investigation_report = item["investigation_report"].ToString(),
                                general_consent = item["general_consent"].ToString(),

                            };
                            mrdlist.Add(pa);
                        }
                        ViewBag.mrdlist = mrdlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult MRDChecklistList()
        {
            p.OnTable = "FetchMRDChecklist";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<MRDChecklistModel> mrdlist = new List<MRDChecklistModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            MRDChecklistModel pa = new MRDChecklistModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                ipd_number = item["ipd_number"].ToString(),
                                discharge_summary = item["discharge_summary"].ToString(),
                                casesheet = item["casesheet"].ToString(),
                                dr_continuation_sheet = item["dr_continuation_sheet"].ToString(),
                                consent_from_for_procedures = item["consent_from_for_procedures"].ToString(),
                                pre_operative_checklist = item["pre_operative_checklist"].ToString(),
                                pre_operative_surgeon = item["pre_operative_surgeon"].ToString(),
                                pre_anaesthesia_evalution = item["pre_anaesthesia_evalution"].ToString(),
                                anaesthesia_formulation_care_plan = item["anaesthesia_formulation_care_plan"].ToString(),
                                intra_anaesthesia_record = item["intra_anaesthesia_record"].ToString(),
                                post_anaesthesia_record = item["post_anaesthesia_record"].ToString(),
                                post_operative_surgeon = item["post_operative_surgeon"].ToString(),
                                tpr_chart = item["tpr_chart"].ToString(),
                                intake_output_chart = item["intake_output_chart"].ToString(),
                                drug_chart = item["drug_chart"].ToString(),
                                nurse_note = item["nurse_note"].ToString(),
                                investigation_report = item["investigation_report"].ToString(),
                                general_consent = item["general_consent"].ToString(),

                            };
                            mrdlist.Add(pa);
                        }
                        ViewBag.mrdlist = mrdlist;
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
        public ActionResult MRDChecklist(MRDChecklistModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_mrd_checklist(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/MRDChecklist");
        }

        public ActionResult SurgeryNote()
        {
            p.OnTable = "FetchSurgeryNote";
            ds = dl.FetchMaster(p);
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.PatientList = cb.Patientlist();
            List<SurgeryNoteModel> surgerynotelist = new List<SurgeryNoteModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            SurgeryNoteModel pa = new SurgeryNoteModel()
                            {
                                date = item["date"].ToString(),
                                time = item["time"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                anaesthetist_name = item["anaesthetist_name"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                diagnosis_pre_op = item["diagnosis_pre_op"].ToString(),
                                diagnosis_post_op = item["diagnosis_post_op"].ToString(),
                                indoor_no = item["indoor_no"].ToString(),
                                proce_dure = item["proce_dure"].ToString(),
                                steps = item["steps"].ToString(),
                                pre_assessment_time = item["pre_assessment_time"].ToString(),
                                pre_assessment_pulse = item["pre_assessment_pulse"].ToString(),
                                pre_assessment_bp = item["pre_assessment_bp"].ToString(),
                                pre_assessment_spo2 = item["pre_assessment_spo2"].ToString(),
                                pre_assessment_iv = item["pre_assessment_iv"].ToString(),
                                pre_assessment_output = item["pre_assessment_output"].ToString(),
                                pre_assessment_bloodloss = item["pre_assessment_bloodloss"].ToString(),
                                findings = item["findings"].ToString(),
                                drains = item["drains"].ToString(),
                                complication = item["complication"].ToString(),
                                advice = item["advice"].ToString(),
                                post_time = item["post_time"].ToString(),
                                post_temp = item["post_temp"].ToString(),
                                post_pulse = item["post_pulse"].ToString(),
                                post_bp = item["post_bp"].ToString(),
                                post_spo2 = item["post_spo2"].ToString(),

                            };
                            surgerynotelist.Add(pa);
                        }
                        ViewBag.surgerynotelist = surgerynotelist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult SurgeryNoteList()
        {
            p.OnTable = "FetchSurgeryNote";
            ds = dl.FetchMaster(p);
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.PatientList = cb.Patientlist();
            List<SurgeryNoteModel> surgerynotelist = new List<SurgeryNoteModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            SurgeryNoteModel pa = new SurgeryNoteModel()
                            {
                                date = item["date"].ToString(),
                                time = item["time"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                anaesthetist_name = item["anaesthetist_name"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                diagnosis_pre_op = item["diagnosis_pre_op"].ToString(),
                                diagnosis_post_op = item["diagnosis_post_op"].ToString(),
                                indoor_no = item["indoor_no"].ToString(),
                                proce_dure = item["proce_dure"].ToString(),
                                steps = item["steps"].ToString(),
                                pre_assessment_time = item["pre_assessment_time"].ToString(),
                                pre_assessment_pulse = item["pre_assessment_pulse"].ToString(),
                                pre_assessment_bp = item["pre_assessment_bp"].ToString(),
                                pre_assessment_spo2 = item["pre_assessment_spo2"].ToString(),
                                pre_assessment_iv = item["pre_assessment_iv"].ToString(),
                                pre_assessment_output = item["pre_assessment_output"].ToString(),
                                pre_assessment_bloodloss = item["pre_assessment_bloodloss"].ToString(),
                                findings = item["findings"].ToString(),
                                drains = item["drains"].ToString(),
                                complication = item["complication"].ToString(),
                                advice = item["advice"].ToString(),
                                post_time = item["post_time"].ToString(),
                                post_temp = item["post_temp"].ToString(),
                                post_pulse = item["post_pulse"].ToString(),
                                post_bp = item["post_bp"].ToString(),
                                post_spo2 = item["post_spo2"].ToString(),

                            };
                            surgerynotelist.Add(pa);
                        }
                        ViewBag.surgerynotelist = surgerynotelist;
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
        public ActionResult SurgeryNote(SurgeryNoteModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_surgery_note(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/SurgeryNote");
        }

        public ActionResult SurgeryNameMaster(string id)
        {
            p.OnTable = "FetchSurgeryNameMaster";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            SurgeryNameMasterModel info = new SurgeryNameMasterModel();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow item = ds.Tables[1].Rows[0];
                        info = new SurgeryNameMasterModel()
                        {
                            surgery_id = item["surgery_id"].ToString(),
                            surgery_name = item["surgery_name"].ToString(),
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(info);
        }

        public ActionResult SurgeryNameMasterList()
        {
            p.OnTable = "FetchSurgeryNameMaster";
            ds = dl.FetchMaster(p);
            List<SurgeryNameMasterModel> surgerynamelist = new List<SurgeryNameMasterModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            SurgeryNameMasterModel pa = new SurgeryNameMasterModel()
                            {
                                surgery_id = item["surgery_id"].ToString(),
                                surgery_name = item["surgery_name"].ToString(),

                            };
                            surgerynamelist.Add(pa);
                        }
                        ViewBag.surgerynamelist = surgerynamelist;
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
        public ActionResult SurgeryNameMaster(SurgeryNameMasterModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_surgery_name_master(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/SurgeryNameMaster");
        }

        public ActionResult AnaesthesiaMaster(string id)
        {
            p.OnTable = "FetchAnaesthesiaMaster";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            AnaesthesiaMasterModel info = new AnaesthesiaMasterModel();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow item = ds.Tables[1].Rows[0];
                        info = new AnaesthesiaMasterModel()
                        {
                            anaesthesia_id = item["anaesthesia_id"].ToString(),
                            anaesthesia_name = item["anaesthesia_name"].ToString(),
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(info);
        }

        public ActionResult AnaesthesiaMasterList()
        {
            p.OnTable = "FetchAnaesthesiaMaster";
            ds = dl.FetchMaster(p);
            List<AnaesthesiaMasterModel> anaesthesialist = new List<AnaesthesiaMasterModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            AnaesthesiaMasterModel pa = new AnaesthesiaMasterModel()
                            {
                                anaesthesia_id = item["anaesthesia_id"].ToString(),
                                anaesthesia_name = item["anaesthesia_name"].ToString(),

                            };
                            anaesthesialist.Add(pa);
                        }
                        ViewBag.anaesthesialist = anaesthesialist;
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
        public ActionResult AnaesthesiaMaster(AnaesthesiaMasterModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_anaesthesia_master(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/AnaesthesiaMaster");
        }

        public ActionResult SurgeryChecklist()
        {
            p.OnTable = "FetchSurgeryChecklist";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.SurgeryList = cb.Surgerylist();
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.AnaesthesiaList = cb.Anaesthesialist();
            List<SurgeryChecklistModel> surgerychecklist = new List<SurgeryChecklistModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            SurgeryChecklistModel pa = new SurgeryChecklistModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                surgery_id = item["surgery_id"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                anaesthesia_id = item["anaesthesia_id"].ToString(),
                                surgery_consent = item["surgery_consent"].ToString(),
                                anaesthesia_assessment = item["anaesthesia_assessment"].ToString(),
                                pre_op_order = item["pre_op_order"].ToString(),
                                nbm_order = item["nbm_order"].ToString(),
                                patient_shaving = item["patient_shaving"].ToString(),
                                pre_op_fitness = item["pre_op_fitness"].ToString(),
                                pre_op_investigation = item["pre_op_investigation"].ToString(),
                                surgery_note = item["surgery_note"].ToString(),
                                post_op_order = item["post_op_order"].ToString(),
                                hpe = item["hpe"].ToString(),

                            };
                            surgerychecklist.Add(pa);
                        }
                        ViewBag.surgerychecklist = surgerychecklist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult SurgeryChecklistList()
        {
            p.OnTable = "FetchSurgeryChecklist";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            ViewBag.SurgeryList = cb.Surgerylist();
            ViewBag.DoctorList = cb.Doctorlist();
            ViewBag.AnaesthesiaList = cb.Anaesthesialist();
            List<SurgeryChecklistModel> surgerychecklist = new List<SurgeryChecklistModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            SurgeryChecklistModel pa = new SurgeryChecklistModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                surgery_id = item["surgery_id"].ToString(),
                                doctor_id = item["doctor_id"].ToString(),
                                anaesthesia_id = item["anaesthesia_id"].ToString(),
                                surgery_consent = item["surgery_consent"].ToString(),
                                anaesthesia_assessment = item["anaesthesia_assessment"].ToString(),
                                pre_op_order = item["pre_op_order"].ToString(),
                                nbm_order = item["nbm_order"].ToString(),
                                patient_shaving = item["patient_shaving"].ToString(),
                                pre_op_fitness = item["pre_op_fitness"].ToString(),
                                pre_op_investigation = item["pre_op_investigation"].ToString(),
                                surgery_note = item["surgery_note"].ToString(),
                                post_op_order = item["post_op_order"].ToString(),
                                hpe = item["hpe"].ToString(),

                            };
                            surgerychecklist.Add(pa);
                        }
                        ViewBag.surgerychecklist = surgerychecklist;
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
        public ActionResult SurgeryChecklist(SurgeryChecklistModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_surgery_check_list(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/SurgeryChecklist");
        }

        public ActionResult PreOperativeFitness()
        {
            p.OnTable = "FetchPreOperativeFitness";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<PreOperativeFitnessModel> preoperativefitnesslist = new List<PreOperativeFitnessModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            PreOperativeFitnessModel pa = new PreOperativeFitnessModel()
                            {
                                date = item["date"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                h_o_doe = item["h_o_doe"].ToString(),
                                h_o_hbp = item["h_o_hbp"].ToString(),
                                h_o_mejor_medical = item["h_o_mejor_medical"].ToString(),
                                h_o_blood_transfusion = item["h_o_blood_transfusion"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                bp = item["bp"].ToString(),
                                r_s_bil = item["r_s_bil"].ToString(),
                                no_rales = item["no_rales"].ToString(),
                                s1s2 = item["s1s2"].ToString(),
                                nogallop = item["nogallop"].ToString(),
                                p_a_soft = item["p_a_soft"].ToString(),
                                liver_spleen = item["liver_spleen"].ToString(),
                                cns_conscious = item["cns_conscious"].ToString(),
                                ecg = item["ecg"].ToString(),
                                pre_of = item["pre_of"].ToString(),

                            };
                            preoperativefitnesslist.Add(pa);
                        }
                        ViewBag.preoperativefitnesslist = preoperativefitnesslist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult PreOperativeFitnessList()
        {
            p.OnTable = "FetchPreOperativeFitness";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<PreOperativeFitnessModel> preoperativefitnesslist = new List<PreOperativeFitnessModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            PreOperativeFitnessModel pa = new PreOperativeFitnessModel()
                            {
                                date = item["date"].ToString(),
                                patient_id = item["patient_id"].ToString(),
                                h_o_doe = item["h_o_doe"].ToString(),
                                h_o_hbp = item["h_o_hbp"].ToString(),
                                h_o_mejor_medical = item["h_o_mejor_medical"].ToString(),
                                h_o_blood_transfusion = item["h_o_blood_transfusion"].ToString(),
                                temp = item["temp"].ToString(),
                                pulse = item["pulse"].ToString(),
                                bp = item["bp"].ToString(),
                                r_s_bil = item["r_s_bil"].ToString(),
                                no_rales = item["no_rales"].ToString(),
                                s1s2 = item["s1s2"].ToString(),
                                nogallop = item["nogallop"].ToString(),
                                p_a_soft = item["p_a_soft"].ToString(),
                                liver_spleen = item["liver_spleen"].ToString(),
                                cns_conscious = item["cns_conscious"].ToString(),
                                ecg = item["ecg"].ToString(),
                                pre_of = item["pre_of"].ToString(),

                            };
                            preoperativefitnesslist.Add(pa);
                        }
                        ViewBag.preoperativefitnesslist = preoperativefitnesslist;
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
        public ActionResult PreOperativeFitness(PreOperativeFitnessModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_pre_operative_fitness(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/PreOperativeFitness");
        }

        public ActionResult DischargeSummary()
        {
            p.OnTable = "FetchDischargeSummary";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<DischargeSummaryModel> dischargesummarylist = new List<DischargeSummaryModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DischargeSummaryModel pa = new DischargeSummaryModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                indoor_no = item["indoor_no"].ToString(),
                                room_no = item["room_no"].ToString(),
                                admision_date = item["admision_date"].ToString(),
                                admision_time = item["admision_time"].ToString(),
                                discharge_date = item["discharge_date"].ToString(),
                                discharge_time = item["discharge_time"].ToString(),
                                reference_doctor_1 = item["reference_doctor_1"].ToString(),
                                reference_doctor_2 = item["reference_doctor_2"].ToString(),
                                reference_doctor_3 = item["reference_doctor_3"].ToString(),
                                admission_reason = item["admission_reason"].ToString(),
                                diagnosis = item["diagnosis"].ToString(),
                                followup_after_discharge = item["followup_after_discharge"].ToString(),
                                condition_on_discharge = item["condition_on_discharge"].ToString(),
                                treatment_on_discharge = item["treatment_on_discharge"].ToString(),
                                treatment_given = item["treatment_given"].ToString(),
                                brief_history = item["brief_history"].ToString(),

                            };
                            dischargesummarylist.Add(pa);
                        }
                        ViewBag.dischargesummarylist = dischargesummarylist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult DischargeSummaryList()
        {
            p.OnTable = "FetchDischargeSummary";
            ds = dl.FetchMaster(p);
            ViewBag.PatientList = cb.Patientlist();
            List<DischargeSummaryModel> dischargesummarylist = new List<DischargeSummaryModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DischargeSummaryModel pa = new DischargeSummaryModel()
                            {
                                patient_id = item["patient_id"].ToString(),
                                indoor_no = item["indoor_no"].ToString(),
                                room_no = item["room_no"].ToString(),
                                admision_date = item["admision_date"].ToString(),
                                admision_time = item["admision_time"].ToString(),
                                discharge_date = item["discharge_date"].ToString(),
                                discharge_time = item["discharge_time"].ToString(),
                                reference_doctor_1 = item["reference_doctor_1"].ToString(),
                                reference_doctor_2 = item["reference_doctor_2"].ToString(),
                                reference_doctor_3 = item["reference_doctor_3"].ToString(),
                                admission_reason = item["admission_reason"].ToString(),
                                diagnosis = item["diagnosis"].ToString(),
                                followup_after_discharge = item["followup_after_discharge"].ToString(),
                                condition_on_discharge = item["condition_on_discharge"].ToString(),
                                treatment_on_discharge = item["treatment_on_discharge"].ToString(),
                                treatment_given = item["treatment_given"].ToString(),
                                brief_history = item["brief_history"].ToString(),

                            };
                            dischargesummarylist.Add(pa);
                        }
                        ViewBag.dischargesummarylist = dischargesummarylist;
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
        public ActionResult DischargeSummary(DischargeSummaryModel m)
        {
            try
            {
                TempData["MSG"] = dl.Insert_discharge_summery(m) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Admin/DischargeSummary");
        }
    }
}