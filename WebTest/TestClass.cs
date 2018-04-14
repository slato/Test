using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebTest.PageObjects;

namespace WebTest
{
    class NUnitTest
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void SearchingForGame()
        {
            string GameName = "Mayfair Roulette";
            VegasGameMainPage vegasGamePage = new VegasGameMainPage(GameName, driver);
            LoginScreen loginScr = new LoginScreen(driver);

            vegasGamePage.Open();
            vegasGamePage.ClickMagnifier();
            vegasGamePage.SearchForGame();
            vegasGamePage.HoverOverGame();
            vegasGamePage.PressMore();
            vegasGamePage.PressPlay();

            NUnit.Framework.Assert.IsNotNull(loginScr.checkIfLoginWindowOpened(),"Login screen has not been found");
            NUnit.Framework.Assert.IsNotNull(loginScr.LoginNameBox, "Login textbox has not been found");
            NUnit.Framework.Assert.IsNotNull(loginScr.PasswordBox, "Password text box Login textbox has not been found");
            NUnit.Framework.Assert.IsNotNull(loginScr.LogInButton, "LogIN button Login textbox has not been found");

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}