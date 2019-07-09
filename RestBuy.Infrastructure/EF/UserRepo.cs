using RestBuy.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using RestBuy.Application.Services.Repos;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Infrastructure.EF
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(RestBuyContext restBuyContext) : base(restBuyContext) { }


        public Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            return this.restBuyContext.Users.AddAsync(user, cancellationToken);
        }
    }
}
