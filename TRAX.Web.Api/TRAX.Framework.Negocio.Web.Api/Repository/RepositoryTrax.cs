using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Models.Web.Api.Models.BDContext;


namespace TRAX.Framework.Negocio.Web.Api.Repository
{
    public class RepositoryTrax
    {
     
        public RepositoryTrax()
        {
            
        }

        public void Add<T>(T Register) where T : class
        {
            using (ApiTraxDB _PapeleriaDbContext = new ApiTraxDB())
            {
                _PapeleriaDbContext.Set<T>().Add(Register);
                _PapeleriaDbContext.SaveChanges();

            }
        }
        public void Update<T>(T Register) where T : class
        {
            using (ApiTraxDB _PapeleriaDbContext = new ApiTraxDB())
            {
                _PapeleriaDbContext.Entry(Register).State = System.Data.Entity.EntityState.Modified;

                _PapeleriaDbContext.SaveChanges();
            }
        }
        public void Remove<T>(T Register) where T : class
        {
            try
            {
                using (ApiTraxDB _PapeleriaDbContext = new ApiTraxDB())
                {
                    _PapeleriaDbContext.Set<T>().Remove(Register);
                    _PapeleriaDbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
