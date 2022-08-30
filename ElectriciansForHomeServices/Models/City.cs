namespace ElectriciansForHomeServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Electricians = new HashSet<Electrician>();
        }

        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City Name")]

        public string Name { get; set; }

        public string Picture { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Electrician> Electricians { get; set; }
    }
}
