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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SearchContext>(options => 
                options.UseSqlServer("Server=.;Database=FullTextSearch;Trusted_Connection=True;"));
            services.AddScoped<ITokenizer, Tokenizer>();
            services.AddScoped<IDocsFileReader, DocsFileReader>();
            services.AddScoped<IInvertedIndex, InvertedIndex>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            services.AddScoped<IFilterApplier, FilterApplier>();
            services.AddScoped<IFullTextSearch, FullTextSearch>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Search", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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