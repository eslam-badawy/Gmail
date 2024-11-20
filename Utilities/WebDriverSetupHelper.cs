using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Geidea.Web.Tests
{
    public class WebDriverSetupHelper
    {
        protected static IWebDriver driver;

        public static IWebDriver InitializeWebDriver()
        {
            KillPreviousProcesses("chromedriver"); // Kill any existing ChromeDriver processes
            var options = BuildChromeOptions();
            driver = new ChromeDriver(options);

            // Configure WebDriver with default timeouts
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Implicit wait
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30); // Page load timeout
            driver.Manage().Window.Maximize(); // Maximize browser window

            return driver;
        }

        private static ChromeOptions BuildChromeOptions()
        {
            var options = new ChromeOptions();

            // Set up download preferences
            string pathUser = Directory.GetCurrentDirectory();
            string pathDownload = Path.Combine(pathUser, "Downloads");
            options.AddUserProfilePreference("download.default_directory", pathDownload);
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            options.AddArgument("--disable-blink-features=AutomationControlled");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }
            return options;
        }

        private static void KillPreviousProcesses(string processName)
        {
            var processInstances = Process.GetProcessesByName(processName);
            foreach (var process in processInstances)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                }
            }
        }
    }
}
