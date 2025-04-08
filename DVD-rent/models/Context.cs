using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DVD_rent.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=mycs") { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Pledge> Pledges { get; set; }
        public DbSet<DVD> DVDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DVD>()
                .HasMany(m => m.Movies)
                .WithMany(d => d.DVDs)
                .Map(m =>
                {
                    m.ToTable("MovieDVDs");
                    m.MapLeftKey("DVDID");
                    m.MapRightKey("MoiveID");
                });

            modelBuilder.Entity<Rent>()
                .HasKey(t => t.PledgeId);

            modelBuilder.Entity<Pledge>()
                .HasOptional(r => r.Rent)
                .WithOptionalPrincipal(p => p.Pledge);

            base.OnModelCreating(modelBuilder);
        }
    }

    
}

