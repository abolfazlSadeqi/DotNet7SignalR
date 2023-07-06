using API.Signalr;
using AutoMapper;
using DAL.Contexts;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Common;

public static class AddStartupApplicationBuilder
{


    public static void AddConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }


        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseAuthorization();
        app.UseSwagger();


        app.UseSwagger();
        //app.UseSwaggerUI();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = "";
        });




        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {

            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");

            endpoints.MapControllers();
            endpoints.MapHub<ShopNotificationHub>("/ShopNotificationHub");
        });
        // Configure the HTTP request pipeline.

    }
}
