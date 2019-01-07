using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Backend.Repositories;
using Backend.Services;
using AutoMapper;
using Backend.MappingEntities;
using Backend.Services.ZakladServices;
using Backend.Repositories.ReposZaklad;
using Backend.Repositories.GraczZakladRepository;
using Backend.Services.ProfileServices;
using Backend.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Backend.Repositories.ProfilesRepositories;

namespace Backend
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //mapowanie
            Mapper.Initialize(cfg => cfg.AddProfile<MappingEntity>());
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //configure strongly
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            //kofiguracja jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IGraczService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.PodajJednegoPoId(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //repos i service
            services.AddTransient<IGonitwaService, GonitwaService>();
            services.AddTransient<IGonitwaRepository, GonitwaRepository>();
            services.AddTransient<IListaStartowaRepository, ListaStartowaRepository>();
            services.AddScoped<IListaStartowaService, ListaStartowaService>();
            services.AddScoped<IGraczZakladyService, GraczZakladyService>();
            services.AddScoped<IGraczZakladyRepo, GraczZakladyRepo>();
            services.AddTransient<IDzokejRepository, DzokejRepository>();
            services.AddTransient<IDzokejService, DzokejService>();
            services.AddTransient<IGraczProfileService, GraczProfileService>();
            services.AddTransient<IGraczProfileRepository, GraczProfileRepository>();
            services.AddScoped<ISzczegolyGonitwyService, SzczegolyGonitwyService>();
            services.AddScoped<ISzczegolyGonitwyRepo, SzczegolyGonitwyRepo>();
            services.AddScoped<IWierzchowiecService, WierzchowiecService>();
            services.AddScoped<IWierzchowiecRepository, WierzchowiecRepository>();
            services.AddScoped<IGraczService, GraczService>();
            services.AddScoped<IGraczRepository, GraczRepository>();


            services.AddDbContext<TotalizatorContext>(options => options
            .UseSqlServer("Server=DESKTOP-29E1B2H;Database=Totalizator;Trusted_Connection=True;"));

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
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
