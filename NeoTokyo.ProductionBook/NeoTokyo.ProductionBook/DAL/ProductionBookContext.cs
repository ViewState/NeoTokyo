using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.DAL
{
    public class ProductionBookContext : DbContext
    {
        public ProductionBookContext() : base("ProductionBookContext")
        { }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffResourceGroupLink> StaffResourceGroupLinks { get; set; }
        public DbSet<ResourceGroup> ResourceGroups { get; set; }
        public DbSet<Designer> Designers { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<Process> Processes { get; set; } 
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; } 
        public DbSet<Design> Designs { get; set; }
        public DbSet<DesignProcess> DesignProcesses { get; set; } 
        public DbSet<Customer> Customers { get; set; }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<StaffResourceGroupLink>().HasKey(s => s.StaffID);
            modelBuilder.Entity<Designer>().HasKey(s => s.ID);
            modelBuilder.Entity<Staff>().HasOptional(staff => staff.StaffResourceGroupLink).WithRequired(link => link.Staff);
            modelBuilder.Entity<Staff>().HasOptional(staff => staff.Designer).WithRequired(link => link.Staff);
        }
    }
}