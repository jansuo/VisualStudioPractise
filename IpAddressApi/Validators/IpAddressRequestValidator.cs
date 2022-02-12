﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IpAddressApi.Models;

namespace IpAddressApi.Validators
{
    public class IpAddressRequestValidator : AbstractValidator<IpAddressRequest>
    {
        public IpAddressRequestValidator()
        {
            RuleFor(request => request.IpAddress)
                .NotEmpty()
                .Matches(@"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}")
                .WithMessage("Provide a valid ip address");
        }
    }
}
