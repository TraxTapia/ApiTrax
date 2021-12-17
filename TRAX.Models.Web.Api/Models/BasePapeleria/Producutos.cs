namespace TRAX.Models.Web.Api.Models.BDContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Producutos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreProducto { get; set; }

        public decimal PrecioUnidadCompra { get; set; }

        public decimal PrecioUnidadVenta { get; set; }

        public long Stock { get; set; }

        public bool Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
