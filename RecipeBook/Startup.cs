using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using RecipeBook.DataLayer;
using RecipeBook.Entities;
using RecipeBook.Models;
using RecipeBook.Services;

namespace RecipeBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });

            var connectionString = Configuration["connectionStrings:recipeBookDBConnectionString"];
            services.AddDbContext<RecipeBookContext>(o => o.UseSqlServer(connectionString));

            // register the service
            services.AddScoped<IRecipeBookService, RecipeBookService>();

            var mappingConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                // cfg.CreateMap<Recipe, RecipeViewModel>();
                cfg.AddAdminMapping();
            });

            services.AddSingleton(x => mappingConfig.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            //Note1: we can use AddNLog instead of the line below, it is a shortcut. 
            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            //Note2: no need to add it here anymore (asp.net core 2.0+), we can add it in program.cs at bootstrap level, so we can have any error when running
            //loggerFactory.AddNLog();

            //add log to debug window
            loggerFactory.AddDebug(LogLevel.Information);

            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global Exception Logger");
                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
