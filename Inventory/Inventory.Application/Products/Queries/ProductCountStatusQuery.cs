using Inventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Inventory.Application.Products.Queries.ProductCountStatusQueryHandler;

namespace Inventory.Application.Products.Queries
{
    public class ProductCountStatusQuery : IRequest<ProductCountQueryResponse>
    {

    }

    public class ProductCountStatusQueryHandler : IRequestHandler<ProductCountStatusQuery, ProductCountQueryResponse>
    {
        private readonly IApplicationContext _context;

        public ProductCountStatusQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ProductCountQueryResponse> Handle(ProductCountStatusQuery request, CancellationToken cancellationToken)
        {

            var results = _context.Products.GroupBy(
        p => p.Status,(key, g) => new  { status = key, count = g.Count() });

            return new ProductCountQueryResponse()
            {
                DamagedCount = results.Where(i => i.status == Domain.Enums.ProductStatus.Damaged).First().count,
                SoldCount = results.Where(i => i.status == Domain.Enums.ProductStatus.Sold).First().count
            };

        }
        public class ProductCountQueryResponse
        {
            public int SoldCount { set; get; }
            public int DamagedCount { set; get; }
        }
    }
}
