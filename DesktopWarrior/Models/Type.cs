namespace DesktopWarrior.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dg_Types")]
    public partial class Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type()
        {
            dg_Types1 = new HashSet<Type>();
        }

        [Key]
        public int TypeId { get; set; }

        public int? CategoryId { get; set; }

        public int? SpecificationId { get; set; }

        public int? ParentId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual Category dg_Categories { get; set; }

        public virtual Specification dg_Specifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type> dg_Types1 { get; set; }

        public virtual Type dg_Types2 { get; set; }
    }
}
