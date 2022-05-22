using System;
using System.Data.Entity;
using System.Linq;

namespace Cotizador.Models
{
    public class DBCotizador : DbContext
    {
        #region Attributes
        public DbSet<Setting> Settings { get; set; }
        #endregion

        #region builder
        public DBCotizador()
            : base("name=Cotizador")
        {
        }
        #endregion
    }
}