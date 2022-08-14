using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quest4pet.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAccessory> tblAccessories { get; set; }
        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblDoctor> tblDoctors { get; set; }
        public virtual DbSet<tblFeedback> tblFeedbacks { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderProduct> tblOrderProducts { get; set; }
        public virtual DbSet<tblPet> tblPets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAccessory>()
                .HasMany(e => e.tblFeedbacks)
                .WithOptional(e => e.tblAccessory)
                .HasForeignKey(e => e.Accessories_FID);

            modelBuilder.Entity<tblAccessory>()
                .HasMany(e => e.tblOrderProducts)
                .WithOptional(e => e.tblAccessory)
                .HasForeignKey(e => e.Accessories_FID);

            modelBuilder.Entity<tblCategory>()
                .HasMany(e => e.tblPets)
                .WithRequired(e => e.tblCategory)
                .HasForeignKey(e => e.Category_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblFeedbacks)
                .WithRequired(e => e.tblCustomer)
                .HasForeignKey(e => e.Customer_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOrder>()
                .HasMany(e => e.tblOrderProducts)
                .WithRequired(e => e.tblOrder)
                .HasForeignKey(e => e.Order_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPet>()
                .HasMany(e => e.tblFeedbacks)
                .WithOptional(e => e.tblPet)
                .HasForeignKey(e => e.Pets_FID);

            modelBuilder.Entity<tblPet>()
                .HasMany(e => e.tblOrderProducts)
                .WithOptional(e => e.tblPet)
                .HasForeignKey(e => e.Pets_FID);
        }
    }
}
