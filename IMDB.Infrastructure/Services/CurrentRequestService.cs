using IMDB.Core.Applications.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace IMDB.Infrastructure.Services
{
    public class CurrentRequestService : ICurrentRequestService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentRequestService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ClientIp => _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress.ToString();

    }
}
