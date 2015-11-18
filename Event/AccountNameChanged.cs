using System;

namespace Blog.ReactiveReadModels.Event
{
    public class AccountNameChanged
    {
        public Guid AccountId { get; private set; }
        public string AccountName { get; private set; }
    }
}
