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
                    
                    IObservable<Func<ReadModel, ReadModel>> mutators = Observable.Merge(
                        _bus.GetEvent<Event.AccountNameChanged>().Where(@event => id.Equals(@event.AccountId)).Select(Functions.WithNameChanged)
                    );

                    return mutators.Scan(accountInfo.ToReadModel(), (rm, m) => m(rm)).Subscribe(observer);
                }
            );
        }
    }
}
