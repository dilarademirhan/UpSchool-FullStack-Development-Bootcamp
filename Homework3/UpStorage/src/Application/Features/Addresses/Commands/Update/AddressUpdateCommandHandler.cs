using Application.Common.Interfaces;
using Application.Features.Addresses.Commands.Delete;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Addresses.Commands.Update
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<int>> Handle(AddressUpdateCommand command, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.Where(a => a.Id == command.Id).FirstOrDefault();

            if (address == null)
            {
                return default;
            }
            else
            {
                address.Name = command.Name;
                address.UserId = command.UserId;
                address.CountryId = command.CountryId;
                address.CityId = command.CityId;
                address.District = command.District;
                address.PostCode = command.PostCode;
                address.AddressLine1 = command.AddressLine1;
                address.AddressLine2 = command.AddressLine2;
                address.AddressType = command.AddressType;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return new Response<int>($"The new address named \"{address.Name}\" was successfully added.", address.Id);
            }
        }
    } 
}
