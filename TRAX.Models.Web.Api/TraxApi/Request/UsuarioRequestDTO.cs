using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.TraxApi.Request
{
   public class UsuarioRequestDTO
    {

        [Required]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]
        public string APaterno { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]
        public string AMaterno { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Se encontraron valores negativos en la moneda")]

        public int IdRol { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Se encontraron valores negativos en la moneda")]

        public bool Activo { get; set; }
    }
}
