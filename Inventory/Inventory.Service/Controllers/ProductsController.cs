using Inventory.Application.Products.Commands;
using Inventory.Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Inventory.Application.Products.Queries.ProductCountStatusQueryHandler;

namespace Inventory.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ApiControllerBase
    {
        [HttpPost("Sell")]
        public async Task<ActionResult<int>> Sell(SellProductCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("ChangeStatus")]
        public async Task<ActionResult<int>> ChangeStatus(ChangeProductStatusCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("CountStatus")]
        public async Task<ActionResult<ProductCountQueryResponse>> Count(ProductCountStatusQuery command)
        {
            return await Mediator.Send(command);
        }
    }
}
