using API.Signalr;
using AutoMapper;
using DAL.Contexts;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Common;

public static class AddBaseStartup
{
   

    public static  void AddConfigureServices(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();



        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();



        services.AddDbContext<TestCurdContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("TestCurdContextConnection"));
        });
      
        services.AddTransient<IUnitOfWork, UnitOfWork>();


        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddSignalR();

        services.AddMvcCore()
        .AddViews();

        services.AddControllersWithViews();

    }

}
