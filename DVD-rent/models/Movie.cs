using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVD_rent.Models;

namespace DVD_rent.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
