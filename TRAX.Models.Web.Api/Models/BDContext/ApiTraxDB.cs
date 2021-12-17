using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TRAX.Models.Web.Api.Models.BDContext
{
    public partial class ApiTraxDB : DbContext
    {
        public ApiTraxDB() : base("name=ApiTraxDB")
        {
            this.Database.CommandTimeout = 180;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Producutos> Producutos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producutos>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.APaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.AMaterno)
                .IsUnicode(false);
        }
    }
}
