using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get;  }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
