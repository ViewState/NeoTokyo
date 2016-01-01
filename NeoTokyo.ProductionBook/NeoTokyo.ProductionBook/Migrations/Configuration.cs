using System.Collections.Generic;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ProductionBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ProductionBookContext context)
        {
            var process = new Process { Name = "Preparation", CompletedStatusText = "Prepared", IsOvernightProcess = false };

            context.Processes.AddOrUpdate(n => n.Name, process);

            context.SaveChanges();

            var department = new Department { Active = true, Name = "Large Winding" };

            context.Departments.AddOrUpdate(n => n.Name, department);

            context.SaveChanges();

            var resourceGroup =
                new ResourceGroup { Name = "Small Winding", DepartmentID = department.ID };

            context.ResourceGroups.AddOrUpdate(n => n.Name, resourceGroup);

            context.SaveChanges();

            var staffs = new List<Staff>
            {
                new Staff {FirstName = "Peter", MiddleName = "David", LastName = "Rowley", Active = true},
                new Staff {FirstName = "Kevin", MiddleName = "James", LastName = "Rowley", Active = true},
                new Staff {FirstName = "Mackenzie", MiddleName = String.Empty, LastName = "Johnson", Active = true},
            };

            staffs.ForEach(staff => context.Staffs.AddOrUpdate(s => new { s.FirstName, s.LastName }, staff));

            context.SaveChanges();

            var staffResourceGroupLinks = new List<StaffResourceGroupLink>();

            staffs.ForEach(staff => staffResourceGroupLinks.Add(new StaffResourceGroupLink { ResourceGroupID = resourceGroup.ID, StaffID = staff.ID }));

            staffResourceGroupLinks.ForEach(link => context.StaffResourceGroupLinks.AddOrUpdate(s => s.StaffID, link));

            context.SaveChanges();

            Staff designerStaff = new Staff
            {
                FirstName = "John",
                MiddleName = "David",
                LastName = "Prowse",
                Active = true
            };

            context.Staffs.AddOrUpdate(s => new { s.FirstName, s.LastName }, designerStaff);

            context.SaveChanges();

            Designer designer = new Designer { ID = designerStaff.ID, Active = true };

            context.Designers.AddOrUpdate(d => d.ID, designer);

            context.SaveChanges();

            Design design = new Design
            {
                Active = true,
                Created = DateTime.Now,
                DesignNumber = "Design1",
                DesignerID = designer.ID,
            };

            context.Designs.AddOrUpdate(n=>n.DesignNumber, design);

            context.SaveChanges();
        }
    }
}
