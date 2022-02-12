using IpAddressApi.Api.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace IpAddressApi.Api
{
    public interface IIpAddressApi
    {
        [Get("/{ipAddress}/geo")]
        Task<IpAddressResponse> SearchByIpAddress(string ipAddress);
    }
}
