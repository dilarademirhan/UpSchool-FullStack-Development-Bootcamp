using Application.Common.Interfaces;
using Application.Features.Addresses.Commands.Add;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Add
{
    public class AddressAddCommandHandler : IRequestHandler<AddressAddCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<int>> Handle(AddressAddCommand request, CancellationToken cancellationToken)
        {
            var Address = new Address()
            {
                Name = request.Name,
                UserId = request.UserId,
                CountryId = request.CountryId,
                CityId = request.CityId,
                District = request.District,
                PostCode = request.PostCode,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                AddressType = request.AddressType,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
                IsDeleted = false,
            };

            await _applicationDbContext.Addresses.AddAsync(Address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The new address named \"{Address.Name}\" was successfully added.", Address.Id);
        }
    }
}
