using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    [Table("Brands", Schema = "Cat")]
    public class Brand
    {
        #region Attributes    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string BrandName { get; set; }        
        public DateTime Created { get; set; }
        #endregion

        #region Builder
        public Brand()
        {
            this.Created = DateTime.Now;
        }
        #endregion
    }
}