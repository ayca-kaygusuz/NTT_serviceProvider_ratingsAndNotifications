using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AspNetCoreRateLimit;

namespace RatingService
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
            services.AddControllers();

            // Configure rate limiting
            services.AddOptions();
            services.Configure<IpRateLimitingOptions>(Configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitingPolicies>(Configuration.GetSection("IpRateLimitingPolicies"));
            services.AddInMemoryRateLimiting();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            // Add Serilog
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            services.AddSingleton<RatingService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rating Service", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIpRateLimiting();
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rating Service V1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}