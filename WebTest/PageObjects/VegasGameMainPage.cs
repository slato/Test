using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace WebTest.PageObjects
{
    public class VegasGameMainPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string URL = "https://vegas.williamhill.com/";
        private string GameName;

        public VegasGameMainPage(string GameName, IWebDriver driver)
        {
            this.GameName = GameName;
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(URL);
        }

        public void ClickMagnifier()
        {
            wait.Until(dr => dr.FindElement(By.ClassName("btn-search-magnifier"))).Click();
        }

        public void SearchForGame()
        {
            wait.Until(dr => dr.FindElement(By.CssSelector("input[placeholder*='Search for games...']"))).SendKeys(GameName);
        }

        public void HoverOverGame()
        {
            System.Threading.Thread.Sleep(3000); //short wait until game will be sorted, need to find beter solution :)
            wait.Until(dr => driver.FindElement(By.CssSelector($"img[alt='{GameName}']")));
            var element = driver.FindElement(By.CssSelector($"img[alt='{GameName}']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }
        public void PressMore()
        {
            wait.Until(dr => dr.FindElement(By.CssSelector("button[class*='o-btn--more']"))).Click();
        }

        public void PressPlay()
        {
            wait.Until(dr => dr.FindElement(By.CssSelector("button[class*='o-btn--big']"))).Click();
        }
    }
}
