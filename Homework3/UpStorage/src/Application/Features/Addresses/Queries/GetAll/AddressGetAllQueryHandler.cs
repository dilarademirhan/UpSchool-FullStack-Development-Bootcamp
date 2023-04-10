using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetAll
{
    public class AddressGetAllQueryHandler : IRequestHandler<AddressGetAllQuery, List<AddressGetAllDto>>
    {
        public readonly IApplicationDbContext _applicationDbContext;

        public AddressGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<AddressGetAllDto>> Handle(AddressGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Addresses.AsQueryable();
            dbQuery = dbQuery.Where(x => x.UserId == request.UserId);

            if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);

            dbQuery = dbQuery.Include(x => x.UserId);
            var addresses = await dbQuery.ToListAsync(cancellationToken);
            var addressDtos = MapAddressToGetAllDto(addresses);
            return addressDtos.ToList();
        }

        private IEnumerable<AddressGetAllDto> MapAddressToGetAllDto(List<Address> addresses)
        {
            List<AddressGetAllDto> addressGetAllDtos = new List<AddressGetAllDto>();
            foreach(var address in addresses)
            {
                yield return new AddressGetAllDto()
                {
                    Id = address.Id,
                    Name = address.Name,
                    UserId = address.UserId,
                    CountryId = address.CountryId,
                    Country = address.Country,
                    CityId = address.CityId,
                    City = address.City,
                    District = address.District,
                    PostCode = address.PostCode,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    AddressType = address.AddressType
                };
            }
        }
    }
}
