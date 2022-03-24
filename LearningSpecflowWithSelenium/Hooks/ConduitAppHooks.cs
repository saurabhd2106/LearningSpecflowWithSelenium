using CommonLibrary.Implementation;
using ConduitApplication.Pages;
using LearningSpecflowWithSelenium.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Bindings;

namespace LearningSpecflowWithSelenium.Hooks
{
    
    public class ConduitAppHooks 
    {
        internal CommonDriver? CmnDriver;

        internal IWebDriver? Driver;

        internal ConduitArticlePage? ArticlePage;


        internal ConduitLoginPage? LoginPage;

        
       

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            BaseHooks.ReportUtils?.CreateScenario(scenarioContext.ScenarioInfo.Title);

            Assert.AreEqual(scenarioContext.ScenarioInfo.Title, "Add an article");

            CmnDriver = new CommonDriver("chrome");

            CmnDriver.NavigateToUrl("http://ec2-3-87-15-51.compute-1.amazonaws.com:3000");

            Driver = CmnDriver.Driver;

            ArticlePage = new ConduitArticlePage(Driver);

            LoginPage = new ConduitLoginPage(Driver);

        }

        [AfterScenario]
        public void Cleanup(ScenarioContext scenarioContext)
        {
            CmnDriver?.CloseAllBrowser();

            
        }

        [AfterStep]
        public  void updateReport(ScenarioContext scenarioContext)

        {

            var stepInfo = scenarioContext.StepContext.StepInfo;

            if (stepInfo.StepDefinitionType.Equals("Given"))
            {
                BaseHooks.ReportUtils?.CreateGivenStep(stepInfo.Text);

            } else if (stepInfo.StepDefinitionType.Equals("When"))
            {
                BaseHooks.ReportUtils?.CreateWhenStep(stepInfo.Text);
            } else
            {
                BaseHooks.ReportUtils?.CreateThenStep(stepInfo.Text);

            }

            if (scenarioContext.StepContext.TestError != null)
            {
                BaseHooks.ReportUtils?.MarkTestStepFail(scenarioContext.StepContext.TestError.Message);
            }
        }

    }
}
