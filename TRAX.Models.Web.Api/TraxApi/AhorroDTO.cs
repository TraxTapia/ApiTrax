using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.TraxApi
{
   public class AhorroDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCobro { get; set; }
       
    }
}
