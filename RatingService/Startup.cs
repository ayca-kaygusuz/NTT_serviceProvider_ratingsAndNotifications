using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Serilog;

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
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("Fixed", config =>
                {
                    config.PermitLimit = 50; // Allow up to 50 requests
                    config.Window = TimeSpan.FromSeconds(10); // Time window duration
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; // Handle requests in order
                    config.QueueLimit = 2; // Allow 2 requests in the queue
                });
            });

            // Add Serilog
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            services.AddSingleton<RatingService>();

            // Add Swagger UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rating Service", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseRateLimiter();
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