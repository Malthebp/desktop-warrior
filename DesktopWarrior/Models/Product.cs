namespace DesktopWarrior.Models
{
    using DesktopWarrior.Models.ViewModels.BuildYourRig;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        public int[] GetCompatibleIds (int catId, Byr byr, List<Category> categories)
        {
            var ids = new int[0];
            switch (catId)
            {
                case 1:
                    ids = GetCpuTypes(catId, byr);
                    break;
                case 2:
                    ids = GetCpuCoolerTypes(catId, byr);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;

            }
            return ids;
        }

        private int[] GetCpuCoolerTypes(int catId, Byr byr)
        {
            var productMb = byr.GetProductInLineByCategoryId(3);
            var productCpu = byr.GetProductInLineByCategoryId(1);
            var ids = new int[0];
            if (productMb != null && productCpu != null)
            {
                var mbIds = productMb.Types.Select(x => x.TypeId).ToArray();
                var cpuIds = productCpu.Types.Select(x => x.TypeId).ToArray();
                ids = mbIds.Concat(cpuIds).ToArray();
            } else if (productMb != null)
            {
                ids = productMb.Types.Select(x => x.TypeId).ToArray();
            } else if (productCpu != null)
            {
                ids = productCpu.Types.Select(x => x.TypeId).ToArray();
            }

            return ids;
        }

        private int[] GetCpuTypes (int catId, Byr byr)
        {
            var product = byr.GetProductInLineByCategoryId(3);
            var ids = new int[0];

            if(product != null)
            {
                ids = product.Types.Select(x => x.TypeId).ToArray();
            }

            return ids;
        }
    }
}
