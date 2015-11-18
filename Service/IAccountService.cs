using System;
using System.Threading.Tasks;

namespace Blog.ReactiveReadModels.Service
{
    public class AccountInfo
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }

    public interface IAccountService
    {
        Task<AccountInfo> GetAccountInfoAsync(Guid id);    
    }
}
