using RestBuy.Application.Services.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Infrastructure.EF
{
    public class RestBuyUoW : IUoW
    {
        readonly RestBuyContext context;

        public RestBuyUoW(RestBuyContext dbContext)
        {
            this.context = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
