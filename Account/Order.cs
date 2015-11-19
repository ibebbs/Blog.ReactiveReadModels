using System;

namespace Blog.ReactiveReadModels.Account
{
    public class Order
    {
        public Order(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; internal set; }
    }
}
