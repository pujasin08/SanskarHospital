using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class MRDChecklistModel
    {
        public string patient_id { get; set; }
        public string ipd_number { get; set; }
        public string discharge_summary { get; set; }
        public string casesheet { get; set; }
        public string dr_continuation_sheet { get; set; }
        public string consent_from_for_procedures { get; set; }
        public string pre_operative_checklist { get; set; }
        public string pre_operative_surgeon { get; set; }
        public string pre_anaesthesia_evalution { get; set; }
        public string anaesthesia_formulation_care_plan { get; set; }
        public string intra_anaesthesia_record { get; set; }
        public string post_anaesthesia_record { get; set; }
        public string post_operative_surgeon { get; set; }
        public string tpr_chart { get; set; }
        public string intake_output_chart { get; set; }
        public string drug_chart { get; set; }
        public string nurse_note { get; set; }
        public string investigation_report { get; set; }
        public string general_consent { get; set; }
    }
}