using SanskarHospital.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class DataLayer
    {
        public static byte[] pImage;

        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {

            int a = 0;
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@img")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
            }
            con.Open();

            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;

        }

        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {
                Property p = new Property();
                SqlConnection con = new SqlConnection(p.Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandTimeout = 1000;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                DataSet ds = null;
                return ds;

            }

        }

        public DataSet MyDs_Process(String Storp)
        {

            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }

        public void runQry(string cmd)
        {
            Property p = new Property();
            SqlConnection con = new SqlConnection(p.Con);
            SqlCommand cmd1 = new SqlCommand(cmd, con);
            cmd1.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Open)
            { con.Close(); }

            con.Open();
            cmd1.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }


        public DataSet runQueryDs(string cmd)
        {
            Property p = new Property();
            SqlDataAdapter dab = new SqlDataAdapter(cmd, p.Con);
            DataSet ds = new DataSet();
            ds.Clear();
            dab.Fill(ds);
            GC.SuppressFinalize(p);
            GC.SuppressFinalize(dab);

            return ds;
        }



        //----------------------Data Access Layer Work---------------------------
        EncryptDecrypt enc = new EncryptDecrypt();
        public DataSet FetchMaster(Property p)
        {
            try
            {
                string[] pname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@Condition10", "@Condition11", "@onTable" };
                string[] pvalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.Condition10, p.Condition11, p.OnTable };
                return Ds_Process("FetchMaster", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int Insert_patient(PatientModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@patient_uhid", "@patient_name", "@patient_address", "@patient_mobile", "@patient_sex", "@patient_dob", "@patient_identification_mark", "@patient_marital_status", "@patient_habit", "@patient_blood_group", "@is_active" };
                string[] pvalue = { p.patient_id, p.patient_uhid, p.patient_name, p.patient_address, p.patient_mobile, p.patient_sex, p.patient_dob, p.patient_identification_mark, p.patient_marital_status, p.patient_habit, p.patient_blood_group, p.is_active };
                return Int_Process("Insert_patient", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_doctor(DoctorModel p)
        {
            try
            {
                string[] pname = { "@doctor_id", "@doctor_name", "@doctor_mobile", "@doctor_email", "@doctor_sex", "@doctor_specialization", "@doctor_address", "@doctor_degree", "@is_active" };
                string[] pvalue = { p.doctor_id, p.doctor_name, p.doctor_mobile, p.doctor_email, p.doctor_sex, p.doctor_specialization, p.doctor_address, p.doctor_degree, p.is_active };
                return Int_Process("Insert_doctor", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_nurse(NurseModel p)
        {
            try
            {
                string[] pname = { "@nurse_id", "@nurse_name", "@nurse_mobile", "@nurse_email", "@nurse_sex", "@nurse_address", "@is_active" };
                string[] pvalue = { p.nurse_id, p.nurse_name, p.nurse_mobile, p.nurse_email, p.nurse_sex, p.nurse_address, p.is_active };
                return Int_Process("Insert_nurse", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int Insert_drug(DrugModel p)
        {
            try
            {
                string[] pname = { "@drug_id", "@drug_name" };
                string[] pvalue = { p.drug_id, p.drug_name };
                return Int_Process("Insert_drug", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Insert_patient_addmission(PatientAdmission p)
        {
            try
            {
                string[] pname = { "@patient_id", "@arrival_time", "@assesment_time", "@room_no", "@indoor_no", "@date_of_addmission", "@addmission_time", "@discharge_date", "@discharge_time", "@history", "@examination", "@diagnosis" };
                string[] pvalue = { p.patient_id, p.arrival_time, p.assesment_time, p.room_no, p.indoor_no, p.date_of_addmission, p.addmission_time, p.discharge_date, p.discharge_time, p.history, p.examination, p.diagnosis };
                return Int_Process("Insert_patient_addmission", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_patient_investigation(PatientInvestigation p)
        {
            try
            {
                string[] pname = { "@doctor_id", "@patient_id", "@date", "@hb", "@tc", "@dc", "@esr", "@pc", "@smer", "@urine", "@stool", "@rbs", "@creatinine", "@na", "@k", "@ca", "@s_billi", "@sgpt", "@s_alk_po4_ase", "@a_alk_po4_ase", "@s_amylase", "@s_lipase", "@s_protein", "@ecg", "@cxr", "@usg_sonography", "@ct_mr", "@others" };
                string[] pvalue = { p.doctor_id, p.patient_id, p.date, p.hb, p.tc, p.dc, p.esr, p.pc, p.smer, p.urine, p.stool, p.rbs, p.creatinine, p.na, p.k, p.ca, p.s_billi, p.sgpt, p.s_alk_po4_ase, p.a_alk_po4_ase, p.s_amylase, p.s_lipase, p.s_protein, p.ecg, p.cxr, p.usg_sonography, p.ct_mr, p.others };
                return Int_Process("Insert_patient_investigation", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_treatment_chart(TreatmentChartModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@day", "@doctor_id", "@date", "@time", "@sr_no", "@drug_id", "@dose", "@dilution", "@route", "@frequency", "@admit_time", "@nurse_id", "@doctor", "@risk_type", "@rbs_time", "@rbs", "@rbs_insulin", "@rbs_nurse", "@rbs_doctor", "@discharge_plan", "@investigation_plan", "@diet_advice", "@consultant_note" };
                string[] pvalue = { p.patient_id, p.day, p.doctor_id, p.date, p.time, p.sr_no, p.drug_id, p.dose, p.dilution, p.route, p.frequency, p.admit_time, p.nurse_id, p.doctor, p.risk_type, p.rbs_time, p.rbs, p.rbs_insulin, p.rbs_nurse, p.rbs_doctor, p.discharge_plan, p.investigation_plan, p.diet_advice, p.consultant_note };
                return Int_Process("Insert_treatment_chart", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public int Insert_doctor_progress_note(DoctorProgressNoteModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@location", "@date", "@patient_complain", "@temp", "@pulse", "@bp", "@spo2", "@time", "@shift" };
                string[] pvalue = { p.patient_id, p.location, p.date, p.patient_complain, p.temp, p.pulse, p.bp, p.spo2, p.time, p.shift };
                return Int_Process("Insert_doctor_progress_note", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int Insert_rbs_chart(RBSChartModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@doctor_id", "@date", "@time", "@rbs", "@insuline_given", "@nurse_id" };
                string[] pvalue = { p.patient_id, p.doctor_id, p.date, p.time, p.rbs, p.insuline_given, p.nurse_id };
                return Int_Process("Insert_rbs_chart", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Insert_nursing_assessment(NursingAssessmentModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@date", "@unit", "@arrival_time", "@assessment_time", "@nurse_id", "@admitted_form", "@patient_arrived", "@hight", "@weight", "@unable_weight", "@estimatted_weight", "@reason", "@temp", "@pulse", "@respiration", "@bp", "@spo2", "@loc", "@ho_allergy", "@dentures", "@spactacles", "@id_belt", "@id_colour", "@vulnerable", "@bedsore", "@bedsore_details",  };
                string[] pvalue = { p.patient_id, p.date, p.unit, p.arrival_time, p.assessment_time, p.nurse_id, p.admitted_form, p.patient_arrived, p.hight, p.weight, p.unable_weight, p.estimatted_weight, p.reason, p.temp, p.pulse, p.respiration, p.bp, p.spo2, p.loc, p.ho_allergy, p.dentures, p.spactacles, p.id_belt, p.id_colour, p.vulnerable, p.bedsore, p.bedsore_details };
                return Int_Process("Insert_nursing_assessment", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Insert_item_check_master(ItemModel p)
        {
            try
            {
                string[] pname = { "@item_id", "@item_name", "@patient_id", "@quantity", "checking", "@id" };
                string[] pvalue = { p.item_id, p.item_name, p.patient_id, p.quantity, p.checking, p.id };
                return Int_Process("Insert_item_check_master", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_nursing_care_paln(NursingCarePlanModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@nursing_diagnosis", "@date", "@nursing_care_plan", "@nursing_interventions", "@outcomes", "@duty_shift", "@nurse_id" };
                string[] pvalue = { p.patient_id, p.nursing_diagnosis, p.date, p.nursing_care_plan, p.nursing_interventions, p.outcomes, p.duty_shift, p.nurse_id };
                return Int_Process("Insert_nursing_care_paln", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_tpr_input_output(TPRInputOutputModel p)
        {
            try
            {
                string[] pname = { "@date", "@room_no", "@doctor_id", "@patient_id", "@shift_chart", "@time", "@temp", "pulse", "@blood_pressure", "@spo2", "@rbs", "@input_oral", "@input_iv", "@output_urine", "@output_aspiration" };
                string[] pvalue = { p.date, p.room_no, p.doctor_id, p.patient_id, p.shift_chart, p.time, p.temp, p.pulse, p.blood_pressure, p.spo2, p.rbs, p.input_oral, p.input_iv, p.output_urine, p.output_aspiration };
                return Int_Process("Insert_tpr_input_output", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_mrd_checklist(MRDChecklistModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@ipd_number", "@discharge_summary", "@casesheet", "@dr_continuation_sheet", "@consent_from_for_procedures", "@pre_operative_checklist", "@pre_operative_surgeon", "@pre_anaesthesia_evalution", "@anaesthesia_formulation_care_plan", "@intra_anaesthesia_record", "@post_anaesthesia_record", "@post_operative_surgeon", "@tpr_chart", "@intake_output_chart", "@drug_chart", "@nurse_note", "@investigation_report", "@general_consent" };
                string[] pvalue = { p.patient_id, p.ipd_number, p.discharge_summary, p.casesheet, p.dr_continuation_sheet, p.consent_from_for_procedures, p.pre_operative_checklist, p.pre_operative_surgeon, p.pre_anaesthesia_evalution, p.anaesthesia_formulation_care_plan, p.intra_anaesthesia_record, p.post_anaesthesia_record, p.post_operative_surgeon, p.tpr_chart, p.intake_output_chart, p.drug_chart, p.nurse_note, p.investigation_report, p.general_consent };
                return Int_Process("Insert_mrd_checklist", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_surgery_note(SurgeryNoteModel p)
        {
            try
            {
                string[] pname = { "@date", "@time", "@doctor_id", "@anaesthetist_name", "@patient_id", "@diagnosis_pre_op", "@diagnosis_post_op", "@indoor_no", "@proce_dure", "@steps", "@pre_assessment_time", "@pre_assessment_pulse", "@pre_assessment_bp", "@pre_assessment_spo2", "@pre_assessment_iv", "@pre_assessment_output", "@pre_assessment_bloodloss", "@findings", "@drains", "@complication", "@advice", "@post_time", "@post_temp", "@post_pulse", "@post_bp", "@post_spo2" };
                string[] pvalue = { p.date, p.time, p.doctor_id, p.anaesthetist_name, p.patient_id, p.diagnosis_pre_op, p.diagnosis_post_op, p.indoor_no, p.proce_dure, p.steps, p.pre_assessment_time, p.pre_assessment_pulse, p.pre_assessment_bp, p.pre_assessment_spo2, p.pre_assessment_iv, p.pre_assessment_output, p.pre_assessment_bloodloss, p.findings, p.drains, p.complication, p.advice, p.post_time, p.post_temp, p.post_pulse, p.post_bp, p.post_spo2 };
                return Int_Process("Insert_surgery_note", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_surgery_name_master(SurgeryNameMasterModel p)
        {
            try
            {
                string[] pname = { "@surgery_id", "@surgery_name" };
                string[] pvalue = { p.surgery_id, p.surgery_name };
                return Int_Process("Insert_surgery_name_master", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_anaesthesia_master(AnaesthesiaMasterModel p)
        {
            try
            {
                string[] pname = { "@anaesthesia_id", "@anaesthesia_name" };
                string[] pvalue = { p.anaesthesia_id, p.anaesthesia_name };
                return Int_Process("Insert_anaesthesia_master", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Insert_surgery_check_list(SurgeryChecklistModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@surgery_id", "@doctor_id", "@anaesthesia_id", "@surgery_consent", "@anaesthesia_assessment", "@pre_op_order", "@nbm_order", "@patient_shaving", "@pre_op_fitness", "@pre_op_investigation", "@surgery_note", "@post_op_order", "@hpe" };
                string[] pvalue = { p.patient_id, p.surgery_id, p.doctor_id, p.anaesthesia_id, p.surgery_consent, p.anaesthesia_assessment, p.pre_op_order, p.nbm_order, p.patient_shaving, p.pre_op_fitness, p.pre_op_investigation, p.surgery_note, p.post_op_order, p.hpe };
                return Int_Process("Insert_surgery_check_list", pname, pvalue);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int Insert_pre_operative_fitness(PreOperativeFitnessModel p)
        {
            try
            {
                string[] pname = { "@date","@patient_id", "@h_o_doe", "@h_o_hbp", "@h_o_mejor_medical", "@h_o_blood_transfusion", "@temp", "@pulse", "@bp", "@r_s_bil", "@no_rales", "@s1s2", "@nogallop", "@p_a_soft", "@liver_spleen", "@cns_conscious", "@ecg", "@pre_of" };
                string[] pvalue = { p.date, p.patient_id, p.h_o_doe, p.h_o_hbp, p.h_o_mejor_medical, p.h_o_blood_transfusion, p.temp, p.pulse, p.bp, p.r_s_bil, p.no_rales, p.s1s2, p.nogallop, p.p_a_soft, p.liver_spleen, p.cns_conscious, p.ecg, p.pre_of };
                return Int_Process("Insert_pre_operative_fitness", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Insert_discharge_summery(DischargeSummaryModel p)
        {
            try
            {
                string[] pname = { "@patient_id", "@indoor_no", "@room_no", "@admision_date", "@admision_time", "@discharge_date", "@discharge_time", "@reference_doctor_1", "@reference_doctor_2", "@reference_doctor_3", "@admission_reason", "@diagnosis", "@followup_after_discharge", "@condition_on_discharge", "@treatment_on_discharge", "@treatment_given", "@brief_history" };
                string[] pvalue = { p.patient_id, p.indoor_no, p.room_no, p.admision_date, p.admision_time, p.discharge_date, p.discharge_time, p.reference_doctor_1, p.reference_doctor_2, p.reference_doctor_3, p.admission_reason, p.diagnosis, p.followup_after_discharge, p.condition_on_discharge, p.treatment_on_discharge, p.treatment_given, p.brief_history };
                return Int_Process("Insert_discharge_summery", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}