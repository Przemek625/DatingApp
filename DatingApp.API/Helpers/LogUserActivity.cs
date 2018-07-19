using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
// important import
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Helpers
{   
    // https://docs.microsoft.com/pl-pl/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1
    // https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/delegates/
    // https://docs.microsoft.com/pl-pl/dotnet/api/microsoft.aspnetcore.mvc.filters.iasyncactionfilter.onactionexecutionasync?view=aspnetcore-2.1
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           var resultContext = await next();

           var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
           var repo = resultContext.HttpContext.RequestServices.GetService<IDatingRepository>();
           var user = await repo.GetUser(userId);
           user.LastActive = DateTime.Now;
           await repo.saveAll();
        }
    }
}