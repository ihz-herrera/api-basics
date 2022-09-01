using APIRest.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace APIRest.Extenciones
{
    public static class Extension
    {
        public static IServiceCollection ConfigurarContextDatos(this IServiceCollection service, string cnnString)
        {
            service.AddDbContext<Context>(optionsBuilder => optionsBuilder.UseSqlServer(cnnString));

            return service;
        }
    }
}
