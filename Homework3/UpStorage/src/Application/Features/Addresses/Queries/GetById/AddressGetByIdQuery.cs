using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetById
{
    public class AddressGetByIdQuery : IRequest<AddressGetByIdDto>
    {
        public int Id { get; set; }
        public AddressGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
