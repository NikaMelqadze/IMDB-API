using AutoMapper;
using IMDB.Core.Applications.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;


        private OfferHistoriesRepository _offerHistoriesRepo;
        public OfferHistoriesRepository OfferHistoriesRepo
        {
            get
            {
                if (_offerHistoriesRepo == null) { _offerHistoriesRepo = new OfferHistoriesRepository(_context); }
                return _offerHistoriesRepo;
            }
        }

        private WatchListsRepository _watchListsRepo;
        public WatchListsRepository WatchListsRepo
        {
            get
            {
                if (_watchListsRepo == null) { _watchListsRepo = new WatchListsRepository(_context, _mapper); }
                return _watchListsRepo;
            }
        }

        public UnitOfWork(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
