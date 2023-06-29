using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System.Reflection;
using TestFramework;

namespace AutomationSpecFlow.Hooks
{
    [Binding]
    public class StartupHooks
    {
        private BrowserHost _browserHost { get; }
        public StartupHooks(BrowserHost browserHost) 
        {
            _browserHost = browserHost;
        }

        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional:false)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton(configuration);
            services.AddSingleton<BrowserHost> ();

            return services;
        }

        [BeforeScenario] 
        public void BeforeScenario() 
        {
            try
            {
                _browserHost.InitializeWebDriver();
            }catch(Exception ex) 
            {
                Console.WriteLine($"[Exception message] {ex.Message}");
            }
        }

        [AfterScenario] 
        public void AfterScenario() 
        {
            try
            {
                _browserHost.DisposeWebDriver();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception message] {ex.Message}");
            }
        }
    }
}
