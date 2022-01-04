using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Models.Web.Api.Models.BDCajaAhorro;

namespace TRAX.Models.Web.Api.TraxApi.Response
{
   public class ObtenerAhorroByUsuarioReponseDTO
    {
        public List<AhorroDTO> List { get; set; }
        public string Message { get; set; }
        public bool IsOk { get; set; }
        public OperationResult.OperationResult Result { get; set; }

    }
}
