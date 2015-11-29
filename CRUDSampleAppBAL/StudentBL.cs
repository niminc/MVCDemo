using CRUDSampleAppEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSampleAppBAL
{
    public class StudentBL
    {
        #region Get Methods

        public tblStudent GetById(int id)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    return ctx.tblStudents.Include(c => c.tblContactDetail).Where(c => c.StudentId == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetGridData(GridSettings grid)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    var query = ctx.tblStudents.AsQueryable();


                    int count;
                    var data = query.GridCommonSettings(grid, out count);

                    var result = new
                    {
                        total = (int)Math.Ceiling((double)count / grid.PageSize),
                        page = grid.PageIndex,
                        records = count,
                        rows = (from c in data
                                select new
                                {
                                    StudentId = c.StudentId,
                                    FirstName = c.FirstName,
                                    MiddleName = c.MiddleName,
                                    LastName = c.LastName,
                                    ContactId = c.ContactId,
                                    CreateDate = c.CreateDate,
                                    ModifiedDate = c.ModifiedDate,
                                    ContactDetail = c.tblContactDetail.ContactDetail
                                }).ToArray()
                    };
                    return JsonConvert.SerializeObject(result, new IsoDateTimeConverter());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsFirstNameExist(string firstname, int StudentId)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    return ctx.tblStudents.Where(t => t.FirstName == firstname && t.StudentId != StudentId).Count() > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region CRUD Operations

        public void Create(tblStudent oStudent)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    oStudent.ModifiedDate = DateTime.Now;

                    oStudent.CreateDate = DateTime.Now;
                    oStudent.ModifiedDate = DateTime.Now;
                    ctx.tblStudents.Add(oStudent);

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tblStudent oStudent)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    ctx.tblContactDetails.Attach(oStudent.tblContactDetail);
                    ctx.Entry(oStudent.tblContactDetail).State = EntityState.Modified;

                    ctx.tblStudents.Attach(oStudent);
                    ctx.Entry(oStudent).State = EntityState.Modified;

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    tblStudent oStudent = ctx.tblStudents.Where(c => c.StudentId == id).FirstOrDefault();
                    ctx.tblStudents.Remove(oStudent);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
