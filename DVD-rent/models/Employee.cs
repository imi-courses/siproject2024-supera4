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
    public class Employee : Person
    {
        public string position { get; set; }
        [MaxLength(100)]
        public string login { get; set; }
        [MaxLength(100)]
        public string password { get; set; }

    }
}