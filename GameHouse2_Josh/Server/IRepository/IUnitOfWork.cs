using GameHouse2_Josh.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<ShippingAddress> ShippingAddresses { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<GamingProduct> GamingProducts { get; }
    }
}
