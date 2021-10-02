// <copyright file="Startup.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Api
{
    using System;
    using Fun.Logging.Startup;
    using Fun.Pokedex.Core.ApiClients;
    using Fun.Pokedex.Core.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// The Startup class configures services and the applications request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets a represents a set of key/value application configuration properties.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFunLogging("Fun.Pokedex", "v1");

            services.AddHttpClient<IPokeApiClient, PokeApiClient>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("Api:PokeApi"));
            });

            services.AddHttpClient<ITranslationApiClient, TranslationApiClient>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("Api:TranslationApi"));
            });

            services.AddTransient<IPokedexService, PokedexService>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "FunCorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .WithMethods("GET");
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fun.Pokedex.Api", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Provides the mechanisms to configure the application request pipelines. <see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">Provides information regarding the hosting environment that the application is running in <see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseFunLogging();
            app.UseFunErrorLogging();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fun.Pokedex.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("FunCorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}