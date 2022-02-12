using IpAddressApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using IpAddressApi.Errors;

namespace IpAddressApi.Services
{
    public interface IIpAddressSearchService
    {
        Task<OneOf<IpAddressResult, IpAddressValidationError>> SearchByIpAddressAsync(IpAddressRequest request);
    }
}
