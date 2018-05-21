namespace DesktopWarrior.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.ComponentModel;

    [Table("dg_Specifications")]
    public partial class Specification
    {
        [Key]
        public int SpecificationId { get; set; }

        public int? ProductId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
