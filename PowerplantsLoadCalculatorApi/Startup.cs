using GemBAL.Interface;
using GemBAL.Strategy;
using PowerplantsLoadCalculatorApi.Converters;
using PowerplantsLoadCalculatorApi.Manager;

namespace PowerplantsLoadCalculatorApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILoadCalculatorStrategy, GasFiredPowerPlantStrategy>();
            services.AddTransient<ILoadCalculatorStrategy, TurbojetPowerPlantStrategy>();
            services.AddTransient<ILoadCalculatorStrategy, WindTurbinePowerPlantStrategy>();
            services.AddTransient<IPayloadService, PayloadService>();
            services.AddControllers()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.Converters.Add(new PowerPlantTypeConverter());
                  options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
              });
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(typeof(Startup));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
        }
    }
}
