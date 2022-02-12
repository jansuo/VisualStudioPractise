using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddressApi.Errors
{
    public struct IpAddressValidationError
    {
        public IReadOnlyList<string> Messages { get; init; }
    }
}
