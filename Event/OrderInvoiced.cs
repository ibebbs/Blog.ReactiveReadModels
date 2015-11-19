using System;

namespace Blog.ReactiveReadModels.Event
{
    public class OrderInvoiced
    {
        public Guid AccountId { get; private set; }
        public Guid OrderId { get; private set; }
    }
}
