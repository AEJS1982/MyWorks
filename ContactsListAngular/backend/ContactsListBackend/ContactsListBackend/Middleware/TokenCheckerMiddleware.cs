using ContactsListBackend.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Middleware
{
    public class TokenCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        private IUsersRepository _repo;

        public TokenCheckerMiddleware(IUsersRepository usersRepo, RequestDelegate next)
        {
            _next = next;
            _repo = usersRepo;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.Count(x => x.Key == "token") > 0)
            {
                //Verify token
                var token=httpContext.Request.Headers.Where(x => x.Key=="token");

                if (token.Count()>0)
                {
                    var isTokenValid = _repo.ValidateToken(token.First().Value);

                    if (!isTokenValid)
                    {
                        //Cancel the request
                        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await httpContext.Response.WriteAsync("Invalid token. Please re-login");
                        return;
                    }
                }
            }
            else {
                //No token? Check route and only allow calls to login. If not, cancel the request
                if (httpContext.Request.Path != "/login") {
                    //Cancel the request
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Invalid token. Please re-login");
                    return;
                }
            }

            await _next(httpContext);
        }
    }

    public static class TokenCheckerMiddlewareExtensions {
        public static IApplicationBuilder UseTokenCheckerMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<TokenCheckerMiddleware>();
        }
    }
}
