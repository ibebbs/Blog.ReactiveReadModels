using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.ReactiveReadModels.Account
{
    public class ReadModel
    {
        public ReadModel(
            Guid id, 
            string name, 
            IEnumerable<Address> deliveryAddresses, 
            IEnumerable<Address> billingAddresses,
            IEnumerable<Order> orderHistory,
            IEnumerable<Order> currentOrders)
        {
            Id = id;
            Name = name;
            DeliveryAddresses = deliveryAddresses ?? Enumerable.Empty<Address>();
            BillingAddresses = billingAddresses ?? Enumerable.Empty<Address>();
            OrderHistory = orderHistory ?? Enumerable.Empty<Order>();
            CurrentOrders = currentOrders ?? Enumerable.Empty<Order>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Address> DeliveryAddresses { get; private set; }
        public IEnumerable<Address> BillingAddresses { get; private set; }
        public IEnumerable<Order> OrderHistory { get; private set; }
        public IEnumerable<Order> CurrentOrders { get; private set; }
    }
}
