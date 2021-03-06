﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

                #region tsp
                var tspHome = new SubMenuItem() { Name = "Home", SubSystem = tsp, Order = 1 };
                var tspTeam = new SubMenuItem() { Name = "Our Team", SubSystem = tsp, Order = 2 };
                var tspGallery = new SubMenuItem() { Name = "Gallery", SubSystem = tsp, Order = 3 };
                var tspUs = new SubMenuItem() { Name = "About us", SubSystem = tsp, Order = 4 };
                var tspProject = new SubMenuItem() { Name = "Current Project", SubSystem = tsp, Order = 5 };

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
                        Title = "COMMERCIAL",
                        Paragraph = "Building from start to finish",
                        Image = "http://www.tspconstruction.co.nz/images/Commercial-homeimage.jpg",
                        SubMenuItem = tspHome,
                        Order = 1
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "RESIDENTIAL",
                        Paragraph = "Stunning homes built with pride",
                        Image = "http://www.tspconstruction.co.nz/images/Residential-homeimage.jpg",
                        SubMenuItem = tspHome,
                        Order = 2
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Others",
                        Paragraph = "Something",
                        Image = "http://www.tspconstruction.co.nz/images/Commercial-homeimage.jpg",
                        SubMenuItem = tspHome,
                        Order = 3
                    });

                    // our team
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Meet the TSP Construction Team",
                        Paragraph = "Building from start to finish",
                        Image = "",
                        SubMenuItem = tspTeam,
                        Order = 1
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Client Testimonial",
                        Paragraph = "We employed TSP Construction in September 2009 to build our house at Waitarere Beach Rd,Levin.From the start when we were looking over the plans I found Todd and Natalie extremely professional.",
                        Image = "http://www.tspconstruction.co.nz/images/Test1.jpg",
                        SubMenuItem = tspTeam,
                        Order = 2
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Client Testimonial",
                        Paragraph = "Todd, from TSP Construction, built our beach house.  He workedclosely with us and our architect during the building process. Todd and his buildingcrew were hardworking and exacting in their detail and finish, resulting in a high end architectural house we look forward to spending many years in.",
                        Image = "http://www.tspconstruction.co.nz/images/Test3.jpg",
                        SubMenuItem = tspTeam,
                        Order = 3
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Client Testimonial",
                        Paragraph = "Two years on we are still delighted with our house, and it has certainly met the lifestyle needs we identified when it was first designed for us.",
                        Image = "http://www.tspconstruction.co.nz/images/Test2.jpg",
                        SubMenuItem = tspTeam,
                        Order = 4
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "TSP Construction Team Fishing Trip - October 2014.",
                        Paragraph = "Left to right : Brendon, Jimmy, Mark, Dane, unknown, Jay, James, Dennis, Maika, John, Matt, Alinka, Mike & Raz.",
                        Image = "http://www.tspconstruction.co.nz/images/TSP-Team-2014.jpg",
                        SubMenuItem = tspTeam,
                        Order = 5
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Graduation evening where the boys received their acknowledgement of achievement from H.D.C. ",
                        Paragraph = "From left to right; Todd (TSP Construction owner), Ronan (BCITO Area Manager), Michael (absent), David, Manu and Mark(Training Accessor).",
                        Image = "http://www.tspconstruction.co.nz/images/TSPConstruction-TeamBCITO.jpg",
                        SubMenuItem = tspTeam,
                        Order = 6
                    });
                    //gallery
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Commercial - Mitre 10 Porirua",
                        Image = "http://www.tspconstruction.co.nz/images/mitre1sm.jpg",
                        Paragraph = "",
                        SubMenuItem = tspGallery,
                        Order = 1
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "Commercial - Mitre 10 Porirua",
                        Image = "http://www.tspconstruction.co.nz/images/mitre2.jpg",
                        Paragraph = "",
                        SubMenuItem = tspGallery,
                        Order = 2
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "New Home - Beach House",
                        Image = "http://www.tspconstruction.co.nz/images/BeachHouse1sm.jpg",
                        Paragraph = "",
                        SubMenuItem = tspGallery,
                        Order = 1
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "New Home - Beach House",
                        Image = "http://www.tspconstruction.co.nz/images/BeachHouse1.1.jpg",
                        Paragraph = "",
                        SubMenuItem = tspGallery,
                        Order = 2
                    });
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "New Home - Beach House",
                        Image = "http://www.tspconstruction.co.nz/images/BeachHouse1.2.jpg",
                        Paragraph = "",
                        SubMenuItem = tspGallery,
                        Order = 3
                    });
                    // current project
                    context.SubItemDetails.Add(new SubItemDetail()
                    {
                        Title = "TSP Construction's Current Project",
                        Image = "http://www.tspconstruction.co.nz/images/masonic1sm.jpg",
                        Paragraph = "Masonic Lodge - 63 Wai Iti Cres Woburn",
                        SubMenuItem = tspProject,
                        Order = 1
                    });
                }
                #endregion

                #region green
                var greenHome = new SubMenuItem() { Name = "Home", SubSystem = green, Order = 1 };
                var greenPlan = new SubMenuItem() { Name = "Our Plan", SubSystem = green, Order = 2 };
                var greenSpecification = new SubMenuItem() { Name = "Our specification", SubSystem = green, Order = 3 };
                var greenFyq = new SubMenuItem() { Name = "FYQ", SubSystem = green, Order = 4 };
                var greenCase = new SubMenuItem() { Name = "Case studies", SubSystem = green, Order = 5 };
                var greenForSale = new SubMenuItem() { Name = "Homes For sale", SubSystem = green, Order = 6 };
                var greenGallery = new SubMenuItem() { Name = "Gallery", SubSystem = green, Order = 7 };
                var greenAbout = new SubMenuItem() { Name = "About", SubSystem = green, Order = 8 };
                var greenNews = new SubMenuItem() { Name = "News", SubSystem = green, Order = 9 };
                var greenUs = new SubMenuItem() { Name = "Contac us", SubSystem = green, Order = 10 };

                if (!context.SubMenuItems.Any())
                {
                    context.SubMenuItems.Add(greenHome);
                    context.SubMenuItems.Add(greenPlan);
                    context.SubMenuItems.Add(greenSpecification);
                    context.SubMenuItems.Add(greenFyq);
                    context.SubMenuItems.Add(greenCase);

                    context.SubMenuItems.Add(greenForSale);
                    context.SubMenuItems.Add(greenGallery);
                    context.SubMenuItems.Add(greenAbout);
                    context.SubMenuItems.Add(greenNews);
                    context.SubMenuItems.Add(greenUs);
                }
                
                #endregion
            }
            if (!context.SubItemDetails.Any())
            {
                var root = Directory.GetCurrentDirectory();
                using (StreamReader r = File.OpenText(@$"{root}\\Data\\details.json"))
                {
                    string json = r.ReadToEnd();
                    List<SubItemDetail> list = JsonConvert.DeserializeObject<List<SubItemDetail>>(json);
                    context.SubItemDetails.AddRange(list);
                }
            }
            context.SaveChanges();
        }
    }
}
