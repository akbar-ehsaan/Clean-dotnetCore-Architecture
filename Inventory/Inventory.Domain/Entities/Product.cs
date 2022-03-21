using Inventory.Domain.Common;
using Inventory.Domain.Enums;
using Inventory.Domain.Exceptions;
using Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Product
    {
        public Guid Id { get;private set; }
        public string Name { get; private set; }
        public Barcode? Barcode { get; private set; }
        public string Description { get; private set; }
        public Weight? Weight { get; private set; }
        public ProductStatus Status { get; private set; }
        public Category? Category { get; private set; }
        public List<DomainEvent> DomainEvents { get; private set; } = new List<DomainEvent>();
        private Product()
        {

        }
        public Product(string name,Barcode barcode,string description,Weight weight,
            ProductStatus productStatus,Category category)
        {
            this.Id = string.IsNullOrEmpty(Id.ToString()) ? Guid.NewGuid() : Id;
            this.Name = name;
            this.Barcode = barcode;
            this.Description = description;
            this.Weight = weight;
            this.Status = productStatus;
            this.Category = category;
        }
        public void ChangeStatus(ProductStatus newProductStatus)
        {
            this.Status = newProductStatus;
        }
        public void Sell()
        {
            if (this.Status == ProductStatus.InStock)
                this.Status = ProductStatus.Sold;
            else if(this.Status==ProductStatus.Damaged)
            {
                throw new ProductDamageException();
            }
            else if (this.Status == ProductStatus.Sold)
            {
                throw new ProductSoldException();
            }
        }


    }
}
