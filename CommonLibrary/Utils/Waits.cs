using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Utils
{
    public class Waits
    {
        public static void WaitTillElementVisible(IWebDriver driver, By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            wait.Until(c => c.FindElement(by));

        }

        public static void WaitTillAlertIsPresent(IWebDriver driver, int timeoutInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));

            wait.Until(c => c.SwitchTo().Alert());
        }
    }
}
