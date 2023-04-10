using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressHardDeleteCommandHandler : IRequestHandler<AddressHardDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressHardDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressHardDeleteCommand command, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
            _applicationDbContext.Addresses.Remove(address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<int>($"The address named \"{address.Name}\" was successfully deleted.", address.Id);
        }
    }
}
