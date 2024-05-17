using Lab11_12;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12
{
    public class AccountPage : AbstractPage
    {
        public AccountPage(IWebDriver webDriver) : base(webDriver) { }

        Data data = new Data();

        private readonly By _nameField = By.XPath("//*[@id=\"name\"]");
        private readonly By _birthDateField = By.XPath("//*[@id=\"dateOfBirth\"]");
        private readonly By _birthDateError = By.XPath("//*[text()='Ого, вы прибыли из будущего? Укажите реальную дату.']");
        private readonly By _saveChangesButton = By.XPath("//*[text()='Сохранить изменения']");
        private readonly By _accountNameField = By.XPath("//*[@id='personal_info_form']/div[2]/div/div/span/p[1]");


        public void InputBadName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_nameField));
            driver.FindElement(_nameField).Clear();
            driver.FindElement(_nameField).SendKeys(data.badName);
        }
        public void InputBadDateOfBirth()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_birthDateField));
            driver.FindElement(_birthDateField).Clear();
            driver.FindElement(_birthDateField).SendKeys(data.badBirthDate);
        }
        public void SaveChanges()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_saveChangesButton));
            Thread.Sleep(1000);
            driver.FindElement(_saveChangesButton).Click();
        }

        public string GetAccountName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_accountNameField));
            Thread.Sleep(5000);
            IWebElement spanElement = driver.FindElement(_accountNameField);
            return spanElement.Text;
        }
        public string GetBirthDateError()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_birthDateError));
            IWebElement spanElement = driver.FindElement(_birthDateError);
            return spanElement.Text;
        }
    }
}
