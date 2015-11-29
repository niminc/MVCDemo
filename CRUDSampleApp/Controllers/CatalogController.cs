using CRUDSampleAppBAL;
using CRUDSampleAppEntity;
using CRUDSampleAppEntity.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDSampleApp.Controllers
{
    public class CatalogController : Controller
    {
        #region Grid Methods
        public ActionResult Index()
        {
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_Index", catalogs.ToList());
            //}
            //else
            //{
            //    return View(catalogs.ToList());
            //}
            return View();
        }

        public string GetGridData(GridSettings grid)
        {
            try
            {
                return new CatalogBL().GetGridData(grid);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region UI

        public PartialViewResult ManageCatalog(int id)
        {
            tblCatalog catalog = new tblCatalog();
            if (id != 0)
            {
                catalog = new CatalogBL().GetById(id);
            }
            ViewBag.Types = new CatalogTypeBL().GetAllCatalogTypes();

            return PartialView("_Manage", catalog);
        }

        #endregion

        #region CRUD Methods

        public ActionResult Save(tblCatalog oCatalog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool Add_Flg = new CommonBL().isNewEntry(oCatalog.Id);
                    if (Add_Flg)
                        new CatalogBL().Create(oCatalog);
                    else
                        new CatalogBL().Update(oCatalog);

                    //TempData["successmsg"] = CommonMsg.Success_Update(EntityNames.Company);
                    return RedirectToAction("ManageCatalog", new { id = oCatalog.Id });
                }
                catch (Exception ex)
                {
                    //TempData["errormsg"] = CommonMsg.Error();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //TempData["errormsg"] = CommonMsg.Error();
                return RedirectToAction("Index");
            }
        }

        public JsonResult DeleteCatalog(int id)
        {
            try
            {
                new CatalogBL().Delete(id);
                return Json(new { success = true, Message = CommonMsg.Success_Delete(EntityNames.Catalog) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Message = CommonMsg.DependancyError() });
            }
        }
        #endregion

        public JsonResult IsBarCodeUnique(tblCatalog catalog)
        {
            return Json(!new CatalogBL().IsCatalogExist(catalog.CatalogName, catalog.Barcode));
        }
    }
}
