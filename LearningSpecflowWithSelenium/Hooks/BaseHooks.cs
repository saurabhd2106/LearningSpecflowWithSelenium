using LearningSpecflowWithSelenium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSpecflowWithSelenium.Hooks
{
    [Binding]
    public class BaseHooks
    {
        internal static ExtentReportUtils? ReportUtils;

        [BeforeFeature]
        public static void PreSetup(FeatureContext featureContext)
        {
            ReportUtils = new ExtentReportUtils("C:/Users/SAURABH/source/repos/LearningSpecflowWithSelenium/LearningSpecflowWithSelenium/Reports/test.html");

            ReportUtils.CreateFeature(featureContext.FeatureInfo.Title);
        }


        [AfterFeature]
        public static void PostCleanup()
        {
            ReportUtils?.FlushReport();
        }
    }
}
