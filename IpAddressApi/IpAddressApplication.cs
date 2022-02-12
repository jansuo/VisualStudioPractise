using FluentValidation;
using IpAddressApi.Api;
using IpAddressApi.Models;
using IpAddressApi.Output;
using IpAddressApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OneOf;
using IpAddressApi.Errors;

namespace IpAddressApi
{
    public class IpAddressSearcApplication
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IIpAddressSearchService _ipAddressSearchService;
        
        public IpAddressSearcApplication(
            IOutputWriter outputWriter,
            IIpAddressSearchService ipAddressSearchService)
        {
            _outputWriter = outputWriter;
            _ipAddressSearchService = ipAddressSearchService;
        }

        public async Task RunAsync()
        {
            var request = new IpAddressRequest("84.251.7.29"); // todo parametrina

            var result = await _ipAddressSearchService.SearchByIpAddressAsync(request);
            HandleResult(result);
        }

        private void HandleResult(OneOf<IpAddressResult, IpAddressValidationError> result)
        {
            result.Switch(
                searchResult =>
                {
                    var resultText = JsonSerializer.Serialize(searchResult, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    _outputWriter.WriteLine(resultText);
                },
                error =>
                {
                    var formattedErrors = String.Join(", ", error.Messages);
                    _outputWriter.WriteLine(formattedErrors);
                });
        }
    }
}
