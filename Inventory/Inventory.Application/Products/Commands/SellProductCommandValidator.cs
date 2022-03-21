using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Products.Commands
{
    public class SellProductCommandValidator : AbstractValidator<SellProductCommand>
    {
        public SellProductCommandValidator()
        {
            RuleFor(v => v.ProductId)
           .NotEmpty().WithMessage("productId is required.");

       

            RuleFor(x => x.ProductId.ToString())
                .Must(Validate).WithErrorCode("ProductId is not a guid");
        }
        private bool Validate(string bar)
        {
            return Guid.TryParse(bar, out var result);
        }
    }
}
