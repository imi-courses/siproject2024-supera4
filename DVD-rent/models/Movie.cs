using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVD_rent.models;

namespace DVD_rent.models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        
    }
}
