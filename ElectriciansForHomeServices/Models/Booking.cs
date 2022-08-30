namespace ElectriciansForHomeServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int BookingID { get; set; }

        public int? UserFID { get; set; }

        public int? ElectricianFID { get; set; }

        [Column(TypeName = "date")]
        public DateTime BookingDate { get; set; }

        public TimeSpan? BookingTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime WorkStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime WorkEndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        public virtual Electrician Electrician { get; set; }

        public virtual User User { get; set; }
    }
}
