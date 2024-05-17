using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Lab11_12
{
    public class DriverInstance
    {
        private static IWebDriver? driver;

        public enum BrowserType
        {
            Chrome,
            Firefox,
            MsEdge
        }
        private DriverInstance() { }

        public static IWebDriver GetInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.MsEdge:
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void CloseBrowser()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
