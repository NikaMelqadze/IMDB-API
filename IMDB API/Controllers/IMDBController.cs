using FAS.eAMS.Hosts.Api.Dictionaries.Controllers;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Enums;
using IMDB.Core.Applications.Movies.Commands.SearchMovieCommand;
using IMDB.Core.Applications.Persons.Queries;
using IMDB.Core.Applications.WatchLists.Commands.CreateWatchListCommand;
using IMDB.Core.Applications.WatchLists.Commands.WatchedCommand;
using IMDB.Core.Applications.WatchLists.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IMDBController : IMDBControllerBase
    {
        public IMDBController(ILogger<IMDBController> logger) : base(logger) { }

        [HttpGet]
        [Route("/[controller]")]
        public async Task<IResult> GetWatchLists([FromHeader] Languages language, int userId)
        {
            return await Mediator.Send(new GetWatchListsQuery() { Language = language, Filter = new IMDB.Core.Applications.WatchLists.DTOs.WatchListFilter { UserId = userId } });
        }

        [HttpPost]
        [Route("/[controller]/setWatched")]
        public async Task<IResult> SetWatched([FromHeader] Languages language, WatchedDto item)
        {
            return await Mediator.Send(new WatchedCommand() { Language = language, Item = item });
        }

        [HttpGet]
        [Route("/[controller]/search")]
        public async Task<IResult> SearchMovie(string name)
        {
            return await Mediator.Send(new SearchMovieCommand() { Name = name });
        }

        [HttpGet]
        [Route("/[controller]/addToWatchList")]
        public async Task<IResult> AddToWatchList([FromHeader] Languages language, int userId, string movieId)
        {
            return await Mediator.Send(new CreateWatchListCommand() { Language = language, Item = new CreateWatchListDto { UserId = userId, MovieId = movieId } });
        }

    }
}
