using System;

namespace Blog.ReactiveReadModels.Event
{
    public class OrderDispatched
    {
        public Guid AccountId { get; private set; }
        public Guid OrderId { get; internal set; }
    }
}
