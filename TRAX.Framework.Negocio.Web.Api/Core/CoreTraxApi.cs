using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Framework.Negocio.Web.Api.Repository;
using TRAX.Models.Web.Api.Models.BDCajaAhorro;
using TRAX.Models.Web.Api.Models.BDContext;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace TRAX.Framework.Negocio.Web.Api.Core
{
    public class CoreTraxApi
    {
        private Logger _Logger;
        public CoreTraxApi(Logger Logger)
        {
            this._Logger = Logger;

        }

        public OperationResult AddUsuario(string Nombre, string APaterno, string AMaterno, int IdRol)
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

        public OperationResult AgregarUsuario(string Nombre, string APaterno, string AMaterno)
        {
            OperationResult _operationResult = new OperationResult();
            RepositoryTrax _repository = new RepositoryTrax();


            try
            {
                Usuario user = new Usuario()
                {
                    Nombre = Nombre.Trim(),
                    ApellidoPaterno = APaterno.Trim(),
                    ApellidoMaterno = AMaterno.Trim(),
                    Activo = true
                };
                _repository.AddDatos(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return _operationResult;
        }
        public OperationResult AddAhorro(int IdUsuario, decimal Cantidad, DateTime fechaCobro, decimal Total)
        {
            OperationResult _operationResult = new OperationResult();
            try
            {
                RepositoryTrax _repository = new RepositoryTrax();

               var existe = _repository.ExisteRegistro(IdUsuario);
                if (!existe)
                {
                    decimal sum = 0;
                    sum =  Cantidad;
                    Ahorro ahorro = new Ahorro()
                    {
                        Id_Usuario = IdUsuario,
                        Cantidad = Cantidad,
                        Fecha_Cobro = fechaCobro,
                        Total = sum,
                        Activo = true
                    };
                    _repository.AddDatos(ahorro);

                }
                else {
                    decimal suma = 0;
                    var result = FindAhorroByIdUsuario(IdUsuario);
                    List<decimal> listCantidad = new List<decimal>();
                    listCantidad = result.List.Select(x => x.Cantidad).ToList();
                    suma = result.List.Sum(x => x.Cantidad);
                    var resultTotal = Cantidad + suma;

                    Ahorro user = new Ahorro()
                    {
                        Id_Usuario = IdUsuario,
                        Cantidad = Cantidad,
                        Fecha_Cobro = fechaCobro,
                        Total = resultTotal,
                        Activo = true
                    };
                    _repository.AddDatos(user);


                }
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return _operationResult;
        }
        public ObtenerAhorroByUsuarioReponseDTO FindAhorroByIdUsuario(int IdUsuario)
        {
            List<Ahorro> _query = new List<Ahorro>();
            ObtenerAhorroByUsuarioReponseDTO _Response = new ObtenerAhorroByUsuarioReponseDTO();
            RepositoryTrax _repository = new RepositoryTrax();
            _query = _repository.GetAhorrosByUsuario(IdUsuario);
            if (!_query.Any()) throw new Exception("No se econtraron resultados con el Id del Usuario " + IdUsuario);
            _Response = MapListAhorro(_query);
            return _Response;
        }

        public ObtenerAhorroByUsuarioReponseDTO MapListAhorro(List<Ahorro> _lts)
        {
            ObtenerAhorroByUsuarioReponseDTO _Response = new ObtenerAhorroByUsuarioReponseDTO();
            _Response.List = _lts.Select(x => new AhorroDTO()
            {
                Id = x.Id,
                Cantidad = x.Cantidad,
                IdUsuario = x.Id_Usuario,
                FechaCobro = x.Fecha_Cobro,
                Total = x.Total,
            }).ToList();
            return _Response;

        }




    }
}
