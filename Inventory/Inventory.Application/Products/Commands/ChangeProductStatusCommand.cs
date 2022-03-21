using Inventory.Application.Common.Interfaces;
using Inventory.Domain.Enums;
using Inventory.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Products.Commands
{
    public class ChangeProductStatusCommand : IRequest<int>
    {
        public Guid ProductId { get; set; }
        public ProductStatus ProductStatus { set; get; }
    }
    public class ChangeProductStatusCommandHandler : IRequestHandler<ChangeProductStatusCommand, int>
    {
        private readonly IApplicationContext _context;

        public ChangeProductStatusCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(ChangeProductStatusCommand request, CancellationToken cancellationToken)
        {

            var product = _context.Products.Find(request.ProductId);
            product.ChangeStatus(request.ProductStatus);
            return await _context.SaveChangesAsync(cancellationToken);
            //this event can be sent to kafka or other brokers in microservice architecture
            product.DomainEvents.Add(new ChangeProductStatusEvent(product));

        }
    }
}
