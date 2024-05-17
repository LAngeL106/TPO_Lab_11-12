using OpenQA.Selenium;

namespace Lab11_12
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;

        public AbstractPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Exit()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
