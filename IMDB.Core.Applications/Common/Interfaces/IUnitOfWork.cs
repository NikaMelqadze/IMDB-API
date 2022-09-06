using IMDB.Core.Applications.Common.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public OfferHistoriesRepository OfferHistoriesRepo { get; }
        public WatchListsRepository WatchListsRepo { get; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
