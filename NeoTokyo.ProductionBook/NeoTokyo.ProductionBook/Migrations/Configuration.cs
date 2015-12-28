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
            var resourceGroup =
                new ResourceGroup { Name = "Small Winding" };

            context.ResourceGroups.AddOrUpdate(n=>n.Name, resourceGroup);

            context.SaveChanges();

            var staffs = new List<Staff>
            {
                new Staff {FirstName = "Peter", MiddleName = "David", LastName = "Rowley", Active = true},
                new Staff {FirstName = "Kevin", MiddleName = "James", LastName = "Rowley", Active = true},
                new Staff {FirstName = "Mackenzie", MiddleName = String.Empty, LastName = "Johnson", Active = true},
            };

            staffs.ForEach(staff => context.Staffs.AddOrUpdate(s=> new { s.FirstName, s.LastName}, staff));

            context.SaveChanges();

            var staffResourceGroupLinks = new List<StaffResourceGroupLink>();

            staffs.ForEach(staff => staffResourceGroupLinks.Add(new StaffResourceGroupLink { ResourceGroupID = resourceGroup.ID, StaffID = staff.ID }));

            staffResourceGroupLinks.ForEach(link => context.StaffResourceGroupLinks.AddOrUpdate(s=>s.StaffID, link));

            context.SaveChanges();
        }
    }
}
