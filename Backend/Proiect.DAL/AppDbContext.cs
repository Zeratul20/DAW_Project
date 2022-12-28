using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proiect.DAL.Configurations;
using Proiect.DAL.Entities;
using System;

namespace Proiect.DAL
{
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Designer> Designers { get; set; }
        public DbSet<DesignerAddress> DesignerAddresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DesignerClient> DesignerClients { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<DesignerCollection> DesignerCollections { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DesignerConfiguration());
            modelBuilder.ApplyConfiguration(new DesignerAddressConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new DesignerClientConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new DesignerCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new ClientAddressConfiguration());
        }

        
        public Designer Find(Designer id)
        {
            throw new NotImplementedException();
        }
    }
}
