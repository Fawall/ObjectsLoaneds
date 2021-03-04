using System;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Repository
{
    public class GetUserId : IGetUserId
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public GetUserId(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcessor = httpContextAccessor;
        }

        public string GetCurrentUser()
        {
            string userId =_httpContextAcessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId;
        }
    }
}