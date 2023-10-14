using SanskarHospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanskarHospital.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        DataSet ds = new DataSet();
        DataLayer dl = new DataLayer();
        Property p = new Property();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ItemMasterList()
        {
            p.OnTable = "FetchItemMaster";
            ds = dl.FetchMaster(p);
            List<ItemModel> itemlist = new List<ItemModel>();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            ItemModel pa = new ItemModel()
                            {
                                item_id = item["item_id"].ToString(),
                                item_name = item["item_name"].ToString(),
                            };
                            itemlist.Add(pa);
                        }
                        ViewBag.itemlist = itemlist;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }
        public ActionResult ItemMaster(string id)
        {
            p.OnTable = "FetchItemMaster";
            p.Condition1 = id;
            ds = dl.FetchMaster(p);
            ItemModel info = new ItemModel();
            if (ds != null)
            {
                try
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow item = ds.Tables[1].Rows[0];

                        info = new ItemModel()
                        {
                            item_id = item["item_id"].ToString(),
                            item_name = item["item_name"].ToString(),
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
        [HttpPost]
        public ActionResult ItemMaster(ItemModel i)
        {
            try
            {
                TempData["MSG"] = dl.Insert_item_check_master(i) > 0 ? "Information is saved..!" : "Oops Something going wrong...!";
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Oops! Something going wrong...!";
            }
            return Redirect("/Item/ItemMaster");
        }
    }
}