using Inventory.Application.Common.Exceptions;
using Inventory.Application.Common.Interfaces;
using Inventory.Domain.Entities;
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
    public class SellProductCommand: IRequest<int>
    {
        public Guid ProductId { get; set; }
    }
    public class SellProductCommandHandler : IRequestHandler<SellProductCommand, int>
    {
        private readonly IApplicationContext _context;

        public SellProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SellProductCommand request, CancellationToken cancellationToken)
        {

            var product = _context.Products.Find(request.ProductId);
            if (product == null) throw new NotFoundException(product.GetType().ToString(),request.ProductId);
            product.Sell();
            return  await _context.SaveChangesAsync(cancellationToken);
            //this event can be sent to kafka or other brokers in microservice architecture
            product.DomainEvents.Add(new SellProductEvent(product));


        }
    }
}
