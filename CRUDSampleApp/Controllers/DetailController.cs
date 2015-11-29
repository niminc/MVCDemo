using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDSampleApp.Controllers
{
    public class DetailController : Controller
    {
        //private CRUDSampleEntities db = new CRUDSampleEntities();

        public ActionResult Index()
        {
            var details = db.tblDetails;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", details.ToList());
            }
            else
            {
                return View(details.ToList());
            }
        }

        public PartialViewResult Manage(int id)
        {
            tblDetail detail = new tblDetail();
            if (id > 0)
            {
                detail = db.tblDetails.Where(t => t.Id == id).FirstOrDefault();
            }

            return PartialView("_Manage", detail);
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Manage(tblDetail detail)
        {
            if (detail.Id > 0)
            {
                db.tblDetails.Attach(detail);
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.tblDetails.Add(detail);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDetail detail = db.tblDetails.Find(id);
            db.tblDetails.Remove(detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
