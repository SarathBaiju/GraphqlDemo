using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphqlDemo.Graphql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphqlDemo
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
            services.AddSingleton<DemoSchema>()
                 .AddGraphQL((options, provider) =>
                 {
                     options.EnableMetrics = true;
                     var logger = provider.GetRequiredService<ILogger<Startup>>();
                     options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                 })
                 .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }) // For .NET Core 3+
                .AddGraphTypes(typeof(DemoSchema));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphQL<DemoSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
