using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12
{
    public class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _loginField = By.XPath("//*[@id='modal']/div/div/div[2]/div/input");
        private readonly By _passwordField = By.XPath("//*[@id='modal']/div/div/div[3]/div/input");
        private readonly By _checkboxConfPolicy = By.XPath("//*[@id='modal']/div/div/div[4]/div/div/div");
        private readonly By _signInSubmitButton = By.XPath("//button[text()='Войти']");


        public void Login(User user)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_loginField));
            driver.FindElement(_loginField).SendKeys(user.username);
            wait.Until(ExpectedConditions.ElementIsVisible(_passwordField));
            driver.FindElement(_passwordField).SendKeys(user.password);
            wait.Until(ExpectedConditions.ElementIsVisible(_checkboxConfPolicy));
            driver.FindElement(_checkboxConfPolicy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_signInSubmitButton));
            driver.FindElement(_signInSubmitButton).Click();
        }
    }
}
