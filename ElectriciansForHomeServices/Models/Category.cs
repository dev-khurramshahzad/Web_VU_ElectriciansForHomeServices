namespace ElectriciansForHomeServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Electricians = new HashSet<Electrician>();
        }

        [Key]
        public int CatID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]

        public string Name { get; set; }

        [StringLength(50)]
        public string Details { get; set; }

        public string Picture { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Electrician> Electricians { get; set; }
    }
}
