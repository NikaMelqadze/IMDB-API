using AutoMapper;
using IMDB.Core.Applications.Common.Interfaces;

namespace IMDB.Core.Applications.Common.Repositories
{
    public class OfferHistoriesRepository
    {
        private IApplicationDbContext _context;
        
        public OfferHistoriesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEntityItem(Domains.Entities.OfferHistory item)
        {
            _context.OfferHistories.Add(item);
        }

    }
}
