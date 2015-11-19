using System;
using System.Linq;

namespace Blog.ReactiveReadModels.Account
{
    public static class Functions
    {
        public static ReadModel WithAccountName(this ReadModel readModel, string accountName)
        {
            return new ReadModel(readModel.Id, accountName, readModel.DeliveryAddresses, readModel.BillingAddresses, readModel.OrderHistory, readModel.CurrentOrders);
        }

        public static ReadModel WithBillingAddress(this ReadModel readModel, Address address)
        {
            return new ReadModel(readModel.Id, readModel.Name, readModel.DeliveryAddresses, readModel.BillingAddresses.Concat(new[] { address }), readModel.OrderHistory, readModel.CurrentOrders);
        }

        public static ReadModel WithoutBillingAddress(this ReadModel readModel, string addressName)
        {
            return new ReadModel(readModel.Id, readModel.Name, readModel.DeliveryAddresses, readModel.BillingAddresses.Where(address => !string.Equals(address.Name, addressName, StringComparison.CurrentCultureIgnoreCase)), readModel.OrderHistory, readModel.CurrentOrders);
        }

        public static ReadModel WithCurrentOrder(this ReadModel readModel, Order order)
        {
            return new ReadModel(readModel.Id, readModel.Name, readModel.DeliveryAddresses, readModel.BillingAddresses, readModel.CurrentOrders.Concat(new[] { order }), readModel.OrderHistory);
        }

        public static ReadModel WithCompletedOrder(this ReadModel readModel, Guid orderId)
        {
            return new ReadModel(readModel.Id, readModel.Name, readModel.DeliveryAddresses, readModel.BillingAddresses, readModel.CurrentOrders.Where(order => !orderId.Equals(order.Id)), readModel.OrderHistory.Concat(readModel.CurrentOrders.Where(order => orderId.Equals(order.Id))));
        }

        public static Func<ReadModel, ReadModel> Apply(Event.AccountNameChanged @event)
        {
            return readModel => readModel.WithAccountName(@event.AccountName);
        }

        public static Func<ReadModel, ReadModel> Apply(Event.AddBillingAddress @event)
        {
            return readModel => readModel.WithBillingAddress(new Address(@event.AddressName));
        }

        public static Func<ReadModel, ReadModel> Apply(Event.RemoveBillingAddress @event)
        {
            return readModel => readModel.WithoutBillingAddress(@event.AddressName);
        }

        public static Func<ReadModel, ReadModel> Apply(Event.OrderInvoiced @event)
        {
            return readModel => readModel.WithCurrentOrder(new Order(@event.OrderId));
        }

        public static Func<ReadModel, ReadModel> Apply(Event.OrderDispatched @event)
        {
            return readModel => readModel.WithCompletedOrder(@event.OrderId);
        }

        public static ReadModel ToReadModel(this Service.AccountInfo accountInfo)
        {
            return new ReadModel(accountInfo.Id, accountInfo.Name, Enumerable.Empty<Address>(), Enumerable.Empty<Address>(), Enumerable.Empty<Order>(), Enumerable.Empty<Order>());
        }
    }
}
