using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Proiect.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Proiect.DAL.Entities;
using Proiect.BLL.Managers;
using Proiect.BLL.Interfaces;
using Proiect.BLL.Helpers;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Proiect
{
    public class Startup
    {
        public string SpecificOrigins = "_allowSpecificOrigins";
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
                options.AddPolicy(name: SpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            // services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            var connectionString = Configuration.GetConnectionString("ConnString");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<InitialSeed>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proiect", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });



            // identity
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });


            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("Designer", policy => policy.RequireRole("Designer").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proiect v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(SpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //return;

            initialSeed.CreateRoles();
        }
    }
}
