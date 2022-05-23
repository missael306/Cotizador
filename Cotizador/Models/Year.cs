using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    [Table("Years", Schema = "Cat")]
    public class Year
    {
        #region Attributes    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string YearName { get; set; }

        public DateTime Created { get; set; }
        #endregion

        #region Relationships
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        #endregion

        #region Builder
        public Year()
        {
            this.Created = DateTime.Now;
        }
        #endregion
    }
}