using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.TraxApi.Response
{
    public class UsuariosResponseDTO
    {
        public UsuariosResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
        }

        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }
        public OperationResult.OperationResult Result { get; set; }

    }
}
