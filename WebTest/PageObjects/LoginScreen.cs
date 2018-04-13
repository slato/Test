using System;
using OpenQA.Selenium;

namespace WebTest.PageObjects
{
    public class LoginScreen
    {
        private IWebDriver driver;
        public LoginScreen(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement checkIfLoginWindowOpened()
        {
            try
            {
                return driver.FindElement(By.CssSelector("div[class='sb-modal-component__wrapper']"));
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
