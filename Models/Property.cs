using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanskarHospital.Models
{
    public class Property
    {
        private string con = @"data source=A2NWPLSK14SQL-v06.shr.prod.iad2.secureserver.net;initial catalog=HospitalERP;persist security info=true;user id=HospitalERP;password=6x9oP61g$";
        //private string con = @"data source=MODASSIR\MODASSIR2019;initial catalog=HospitalERP;persist security info=true;user id=sa;password=sql@2019";
        public string Con
        {
            get
            {
                return con;
            }
        }
        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public string Condition5 { get; set; }
        public string Condition6 { get; set; }
        public string Condition7 { get; set; }
        public string Condition8 { get; set; }
        public string Condition9 { get; set; }
        public string Condition10 { get; set; }
        public string Condition11 { get; set; }
        public string Condition12 { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }
        public string Id { get; set; }
        public string OnTable { get; set; }
        public string EmailId { get; set; }
        public string UserType { get; set; }
        public string Status { get; set; }
    }
}