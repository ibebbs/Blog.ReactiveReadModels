using System;

namespace Blog.ReactiveReadModels.Event
{
    public class AddBillingAddress
    {
        public Guid AccountId { get; private set; }
        public string AddressName { get; internal set; }
    }
}
