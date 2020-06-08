using TSP.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.Shared;

namespace TSP.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public virtual DbSet<SubSystem> SubSystems { get; set; }
        public virtual DbSet<SubMenuItem> SubMenuItems { get; set; }
        public virtual DbSet<SubItemDetail> SubItemDetails { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
    }
}
