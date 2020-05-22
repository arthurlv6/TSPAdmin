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

            var tsp = new SubSystem { Name = "TSP Construction" };
            var green = new SubSystem { Name = "Green Haven Home" };
            var rev = new SubSystem { Name = "Revlution" };

            if (!context.SubSystems.Any())
            {
                context.SubSystems.Add(tsp);
                context.SubSystems.Add(green);
                context.SubSystems.Add(rev);
            }
            var tspHome = new SubMenuItem() { Name="Home", SubSystem=tsp };
            var tspTeam = new SubMenuItem() { Name = "Our Team", SubSystem = tsp };
            var tspGallery = new SubMenuItem() { Name = "Gallery", SubSystem = tsp };
            var tspUs = new SubMenuItem() { Name = "About us", SubSystem = tsp };
            var tspProject = new SubMenuItem() { Name = "Current Project", SubSystem = tsp };

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
                    SubMenuItem=tspHome
                });
                context.SubItemDetails.Add(new SubItemDetail()
                {
                    Title = "RESIDENTIAL",
                    Paragraph = "Stunning homes built with pride",
                    Image = "http://www.tspconstruction.co.nz/images/Residential-homeimage.jpg",
                    SubMenuItem = tspHome
                });
                context.SubItemDetails.Add(new SubItemDetail()
                {
                    Title = "Others",
                    Paragraph = "Building from start to finish",
                    Image = "http://www.tspconstruction.co.nz/images/Commercial-homeimage.jpg",
                    SubMenuItem = tspHome
                });
            }
            context.SaveChanges();
        }
    }
}
