
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSpecflowWithSelenium.Utils
{
    public class ExtentReportUtils
    {

        private ExtentReports extentReports;

        private ExtentSparkReporter sparkReporter;

        private ExtentTest extentFeatureName;

        private ExtentTest extentScenarioName;

        private ExtentTest extentStepName;



        public ExtentReportUtils(string filename)
        {
             _ = filename.Trim();

             extentReports = new ExtentReports();

            sparkReporter = new ExtentSparkReporter(filename);

            extentReports.AttachReporter(sparkReporter);

        }

        public void FlushReport()
        {
            extentReports.Flush();
        }
        public void CreateFeature(string featureName)
        {
            extentFeatureName = extentReports.CreateTest(featureName);
        }

        public void CreateScenario(string scenarioName)
        {
            extentScenarioName = extentFeatureName.CreateNode(scenarioName);
        }

        public void CreateWhenStep(string stepName)
        {
             extentScenarioName.CreateNode<When>(stepName);
        }

        public void CreateThenStep(string stepName)
        {
            extentScenarioName.CreateNode<Then>(stepName);
        }

        public void CreateGivenStep(string stepName)
        {
            extentStepName = extentScenarioName.CreateNode<Given>(stepName);
        }

        public void MarkTestStepFail(string errorMessage)
        {

            extentStepName.Log(Status.Fail, errorMessage);
        }
    }
}
