using System;

namespace Blog.ReactiveReadModels.Event
{
    public class RemoveBillingAddress
    {
        public Guid AccountId { get; private set; }
        public string AddressName { get; internal set; }
    }
}
