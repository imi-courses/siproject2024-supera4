using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DVD_rent.models
{
    public class Context : DbContext
    {
        public Context() : base("DVD-rentDB") { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
