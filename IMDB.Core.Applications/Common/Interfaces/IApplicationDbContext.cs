using IMDB.Core.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<WatchList> WatchLists { get; set; }
        DbSet<OfferHistory> OfferHistories { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void SetAutoTransactions(bool enabled = true);
    }
}
