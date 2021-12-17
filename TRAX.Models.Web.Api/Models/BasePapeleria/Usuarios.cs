namespace TRAX.Models.Web.Api.Models.BDContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string APaterno { get; set; }

        [Required]
        [StringLength(250)]
        public string AMaterno { get; set; }

        public int IdRol { get; set; }

        public bool Activo { get; set; }
    }
}
