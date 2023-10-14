using SanskarHospital.Helpers;
using SanskarHospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanskarHospital.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DataLayer dl = new DataLayer();
        Property p = new Property();
        DataSet ds = new DataSet();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Property p)
        {
            p.Condition1 = p.EmailId.ToString();
            p.Condition2 = enc.Encrypt(p.Password.ToString());
            p.OnTable = "FetchLogin";
            ds = dl.FetchMaster(p);
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["UserType"].ToString() == "ADMIN")
                        {
                            HttpCookie logincookie = Response.Cookies["sanskarhospital"];
                            if (logincookie != null)
                            {
                                logincookie["Id"] = enc.Encrypt(ds.Tables[0].Rows[0]["Id"].ToString());
                                logincookie["EmailId"] = enc.Encrypt(ds.Tables[0].Rows[0]["EmailId"].ToString());
                                logincookie["UserType"] = enc.Encrypt(ds.Tables[0].Rows[0]["UserType"].ToString());
                                logincookie.Expires = DateTime.Now.AddDays(5);
                                Response.Cookies.Add(logincookie);
                            }
                            else
                            {
                                logincookie.Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies.Add(logincookie);
                                logincookie["Id"] = enc.Encrypt(ds.Tables[0].Rows[0]["Id"].ToString());
                                logincookie["EmailId"] = enc.Encrypt(ds.Tables[0].Rows[0]["EmailId"].ToString());
                                logincookie["UserType"] = enc.Encrypt(ds.Tables[0].Rows[0]["UserType"].ToString());
                                logincookie.Expires = DateTime.Now.AddDays(5);
                                Response.Cookies.Add(logincookie);
                            }
                            return Redirect("/Admin/Index");
                        }
                        else
                        {
                            TempData["MSG"] = "UserName or password is incorrect!!";
                            return Redirect("/Login/Index");
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["MSG"] = "UserName or password is incorrect!!";
                    return Redirect("/Login/Index");
                }
            }
                
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie sanskarhospital = Request.Cookies["sanskarhospital"];
            try
            {
                if (sanskarhospital != null)
                {
                    sanskarhospital.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(sanskarhospital);
                }
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();
            }
            catch (Exception ex)
            {
                throw;
            }

            //return RedirectToAction("Index", "Admin");
            return Redirect("/Login/Index");
        }

        public ActionResult ChangePassword()
        {
            // string test = enc.Decrypt("LgzXVSoYxGs=");
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(Property p)
        {
            string str = "";
            SqlConnection con = new SqlConnection(p.Con);
            con.Open();
            HttpCookie loginCookie = Request.Cookies["sanskarhospital"];
            p.Condition1 = enc.Decrypt(loginCookie.Values["Id"]);
            string cond2 = p.Condition2;
            string cond3 = p.Condition3;

            if (enc.Decrypt(loginCookie["UserType"]) == "ADMIN")
            {
                str = "Update Login_tbl set Password='" + p.Condition2 + "' where Id='" + p.Condition1 + "' and Password='" + p.Condition3 + "'";
            }

            try
            {
                SqlCommand cmd = new SqlCommand(str, con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    TempData["msg"] = "Password Changed Successfully!!!";

                }
                else
                {
                    TempData["msg"] = "Password Not Changed.!";

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Oops something going wrong!";

            }
            con.Close();
            return View();
        }
    }
}