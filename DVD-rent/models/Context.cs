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
    }

    
}

