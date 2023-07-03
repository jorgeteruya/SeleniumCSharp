
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System.Diagnostics;
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

        static string GetProjectFolderPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectFolderPath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));

            Console.WriteLine("Caminho do batch file: " + projectFolderPath);

            return projectFolderPath;
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
        
        [AfterFeature]
        static void GenerateReport()
        {
            try
            {
                string projectPath = GetProjectFolderPath();

                string batchFilePath = projectPath + "GenerateReport.bat";

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c \"" + batchFilePath + "\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"[Exception message] {ex.Message}");
            }
        }
    }
}
