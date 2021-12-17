using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Framework.Negocio.Web.Api.Repository;
using TRAX.Models.Web.Api.Models.BDContext;
using TRAX.Models.Web.Api.OperationResult;

namespace TRAX.Framework.Negocio.Web.Api.Core
{
    public class CoreTraxApi
    {
        private Logger _Logger;
        public CoreTraxApi(Logger Logger)
        {
            this._Logger = Logger;

        }

        public  OperationResult AddUsuario(string Nombre,string APaterno,string AMaterno,int IdRol)
         {
            OperationResult _operationResult = new OperationResult();
            RepositoryTrax _repository = new RepositoryTrax();

            try
            {
                Usuarios user = new Usuarios()
                {
                    Nombre = Nombre.Trim(),
                    APaterno = APaterno,
                    AMaterno = AMaterno,
                    IdRol = IdRol,
                    Activo = true
                };
                _repository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
            return _operationResult;
        }

    }
}
