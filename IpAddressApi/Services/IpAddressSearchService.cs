using IpAddressApi.Api;
using IpAddressApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpAddressApi.Mappings;
using FluentValidation;
using OneOf;
using IpAddressApi.Errors;
using System.Linq;

namespace IpAddressApi.Services
{
    public class IpAddressSearchService : IIpAddressSearchService
    {
        private readonly IIpAddressApi _ipAddressApi;
        private readonly IValidator<IpAddressRequest> _validator;

        public IpAddressSearchService(IIpAddressApi ipAddressApi, IValidator<IpAddressRequest> validator)
        {
            _ipAddressApi = ipAddressApi;
            _validator = validator;
        }

        public async Task<OneOf<IpAddressResult, IpAddressValidationError>> SearchByIpAddressAsync(IpAddressRequest request)
        {
            // validate
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errorMessages = (from obj in validationResult.Errors select obj.ErrorMessage).ToList(); 
                return new IpAddressValidationError
                {
                    Messages = errorMessages
                };
            }

            // call api and map result
            var response = await _ipAddressApi.SearchByIpAddress(request.IpAddress);
            var result = response.ToIpAddressResult();
            return result;  
        }
    }
}
