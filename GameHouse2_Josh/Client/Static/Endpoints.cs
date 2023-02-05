using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Client.Static
{
    public static class Endpoints
    {

        private static readonly string Prefix = "api";

        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string ShippingAddressesEndpoint = $"{Prefix}/addresses";
        public static readonly string OrdersEndpoint = $"{Prefix}/orders";
        public static readonly string OrderItemsEndpoint = $"{Prefix}/orderitems";
        public static readonly string PaymentsEndpoint = $"{Prefix}/payments";
        public static readonly string CategoriesEndpoint = $"{Prefix}/categories";
        public static readonly string GamingProductsEndpoint = $"{Prefix}/products";
    }
}
