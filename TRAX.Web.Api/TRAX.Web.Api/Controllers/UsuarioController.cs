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
using TRAX.Models.Web.Api.TraxApi.Request;

namespace TRAX.Web.Api.Controllers
{
    [RoutePrefix("Usuario")]
    public class UsuarioController : ApiController
    {
        private Logger _Logger;

        public UsuarioController()
        {
            this._Logger = new Logger(System.Web.Hosting.HostingEnvironment.MapPath("~/" + Properties.Settings.Default.LogPath));
        }

        [HttpPost]
        [Route("Usuarios")]
        public OperationResult AddUusuarios(UsuarioRequestDTO request)
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
                _Response = _Core.AddUsuario(request.Nombre, request.APaterno, request.AMaterno, request.IdRol);



            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }
    }
}