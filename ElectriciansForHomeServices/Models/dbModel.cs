using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ElectriciansForHomeServices.Models
{
    public partial class dbModel : DbContext
    {
        public dbModel()
            : base("name=dbModel")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Electrician> Electricians { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Electricians)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CatFID);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Electricians)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.CItyFID);

            modelBuilder.Entity<Electrician>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Electrician>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.Electrician)
                .HasForeignKey(e => e.ElectricianFID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserFID)
                .WillCascadeOnDelete();
        }
    }
}
