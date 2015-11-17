using Reactive.EventAggregator;
using System;
using System.Reactive.Linq;

namespace Blog.ReactiveReadModels.Account
{
    public class Repository
    {
        private readonly Service.IAccountService _accountService;
        private readonly IEventAggregator _bus;

        public Repository(Service.IAccountService accountService, IEventAggregator bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public IObservable<ReadModel> For(Guid id)
        {
            return Observable.Create<ReadModel>(
                async observer =>
                {
                    Service.AccountInfo accountInfo = await _accountService.GetAccountInfoAsync(id);

                    return Observable.Empty<ReadModel>().Subscribe(observer);
                }
            );
        }
    }
}
