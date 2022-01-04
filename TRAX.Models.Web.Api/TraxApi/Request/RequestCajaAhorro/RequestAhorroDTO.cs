using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.TraxApi.Request.RequestCajaAhorro
{
 public  class RequestAhorroDTO
    {
        public int IdUsuario { get; set; } 
        public decimal Cantidad { get; set; } 
        public decimal Total { get; set; } 
        public DateTime FechaCobro { get; set; } 
    }
}
