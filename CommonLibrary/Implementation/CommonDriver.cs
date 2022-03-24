using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Implementation
{
    public class CommonDriver
    {
        public IWebDriver Driver { get; private set; }

        private int _pageLoadTimeout;

        private int _elementDetectionTimeout;

        public int PageLoadTimeout { 
            
            private get { return _pageLoadTimeout; }

            set { if (value > 0) { _pageLoadTimeout = value; } }
        
        }

        public int ElementDetectionTimeout { 
            private get { return _elementDetectionTimeout; } 
            
            set { if (value > 0) { _elementDetectionTimeout = value; } } 
        
        }


        public CommonDriver(string browserType)
        {
            _pageLoadTimeout = 10;
            _elementDetectionTimeout = 5;

            if (browserType.Equals("chrome"))
            {
                Driver = new ChromeDriver();

            } else if(browserType.Equals("edge"))
            {
                Driver = new EdgeDriver();
            }
            else
            {
                throw new Exception("Invalid browser type " + browserType);
            }

            Driver.Manage().Cookies.DeleteAllCookies();

            Driver.Manage().Window.Maximize();
        }

        public void NavigateToUrl(string url)
        {
            _ = url.Trim();

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_pageLoadTimeout);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_elementDetectionTimeout);

            Driver.Url = url;
        }

        public void Refresh() => Driver.Navigate().Refresh();

        public void CloseAllBrowser() => Driver.Quit();

        public void CloseBrowser() => Driver.Close();

        public String GetTitle() => Driver.Title;

        public string GetUrl()  => Driver.Url;

        public string GetCurrentUrl() => Driver.Url;

        public void NavigateBackward() => Driver.Navigate().Back();


        public void NavigateForward() => Driver.Navigate().Forward();
    }
}
