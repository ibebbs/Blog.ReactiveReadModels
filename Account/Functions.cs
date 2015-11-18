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

        public static Func<ReadModel, ReadModel> WithNameChanged(Event.AccountNameChanged @event)
        {
            return readModel => readModel.WithAccountName(@event.AccountName);
        }

        public static ReadModel ToReadModel(this Service.AccountInfo accountInfo)
        {
            return new ReadModel(accountInfo.Id, accountInfo.Name, Enumerable.Empty<Address>(), Enumerable.Empty<Address>(), Enumerable.Empty<Order>(), Enumerable.Empty<Order>());
        }
    }
}
