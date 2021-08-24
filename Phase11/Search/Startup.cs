using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Search.Interface;
using Search.Model;

namespace Search
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SearchContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("database")));
            services.AddTransient<ITokenizer, Tokenizer>();
            services.AddTransient<IDocsFileReader, DocsFileReader>();
            services.AddTransient<IInvertedIndex, InvertedIndex>();
            services.AddTransient<IQueryProcessor, QueryProcessor>();
            services.AddTransient<IFilterApplier, FilterApplier>();
            services.AddTransient<IFullTextSearch, FullTextSearch>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Search", Version = "v1"}); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Search v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}