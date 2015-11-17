using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ReactiveReadModels.Service
{
    public class AccountInfo
    {

    }

    public interface IAccountService
    {
        Task<AccountInfo> GetAccountInfoAsync(Guid id);    
    }
}
