using AutoMapper;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Domains.MovieService;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Movies.Commands.SearchMovieCommand
{


    public class SearchMovieCommand : IRequest<IResult>
    {
        public string Name { get; set; }
    }

    public class SearchMovieCommandHandler : IRequestHandler<SearchMovieCommand, IResult>
    {
        protected readonly IMovieService _context;        
        protected readonly IMapper _mapper;
        

        public SearchMovieCommandHandler(IMovieService context, IMapper mapper)
        {
            _context = context;           
            _mapper = mapper;
        }

        public async Task<IResult> Handle(SearchMovieCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.SearchAsync(request.Name);
            return new Result<List<SearchResult>>(result.Results);

            //.ProjectTo<Countries.DTOs.Country>(_mapper.ConfigurationProvider)
        }
    }


}
