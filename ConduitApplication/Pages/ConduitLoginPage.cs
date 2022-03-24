using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConduitApplication.Pages
{
    public class ConduitLoginPage : BasePage
    {
        private IWebDriver driver;

        private IWebElement signInLink => driver.FindElement(By.CssSelector("a[href='/user/login']"));

        private IWebElement usernameField => driver.FindElement(By.CssSelector("input[placeholder='Email']"));

        private IWebElement passwordField => driver.FindElement(By.CssSelector("input[placeholder='Password']"));

        private IWebElement submitField => driver.FindElement(By.XPath("//button[text()='Sign in']"));

        public ConduitLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void NavigateToLoginPage()
        {
            commonElement.ClickElement(signInLink);

        }

        public void LoginToApplication(String email, String password)
        {

            commonElement.SetText(usernameField, email);

            commonElement.SetText(passwordField, password);

            commonElement.ClickElement(submitField);

        }
    }
}
