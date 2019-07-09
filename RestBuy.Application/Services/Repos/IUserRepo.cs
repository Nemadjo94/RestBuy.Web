using RestBuy.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Services.Repos
{
    public interface IUserRepo : IEntityRepo<User>
    {
        Task AddAsync(User user, CancellationToken cancellationToken = default);
    }
}
