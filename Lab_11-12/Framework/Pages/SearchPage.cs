﻿using Lab11_12;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class SearchPage : AbstractPage
{
    public SearchPage(IWebDriver webDriver) : base(webDriver) { }

    private readonly By _searchResultString = By.XPath("//*[@id=\"__layout\"]/div/div/div[4]/div/div/div/div/div/div[1]/h1");

    public string GetSearchResult()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(_searchResultString));
        IWebElement searchResult = driver.FindElement(_searchResultString);
        return searchResult.Text;
    }
}