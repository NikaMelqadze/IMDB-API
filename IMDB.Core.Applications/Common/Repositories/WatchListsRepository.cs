using AutoMapper;
using AutoMapper.QueryableExtensions;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Applications.WatchLists.DTOs;
//using FAS.eAMS.Core.Applications.Dictionaries.Countries.DTOs;
using IMDB.Core.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Repositories
{
    public class WatchListsRepository
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public WatchListsRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Domains.Entities.WatchList> GetIenumarableWatchList()
        {
            return _context.WatchLists.Include(x=>x.OfferHistories).AsEnumerable();
        }

        public async Task AddEntityItem(Domains.Entities.WatchList item)
        {
            await _context.WatchLists.AddAsync(item);
        }

        public async Task<Domains.Entities.WatchList> GetEntityItem(int userId, string filmId)
        {
            return await _context.WatchLists.FirstOrDefaultAsync(w => w.UserId == userId && w.FilmId == filmId);
        }

        public bool CheckDublicates(CreateWatchListDto item)
        {
            return _context.WatchLists.Any(w => w.UserId == item.UserId &&
                                                w.FilmId == item.MovieId);
        }

        //public bool CheckDublicates(UpdateCountryDto item)
        //{
        //    return _context.Countries.Any(o => o.Id != item.Id && o.Name == item.Name && !o.IsDeleted);
        //}

        internal async Task<List<WatchLists.DTOs.WatchList>> WatchListsAsync(WatchListFilter filter, CancellationToken cancellationToken)
        {
            return await _context.WatchLists
                    .Where(x => x.UserId == filter.UserId)
                    .AsNoTracking()
                    .ProjectTo<WatchLists.DTOs.WatchList>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        }

        //internal async Task<Cities.DTOs.City> GetCountryAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    return await (from x in _context.Countries
        //                  where x.Id == id && !x.IsDeleted
        //                  select x)
        //                    .AsNoTracking()
        //                    .ProjectTo<Countries.DTOs.Country>(_mapper.ConfigurationProvider)
        //                    .FirstOrDefaultAsync(cancellationToken);
        //}
    }
}
