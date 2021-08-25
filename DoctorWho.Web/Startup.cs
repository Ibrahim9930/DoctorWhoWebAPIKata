using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DoctorWho.Web
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
            services.AddControllers()
                .ConfigureApiBehaviorOptions(setupAction =>
                {
                    setupAction.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetailsFactory = context.HttpContext.RequestServices
                            .GetRequiredService<ProblemDetailsFactory>();

                        var problemDetails = problemDetailsFactory.CreateProblemDetails(context.HttpContext);

                        var actionExecutingContext = context as ActionExecutingContext;
                        
                        if (!context.ModelState.IsValid)
                        {
                            if (context.ActionDescriptor.Parameters.Count ==
                                actionExecutingContext?.ActionArguments.Count)
                            {
                                problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                                problemDetails.Detail = "error validating one or more fields";

                                return new UnprocessableEntityObjectResult(problemDetails)
                                {
                                    ContentTypes = {"application/problem+json"}
                                };
                            }
                        }

                        problemDetails.Status = StatusCodes.Status400BadRequest;
                        problemDetails.Title = "Un-parsable input";

                        return new BadRequestObjectResult(problemDetails)
                        {
                            ContentTypes = {"application/problem+json"}
                        };
                    };
                });
            services.AddFluentValidation(
                fv => fv.RegisterValidatorsFromAssemblyContaining<DoctorCreationValidator>()
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped < DoctorWhoCoreDbContext>(sp =>
            {
                var optBuilder = new DbContextOptionsBuilder();
                optBuilder.UseInMemoryDatabase("Development DB");
                
                var db = new DoctorWhoCoreDbContext(optBuilder.Options);
                
                db.Database.EnsureCreated();
                
                return db;
            });
            
            // services.AddScoped<DoctorWhoCoreDbContext>();

            services.AddScoped<EFRepository<Doctor>, DoctorEFRepository>();
            services.AddScoped<EFRepository<Episode>, EpisodeEFRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "DoctorWho.Web", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoctorWho.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}