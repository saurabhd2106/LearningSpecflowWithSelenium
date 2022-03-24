using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Utils
{
    public class ScreenshotUtils
    {
        ITakesScreenshot camera;

        public ScreenshotUtils(IWebDriver driver)
        {
            camera = (ITakesScreenshot)driver;
        }
        public void CaptureAndSaveScreenshot(string Filename)
        {
            _ = Filename.Trim();

            if (File.Exists(Filename))
            {
                throw new Exception("File already exist.." + Filename);
            }

            Screenshot screenshot = camera.GetScreenshot();

            screenshot.SaveAsFile(Filename);

        }
    }
}
