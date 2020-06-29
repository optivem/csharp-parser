﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Atomiv.Template.DependencyInjection;
using Atomiv.Template.Web.RestApi.Services;
using Microsoft.AspNetCore.Http;
using Atomiv.Template.Web.RestApi.Extensions;
using Atomiv.Web.AspNetCore;
using Atomiv.DependencyInjection.Web.AspNetCore;

namespace Atomiv.Template.Web.RestApi
{
    public class Startup
    {
        private const string SwaggerTitle = "Atomiv.Template REST API";
        private const string SwaggerVersion = "v1";
        private const string SwaggerUrl = "../swagger/v1/swagger.json";

        private static readonly string SwaggerEndpointName = $"{SwaggerTitle} {SwaggerVersion}";
        private static readonly string SwaggerRoutePrefix = string.Empty;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            */


            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddModules(Configuration);

            services.AddAspNetCoreWeb();

            services.AddHostedService<ProductSynchronizationService>();

            // TODO: VC: Check why this is here
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // TODO: Enable if use authentication & authorization

            /*
            var authorizationPolicyBuilder
                = new AuthorizationPolicyBuilder();

            var authorizationPolicy = authorizationPolicyBuilder
                .RequireAuthenticatedUser()
                .Build();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CustomAuthDefaults.AuthenticationScheme;
            }).AddCustomAuthentication(options =>
            {
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = authorizationPolicy;
            });
            */

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerVersion, new OpenApiInfo { Title = SwaggerTitle, Version = SwaggerVersion });
            });

            /*
            services.Configure<KestrelServerOptions>(o =>
            {
                o.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(o =>
            {
                o.AllowSynchronousIO = true;
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, /* IBackgroundJobClient backgroundJobs, */ IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseProblemDetailsExceptionHandler();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerUrl, SwaggerEndpointName);
                c.RoutePrefix = SwaggerRoutePrefix;
            });

            /*

            app.UseHangfireDashboard();
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            */

            // TODO: Enable if use authentication & authorization

            /*
            app.UseAuthentication();
            app.UseAuthorization();
            */

            app.UseHttpsRedirection();
            app.UseMvc();

            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization();
            });
            */
        }
    }
}