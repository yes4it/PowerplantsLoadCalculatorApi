using GemBAL.Factory;
using GemBAL.Interface;
using GemBAL.Strategy;
using PowerplantsLoadCalculatorApi.Converters;
using PowerplantsLoadCalculatorApi.Interface;
using PowerplantsLoadCalculatorApi.Service;

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
            services.AddSingleton<ILoadCalculatorStrategyFactory, LoadCalculatorStrategyFactory>(provider =>
            {
                var factory = new LoadCalculatorStrategyFactory();

                var strategies = provider.GetServices<ILoadCalculatorStrategy>();

                foreach (var strategy in strategies)
                {
                    factory.AddStrategy(strategy);
                }

                return factory;
            });

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
