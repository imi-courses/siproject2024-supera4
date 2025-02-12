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
    public class Client : Person
    {
        [MaxLength(100)]
        public int phoneNumber { get; set; }
        [MaxLength(100)]
        public string address { get; set; }
        public bool inBlackList { get; set; }

    }
}
