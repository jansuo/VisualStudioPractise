using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddressApi.Models
{
    public record IpAddressResult
    {
        public string City { get; set; }
        public string Country { get; set; } 
    }
}
