using HackathonDGTU.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



public static class ServicesBuilderExtions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {

        return services.AddEfCore();
    }


    static IServiceCollection AddEfCore(this IServiceCollection services)
    {
        services.AddDbContextPool<HistoryActionsContext>(ContextBuilder);
        


        return services;
    }
    static void ContextBuilder(IServiceProvider services, DbContextOptionsBuilder builder)
    {
        var conf = services.GetRequiredService<IConfiguration>();
        

        var pgConf = conf.GetConnectionString("PostgresConnection");
        
        if(pgConf is null)
            builder.UseSqlite();
        else
            builder.UseNpgsql(pgConf);
    }
}