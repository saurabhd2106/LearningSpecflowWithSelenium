using CommonLibrary.Implementation;
using ConduitApplication.Pages;
using LearningSpecflowWithSelenium.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningSpecflowWithSelenium.StepDefinitions

{
    
    [Binding]
    public sealed class ConduitApplicationSteps : ConduitAppHooks
    {

        private ScenarioContext _scenarioContext;

        public ConduitApplicationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        
        

        [Given(@"As a writer")]
        public void GivenAsAWriter()
        {


            LoginPage.NavigateToLoginPage();

            LoginPage.LoginToApplication("saurabh@fake.com", "admin");


        }

        [When(@"I post an article with title as (.*)")]
        public void WhenIPostAnArticle(string title)
        {

            ArticlePage.NavigateToArticlePage();

            ArticlePage.AddArticle();

            _scenarioContext["title"] = title;

        }

        [Then(@"posted article should be visible for my learners")]
        public void ThenPostedArticleShouldBeVisibleForMyLearners()
        {
            Assert.AreEqual(_scenarioContext.ScenarioInfo.Title, "Add an article");

            Assert.AreEqual(_scenarioContext["title"], "Learning Specflow");

            Assert.AreEqual(_scenarioContext.ScenarioInfo.Tags[0], "Regression");
        }
    }
}