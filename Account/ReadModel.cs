using System;
using System.Collections.Generic;

namespace Blog.ReactiveReadModels.Account
{
    public class ReadModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Address> DeliveryAddresses { get; private set; }
        public IEnumerable<Address> BillingAddresses { get; private set; }
        public IEnumerable<Order> OrderHistory { get; private set; }
        public IEnumerable<Order> CurrentOrders { get; private set; }
    }
}
