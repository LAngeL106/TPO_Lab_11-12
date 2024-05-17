using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Lab11_12
{
    public class KufarTests
    {
        IWebDriver? driver;

        FixPricePage fixPricePage;
        LoginPage loginPage;
        FavoritesPage favoritesPage;
        CartPage cartPage;
        SearchPage searchPage;
        ProfileSettingsPage profileSettingsPage;

        string? productName;

        User user = UserCreator.UserWitchInfoFromFile();
        Data data = new Data();

        [SetUp]
        public void Init()
        {
            driver = DriverInstance.GetInstance(DriverInstance.BrowserType.MsEdge);
            driver.Manage().Window.Maximize();
            fixPricePage = new FixPricePage(driver);
            loginPage = new LoginPage(driver);
            favoritesPage = new FavoritesPage(driver);
            cartPage = new CartPage(driver);
            searchPage = new SearchPage(driver);
            profileSettingsPage = new ProfileSettingsPage(driver);
        }

        [TearDown]
        public void Cleanup()
        {
            DriverInstance.CloseBrowser();
        }

        [Test]
        public void AddItemToFavorite()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.AuthorizeUser(user, loginPage);
            productName = fixPricePage.ClickFirstProduct();
            fixPricePage.LikeProduct();
            fixPricePage.ClickProfileFavorites();
            Assert.IsTrue(favoritesPage.GetFavoriteProductName() == productName);
        }

        [Test]
        public void AddProductToCart()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.AuthorizeUser(user, loginPage);
            productName = fixPricePage.AddToCartFirstProductCard();
            fixPricePage.GoToCart();
            Assert.IsTrue(cartPage.GetBusketProductName() == productName);
        }

        [Test]
        public void SearchingProductsByEnteringStringInSearchEngine()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.ClosingPolicyAndAdvertisingWindows();
            fixPricePage.ClickSearchField();
            fixPricePage.EnteringValueInSearchEngine();
            fixPricePage.ClickButtonSearch();
            Assert.IsTrue(searchPage.GetSearchResult().Contains(data.searchString));
        }

        [Test]
        public void DisableNotifications()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.AuthorizeUser(user, loginPage);
            fixPricePage.ClickProfileSettings();
            string[] arr = profileSettingsPage.FindAndDisableNotificationsSettings();
            Assert.IsTrue(!arr[0].Contains("btn on") && !arr[1].Contains("btn on"));
        }

        [Test]
        public void ChooseCatalog()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.ClickCatalogButton();
            fixPricePage.ChooseCatalog();
            Assert.IsTrue(fixPricePage.GetCatalogName() == data.catalogName);
        }
    }
}
