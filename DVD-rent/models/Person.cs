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
    public abstract class Person
    {
        [MaxLength(100)]
        public string FullName { get; set; }
    }
}
