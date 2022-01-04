using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.Models.BDCajaAhorro
{
    [Table("Ahorro")]
    public partial class Ahorro
    {
        [Key]
        public int Id { get; set; }

        public int Id_Usuario { get; set; }

        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha_Cobro { get; set; }

        public bool Activo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
