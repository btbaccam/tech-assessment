using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pizza { get; set; }
        public string Cost { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
