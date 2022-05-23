using System;
using System.Data.Entity;
using System.Linq;

namespace Cotizador.Models
{
    public class DBCotizador : DbContext
    {
        #region Attributes
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Mdoels { get; set; }
        public DbSet<Year> Years { get; set; }
        #endregion

        #region builder
        public DBCotizador()
            : base("name=Cotizador")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);            

            builder.Entity<Model>().HasRequired(x => x.Brand);
            builder.Entity<Year>().HasRequired(x => x.Model);            

        }
        #endregion
    }
}