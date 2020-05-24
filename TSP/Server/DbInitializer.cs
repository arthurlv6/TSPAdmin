using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.Server.Data;
using TSP.Shared;

namespace TSP.Server
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            var tsp = new SubSystem { Name = "TSP Construction", Order=1 };
            var green = new SubSystem { Name = "Green Haven Home", Order=2 };
            var rev = new SubSystem { Name = "Revlution", Order=3 };

            if (!context.SubSystems.Any())
            {
                context.SubSystems.Add(tsp);
                context.SubSystems.Add(green);
                context.SubSystems.Add(rev);
            }
            var tspHome = new SubMenuItem() { Name="Home", SubSystem=tsp, Order=1 };
            var tspTeam = new SubMenuItem() { Name = "Our Team", SubSystem = tsp, Order=2 };
            var tspGallery = new SubMenuItem() { Name = "Gallery", SubSystem = tsp , Order=3};
            var tspUs = new SubMenuItem() { Name = "About us", SubSystem = tsp, Order=4};
            var tspProject = new SubMenuItem() { Name = "Current Project", SubSystem = tsp, Order=5 };

            if (!context.SubMenuItems.Any())
            {
                context.SubMenuItems.Add(tspHome);
                context.SubMenuItems.Add(tspTeam);
                context.SubMenuItems.Add(tspGallery);
                context.SubMenuItems.Add(tspUs);
                context.SubMenuItems.Add(tspProject);
            }
            if (!context.SubItemDetails.Any())
            {
                context.SubItemDetails.Add(new SubItemDetail() 
                { 
                    Title= "COMMERCIAL",
                    Paragraph= "Building from start to finish" ,
                    Image= "http://www.tspconstruction.co.nz/images/Commercial-homeimage.jpg",
                    SubMenuItem=tspHome,
                    Order=1
                });
                context.SubItemDetails.Add(new SubItemDetail()
                {
                    Title = "RESIDENTIAL",
                    Paragraph = "Stunning homes built with pride",
                    Image = "http://www.tspconstruction.co.nz/images/Residential-homeimage.jpg",
                    SubMenuItem = tspHome,
                    Order=2
                });
                context.SubItemDetails.Add(new SubItemDetail()
                {
                    Title = "Others",
                    Paragraph = "Something",
                    Image = "http://www.tspconstruction.co.nz/images/Commercial-homeimage.jpg",
                    SubMenuItem = tspHome,
                    Order=3
                });
            }
            context.SaveChanges();
        }
    }
}
