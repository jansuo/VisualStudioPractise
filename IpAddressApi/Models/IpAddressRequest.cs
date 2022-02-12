using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddressApi.Models
{
    public struct IpAddressRequest
    {
        public IpAddressRequest(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string IpAddress { get; }
    }
}
