using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Models.Web.Api.Models.BDCajaAhorro;
using TRAX.Models.Web.Api.Models.BDContext;


namespace TRAX.Framework.Negocio.Web.Api.Repository
{
    public class RepositoryTrax
    {

        public RepositoryTrax()
        {

        }
        //Guarda en usuarios
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
        //Guarda en base CajaAhorro
        public void AddDatos<T>(T Register) where T : class
        {
            try
            {
                using (CajaAhorro _dbcontxCajaAhorro = new CajaAhorro())
                {
                    _dbcontxCajaAhorro.Set<T>().Add(Register);
                    _dbcontxCajaAhorro.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void UpdateDatos<T>(T Register) where T : class
        {
            try
            {
                using (CajaAhorro _dbcontxCajaAhorro = new CajaAhorro())
                {
                    _dbcontxCajaAhorro.Entry(Register).State = System.Data.Entity.EntityState.Modified;

                    _dbcontxCajaAhorro.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void RemoveDatos<T>(T Register) where T : class
        {
            try
            {
                using (CajaAhorro _dbcontxCajaAhorro = new CajaAhorro())
                {
                    _dbcontxCajaAhorro.Set<T>().Remove(Register);
                    _dbcontxCajaAhorro.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ahorro> GetAhorrosByUsuario(int IdUsuario)
        {
            List<Ahorro> _listAhorro = new List<Ahorro>();
            using (CajaAhorro _context = new CajaAhorro())
            {
                _listAhorro = _context.Ahorro.Include(x=> x.Usuario).Where(x => x.Id_Usuario == IdUsuario).ToList();

            }
            return _listAhorro;

        }

        public bool ExisteRegistro(int IdUsuario)
        {
            bool existe = false;
            using (var context = new CajaAhorro())
            {
               existe = context.Ahorro.Any(x => x.Id_Usuario == IdUsuario);
                
            }
            return existe;
        }

    }
}
