using System;
using System.Collections.Generic;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.DAL
{
    public class ProductionBookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductionBookContext>
    {
        protected override void Seed(ProductionBookContext context)
        {
            var resourceGroup =
                new ResourceGroup { Name = "Small Winding" };

            context.ResourceGroups.Add(resourceGroup);

            var staffs = new List<Staff>
            {
                new Staff {FirstName = "Peter", MiddleName = "David", LastName = "Rowley", Active = true},
                new Staff {FirstName = "Kevin", MiddleName = "James", LastName = "Rowley", Active = true},
                new Staff {FirstName = "Mackenzie", MiddleName = String.Empty, LastName = "Johnson", Active = true},
            };

            staffs.ForEach(staff => context.Staffs.Add(staff));

            var staffResourceGroupLinks = new List<StaffResourceGroupLink>();

            staffs.ForEach(staff => staffResourceGroupLinks.Add(new StaffResourceGroupLink { ResourceGroupID = resourceGroup.ID, StaffID = staff.ID }));

            staffResourceGroupLinks.ForEach(link => context.StaffResourceGroupLinks.Add(link));

            context.SaveChanges();
        }
    }
}