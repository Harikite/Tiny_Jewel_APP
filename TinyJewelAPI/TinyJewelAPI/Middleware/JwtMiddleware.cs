using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TinyJewelCore.BusinessLogic.CustomerBL;
using TinyJewelCore.BusinessLogic.Utility;

namespace  TinyJewel.MiddleWare
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICustomerBL customerService, IJwtUtils jwtUtils)
        {
            //var allowAnonymous = context.
            //if (allowAnonymous)
            //    return;

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Customer"] = customerService.GetById(userId);

                await _next(context);
            }

            await _next(context);
            // await ReturnErrorResponse(context);

        }

        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.StartAsync();
        }
    }
}