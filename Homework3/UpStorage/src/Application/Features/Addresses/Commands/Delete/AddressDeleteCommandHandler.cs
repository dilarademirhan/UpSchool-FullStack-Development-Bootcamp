using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressDeleteCommand command, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.Where(a => a.Id == command.Id).FirstOrDefault();

            if (address == null)
            {
                return default;
            }
            else
            {
                address.IsDeleted = true;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return new Response<int>($"The address named \"{address.Name}\" was successfully deleted.", address.Id);
            }
        }
    }
}
