using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.TraxApi.Request.RequestCajaAhorro
{
   public  class UsuariosRequestDTO
    {
        [Required]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]

        public string Nombre { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]

        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]

        public string ApellidoMaterno { get; set; }
    }
}
