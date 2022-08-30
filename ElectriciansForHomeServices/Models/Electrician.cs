namespace ElectriciansForHomeServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Electrician")]
    public partial class Electrician
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Electrician()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int ElecID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Electrician Name")]
        public string Name { get; set; }

        public double Age { get; set; }

        [Required]
        [StringLength(50)]
        public string CNIC { get; set; }

        public string Picture { get; set; }

        public double ExpYears { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public double RatePerDay { get; set; }

        public int CItyFID { get; set; }

        public int CatFID { get; set; }

        public int? Rating { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Category Category { get; set; }

        public virtual City City { get; set; }
    }
}
