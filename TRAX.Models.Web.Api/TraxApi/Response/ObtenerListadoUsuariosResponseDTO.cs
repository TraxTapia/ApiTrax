using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.TraxApi.Response
{
  public  class ObtenerListadoUsuariosResponseDTO
    {
        public List<AhorroDTO> List { get; set; }
        public string Message { get; set; }
        public bool IsOk { get; set; }
        public OperationResult.OperationResult Result { get; set; }
    }
}
