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

        public static ReadModel ToReadModel(this Service.AccountInfo accountInfo)
        {
            return new ReadModel(accountInfo.Id, accountInfo.Name, Enumerable.Empty<Address>(), Enumerable.Empty<Address>(), Enumerable.Empty<Order>(), Enumerable.Empty<Order>());
        }
    }
}
