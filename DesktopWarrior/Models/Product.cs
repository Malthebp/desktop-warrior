namespace DesktopWarrior.Models
{
    using DesktopWarrior.Models.ViewModels.BuildYourRig;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.ComponentModel;

    [Table("dg_Products")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Types = new HashSet<Type>();
        }

        [Key]
        public int ProductId { get; set; }

        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(200)]
        public string Video { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public decimal Price { get; set; }

        public int? Stock { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type> Types { get; set; }

        public int[] GetCompatibleIds(int catId, Byr byr)
        {
            var ids = new List<int>();

            foreach (var line in byr.Lines)
            {
                foreach (var type in line.Product.Types)
                {
                    ids.Add(type.TypeId);
                }
            }

            return ids.ToArray();
        }
    }
}
