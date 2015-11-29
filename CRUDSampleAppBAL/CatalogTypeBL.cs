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
    public class CatalogTypeBL
    {
        #region Get Methods

        public tblCatalogType GetById(int id)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    return ctx.tblCatalogTypes.Where(c => c.TypeId == id).FirstOrDefault();
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
                    var query = ctx.tblCatalogTypes.AsQueryable();


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
                                    TypeId = c.TypeId,
                                    TypeName = c.TypeName
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

        public List<tblCatalogType> GetAllCatalogTypes()
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    return ctx.tblCatalogTypes.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region CRUD Operations

        public void Create(tblCatalogType oCatalogType)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    ctx.tblCatalogTypes.Add(oCatalogType);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tblCatalogType oCatalogType)
        {
            try
            {
                using (var ctx = new CRUDSampleEntities())
                {
                    ctx.Entry(oCatalogType).State = EntityState.Modified;
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
                    tblCatalogType oCatalogType = ctx.tblCatalogTypes.Where(c => c.TypeId == id).FirstOrDefault();
                    ctx.tblCatalogTypes.Remove(oCatalogType);
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
