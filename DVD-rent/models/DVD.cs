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
    public class DVD
    {
        [MaxLength(100)]
        public int quantity { get; set; }
        public float price { get; set; }
    }
}
