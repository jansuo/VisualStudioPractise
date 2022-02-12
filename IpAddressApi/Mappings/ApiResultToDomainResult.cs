

using IpAddressApi.Api.Responses;
using IpAddressApi.Models;

namespace IpAddressApi.Mappings
{
    public static class ApiResultToDomainResult
    {
        public static IpAddressResult ToIpAddressResult(this IpAddressResponse response)
        {
            return new()
            {
                City = response.City,
                Country = response.Country
            };
        }
    }
}
