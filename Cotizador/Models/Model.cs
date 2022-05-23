using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    [Table("Models", Schema = "Cat")]
    public class Model
    {
        #region Attributes    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
            
        [Required]
        [StringLength(150)]
        public string ModelName { get; set; }

        public DateTime created { get; set; }
        #endregion

        #region Relationships
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        #endregion

        #region Builder
        public Model()
        {
            this.created = DateTime.Now;
        }
        #endregion
    }
}