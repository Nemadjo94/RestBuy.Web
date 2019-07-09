using RestBuy.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Services
{
    public interface IRegistrationService
    {
        Task RegisterUser(NewUserViewModel newUserViewModel, CancellationToken token = default);
    }
}
