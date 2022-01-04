using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Models.Web.Api.Models.BDCajaAhorro;

namespace TRAX.Models.Web.Api.Models.BDContext
{
    public partial class CajaAhorro : DbContext
    {
        public CajaAhorro(): base("name=CajaAhorro")
        {
            this.Database.CommandTimeout = 180;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Ahorro> Ahorro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ApellidoPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ApellidoMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ahorro)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Id_Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
