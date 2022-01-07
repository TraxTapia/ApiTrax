using Microsoft.Extensions.Logging;
using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TRAX.Framework.Negocio.Web.Api.Core;
using TRAX.Models.Web.Api.Models.BDContext;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Request.RequestCajaAhorro;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace TRAX.Web.Api.Controllers
{
    [RoutePrefix("CajaAhorro")]
    public class CajaAhorroController : ApiController
    {
        private Logger _Logger;

        public CajaAhorroController()
        {
            this._Logger = new Logger(System.Web.Hosting.HostingEnvironment.MapPath("~/" + Properties.Settings.Default.LogPath));
        }

        [HttpPost]
        [Route("Usuarios")]
        public OperationResult AddUusuarios(UsuariosRequestDTO request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                if (!ModelState.IsValid)
                {
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    _Errors.ForEach(x => { if (x.Exception == null) _Response.AddException(new Exception(x.ErrorMessage)); else _Response.AddException(x.Exception); });
                    return _Response;

                }
                CoreTraxApi _Core = new CoreTraxApi(this._Logger);
                _Response = _Core.AgregarUsuario(request.Nombre, request.ApellidoPaterno, request.ApellidoMaterno);



            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }
        [HttpPost]
        [Route("Ahorro")]
        public OperationResult AddAhorro(RequestAhorroDTO request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                if (!ModelState.IsValid)
                {
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    _Errors.ForEach(x => { if (x.Exception == null) _Response.AddException(new Exception(x.ErrorMessage)); else _Response.AddException(x.Exception); });
                    return _Response;

                }
                CoreTraxApi _Core = new CoreTraxApi(this._Logger);
                _Response = _Core.AddAhorro(request.IdUsuario, request.Cantidad, request.FechaCobro, request.Total);



            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }
        [HttpPost]
        [Route("obtenerAhorros")]
        public ObtenerAhorroByUsuarioReponseDTO obtenerAhorros(ObtenerAhorroByUsuarioRequestDTO request)
        {
            ObtenerAhorroByUsuarioReponseDTO _Response = new ObtenerAhorroByUsuarioReponseDTO();
            try
            {
                if (!ModelState.IsValid)
                {
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    _Errors.ForEach(x => { if (x.Exception == null) _Response.Result.AddException(new Exception(x.ErrorMessage)); else _Response.Result.AddException(x.Exception); });
                    return _Response;

                }
                CoreTraxApi _Core = new CoreTraxApi(this._Logger);
                _Response = _Core.FindAhorroByIdUsuario(request.IdUsuario);



            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
            }
            return _Response;
        }

        [HttpPost]
        [Route("AhorrosUsuarios")]
        public ObtenerListadoUsuariosResponseDTO ListadoUsuariosAhorro()
        {
            ObtenerListadoUsuariosResponseDTO response = new ObtenerListadoUsuariosResponseDTO();
            try
            {
                if (!ModelState.IsValid)
                {
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    response.Result.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    _Errors.ForEach(x => { if (x.Exception == null) response.Result.AddException(new Exception(x.ErrorMessage)); else response.Result.AddException(x.Exception); });
                    return response;
                }
                CoreTraxApi _Core = new CoreTraxApi(this._Logger);
                response = _Core.ListUsuariosAhorro();
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                response.Result.AddException(ex);

            }
            return response;
        }


    }
}