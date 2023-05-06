using System.Linq;
using API.error;
using API.Extensions;
using API.Helper;
using AutoMapper;
using Infrastructure.CarModels;
using Infrastructure.IdentityContext;
using Infrastructure.interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(typeof(MapperProfiles));
            string connectionStringCar = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CarStoresDBContext>(opt => opt.UseSqlServer(connectionStringCar));


            string connectionStringIdentity = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppIdentityDBContext>(opt => opt.UseSqlServer(connectionStringIdentity));

            // This is to have validation error with custom error .
            services.Configure<ApiBehaviorOptions>(
               options =>
               {
                   options.InvalidModelStateResponseFactory = actionContext =>
                   {
                       var errors = actionContext.ModelState
                                               .Where(e => e.Value.Errors.Count > 0)
                                               .SelectMany(x => x.Value.Errors)
                                               .Select(x => x.ErrorMessage)
                                               .ToArray();

                       var errorResponse = new ApiValidationError
                       {
                           Errors = errors
                       };
                       return new BadRequestObjectResult(errorResponse);
                   };
               }
           );
            services.AddIdentityServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarAPI", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                c.AddSecurityRequirement(securityRequirement);
            }
            );
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200", "http://localhost:4200");
                });
            });

            //Upload FormOptions
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // This will be run for the each request incase any issue in the cotroller then instead of passing next 
            // It will throw an error.

            // app.UseMiddleware<ExceptionMiddleware>();

            //when the API URL IS NOT MATCHING WITH THE CONTROLLER WE ARE 
            //CREATING THIS SPECIFIC PAGE
            app.UseStatusCodePagesWithRedirects("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseRouting();
            //Always should come after the routing It looks for the wwwroot folder for serving the static files.
            // By Default www root folder served as static folder
            app.UseStaticFiles();
            /*   If we serve anyother folder as Static folder we need to uncomment below lines.
                 app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                    RequestPath = new PathString("/Resources")
                });
            */
            app.UseCors("CorsPolicy");

            //For HTTP CONTEXT CLAIMS ADDING IS NECESSARY
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarAPI V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
