namespace DesktopWarrior.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dg_Products")]
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(200)]
        public string Video { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        public int? Stock { get; set; }
    }
}
