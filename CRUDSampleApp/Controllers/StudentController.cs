using CRUDSampleAppBAL;
using CRUDSampleAppEntity;
using CRUDSampleAppEntity.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDSampleApp.Controllers
{
    public class StudentController : Controller
    {
        #region Grid Methods

        public ActionResult Index()
        {
            //var tblstudents = db.tblStudents.Include(t => t.tblContactDetail);
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_Index", tblstudents.ToList());
            //}
            //else
            //{
            //    return View(tblstudents.ToList());
            //}
            return View();
        }

        public string GetGridData(GridSettings grid)
        {
            try
            {
                return new StudentBL().GetGridData(grid);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region UI

        public ActionResult ManageStudent(int id)
        {
            tblStudent student = new tblStudent();
            student.tblContactDetail = new tblContactDetail();
            if (id != 0)
            {
                student = new StudentBL().GetById(id);
            }

            return PartialView("_ManageStudent", student);
        }

        #endregion

        #region CRUD Methods

        public ActionResult Save(tblStudent oStudent)
        {
            try
            {
                bool Add_Flg = new CommonBL().isNewEntry(oStudent.StudentId);
                if (Add_Flg)
                    new StudentBL().Create(oStudent);
                else
                    new StudentBL().Update(oStudent);

                TempData["successmsg"] = CommonMsg.Success_Update(EntityNames.Student);
                return RedirectToAction("ManageStudent", new { id = oStudent.StudentId });
            }
            catch (Exception ex)
            {
                TempData["errormsg"] = CommonMsg.Error();
                return RedirectToAction("Index");
            }
        }

        public JsonResult DeleteStudent(int id)
        {
            try
            {
                new StudentBL().Delete(id);
                return Json(new { success = true, Message = CommonMsg.Success_Delete(EntityNames.Student) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Message = CommonMsg.DependancyError() });
            }
        }

        public JsonResult IsFirstUnique(string FirstName, int StudentId)
        {
            return Json(!new StudentBL().IsFirstNameExist(FirstName, StudentId), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}