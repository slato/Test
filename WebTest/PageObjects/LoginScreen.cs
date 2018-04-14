using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebTest.PageObjects
{
    public class LoginScreen
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public LoginScreen(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement checkIfLoginWindowOpened()
        {
            try
            {
                return wait.Until(dr => dr.FindElement(By.CssSelector("div[class='sb-modal-component__wrapper']")));
                            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public IWebElement LoginNameBox { get { return driver.FindElement(By.CssSelector("input[id='login-form-username']")); } }

        public IWebElement PasswordBox { get { return driver.FindElement(By.CssSelector("input[id='login-form-password']")); } }

        public IWebElement LogInButton { get { return driver.FindElement(By.CssSelector("button[class*='c-login-form__submit-button']")); } }

    }
}
