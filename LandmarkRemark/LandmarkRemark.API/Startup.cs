﻿using LandmarkRemark.API.Repository;
using LandmarkRemark.API.Repository.Mock;
using LandmarkRemark.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LandmarkRemark.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserService>();
            services.AddScoped<IRemarkServices, RemarkServices>();
            //services.AddScoped<IRemarkRepository, RemarkRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRemarkRepository, MockRemarkRepository>();
            services.AddScoped<IUserRepository, MockUserRepository>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}