using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConduitApplication.Pages
{
    public class ConduitArticlePage : BasePage
    {
        private IWebDriver driver;

        public ConduitArticlePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToArticlePage()
        {
            driver.FindElement(By.LinkText("New Article")).Click();
        }

        public void AddArticle()
        {
            driver.FindElement(By.CssSelector("[placeholder='Article Title']")).SendKeys("Learning Specflow");

            driver.FindElement(By.CssSelector("[placeholder=\"What's this article about?\"]")).SendKeys("Learning Specflow");

            driver.FindElement(By.CssSelector("[placeholder=\"Write your article (in markdown)\"]")).SendKeys("Learning Specflow");

            driver.FindElement(By.CssSelector("[placeholder='Enter tags']")).SendKeys("Learning Specflow");

            driver.FindElement(By.XPath("//button")).Click();
        }
    }
}
