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
    public class CatalogBL
    {
        #region Get Methods

        public tblCatalog GetById(int id)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    return ctx.tblCatalogs.Where(c => c.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsCatalogExist(string catalogName, string barcode)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    return ctx.tblCatalogs.Where(t => t.CatalogName == catalogName && t.Barcode == barcode).Count() > 0 ? true : false;
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
                    var query = ctx.tblCatalogs.AsQueryable();


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
                                    Id = c.Id,
                                    CatalogName = c.CatalogName,
                                    Barcode = c.Barcode,
                                    TypeId = c.TypeId,
                                    TypeName = c.tblCatalogType.TypeName,
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


        #endregion

        #region CRUD Operations

        public void Create(tblCatalog oCatalog)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    ctx.tblCatalogs.Add(oCatalog);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tblCatalog oCatalog)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    ctx.Entry(oCatalog).State = EntityState.Modified;
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
                    tblCatalog oCatalog = ctx.tblCatalogs.Where(c => c.Id == id).FirstOrDefault();
                    ctx.tblCatalogs.Remove(oCatalog);
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
