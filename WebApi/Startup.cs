using System;
using AutoMapper;
using Core.Data.Models;
using Core.DockerConfig;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Transactions.Common.Interfaces;
using Transactions.Repositories;
using Transactions.Services;
using WebApi.GraphQL;
using WebApi.GraphQL.Transactions;

namespace WebApi
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
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.Configure<BudgetDbSettings>(
                Configuration.GetSection(nameof(BudgetDbSettings)));

            services.AddSingleton<IBudgetDbSettings>(sp =>
                sp.GetRequiredService<IOptions<BudgetDbSettings>>().Value);

            services.AddTransient<IExpenseService, ExpenseService>()
            .AddTransient<IExpenseRepository, ExpenseRepository>()
            .AddTransient<IIncomeService, IncomeService>()
            .AddTransient<IIncomeRepository, IncomeRepository>()
            .AddTransient<IPerformanceService, PerformanceService>()
            .AddTransient<IBalanceAdjustmentService, BalanceAdjustmentService>()
            .AddTransient<IBalanceAdjustmentRepository, BalanceAdjustmentRepository>()
            .AddTransient<ITransactionData, TransactionData>();

            services.AddSingleton<BudgetSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
            .AddWebSockets()
            .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath);
            builder.AddDockerSecrets();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                builder.AddUserSecrets<Startup>();
            }
            app.UseWebSockets();
            app.UseGraphQLWebSockets<BudgetSchema>("/graphql");
            app.UseGraphQL<BudgetSchema>("/graphql");

            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphQLEndPoint = "/graphql"
            });

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
