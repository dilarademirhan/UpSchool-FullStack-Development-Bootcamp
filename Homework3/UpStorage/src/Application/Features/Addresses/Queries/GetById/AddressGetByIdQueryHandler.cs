// using Application.Common.Interfaces;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// namespace Application.Features.Addresses.Queries.GetById
// {
//     public class AddressGetByIdQueryHandler : IRequestHandler<AddressGetByIdQuery, AddressGetByIdDto>
//     {
//         private readonly IApplicationDbContext _applicationDbContext;

//         public AddressGetByIdQueryHandler(IApplicationDbContext applicationDbContext)
//         {
//             _applicationDbContext = applicationDbContext;
//         }
    
//         public async Task<AddressGetByIdDto> Handle(AddressGetByIdQuery request, CancellationToken cancellationToken)
//         {
//             var address = await _applicationDbContext.Addresses.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
//             return address;
//         }
//     }
// }
