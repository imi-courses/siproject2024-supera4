using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}

