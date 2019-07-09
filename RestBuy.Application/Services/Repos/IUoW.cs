using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Services.Repos
{
    //Unit of work
    public interface IUoW
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
