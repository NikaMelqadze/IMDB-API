using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace FAS.eAMS.Hosts.Api.Dictionaries.Controllers
{
    public abstract class IMDBControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();


        private readonly ILogger<IMDBControllerBase> _logger;

        public IMDBControllerBase(ILogger<IMDBControllerBase> logger)
        {
            _logger = logger;
        }
    }
}
