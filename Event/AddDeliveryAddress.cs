using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ReactiveReadModels.Event
{
    public class AddDeliveryAddress
    {
        public Guid AccountId { get; private set; }
    }
}
