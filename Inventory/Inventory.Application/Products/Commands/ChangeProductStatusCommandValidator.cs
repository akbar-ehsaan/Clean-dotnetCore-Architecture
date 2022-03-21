using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Products.Commands
{
    public class ChangeProductStatusCommandValidator : AbstractValidator<ChangeProductStatusCommand>
    {
        public ChangeProductStatusCommandValidator()
        {
            RuleFor(v => v.ProductId)
           .NotEmpty().WithMessage("productId is required.");
            RuleFor(v => v.ProductStatus)
           .NotEmpty().WithMessage("product Status is required.");

        }

    }
}
