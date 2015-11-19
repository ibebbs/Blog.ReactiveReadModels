using System;

namespace Blog.ReactiveReadModels.Event
{
    public class RemoveDeliveryAddress
    {
        public Guid AccountId { get; private set; }
        public string AddressName { get; private set; }
    }
}
