using System;
using System.Security.AccessControl;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollTurnUpPortal.Pages;
using ReqnrollTurnUpPortal.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace ReqnrollTurnUpPortal.StepDefinition
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Given("I logged into turnup Portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver);
        }

        [Given("I navigate to Time and material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization
            HomePage homePage = new HomePage();
            homePage.NavigateToTMPage(driver);
        }

        [When("I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            // TM page object initialization
            TMPage tMPage = new TMPage();
            tMPage.CreateTimeRecord(driver);
        }

        [Then("The record should be successfully created")]
        public void ThenTheRecordShouldBeSuccessfullyCreated()
        {
            TMPage tMPage = new TMPage();


            string code = tMPage.GetCode(driver); //code is equivalent to Iwebelement.Text which is in the method GetCode newCode.Text
            string description = tMPage.GetDescription(driver);
            string price = tMPage.GetPrice(driver);

            Assert.That(code == "TA Programme", "Actual and excepted code doesn't match");
            Assert.That(description == "This is a description", "Actual and excepted description doesn't match");
            Assert.That(price == "$12.00", "Actual and excepted price doesn't match");
        }

        [When("update time and material record with code {string} , description {string}")]
        public void WhenUpdateTimeAndMaterialRecordWithCodeDescription(string code, string description)
        {
            TMPage tMPage = new TMPage();
            tMPage.EditTimeRecord(driver, code, description);

        }

        [Then("The updated record with code {string} , description {string} should be successfully updated")]
        public void ThenTheUpdatedRecordWithCodeDescriptionShouldBeSuccessfullyUpdated(string code, string description)
        {
            TMPage tMPage = new TMPage();


            string codeValue = tMPage.GetCode(driver); //code is equivalent to Iwebelement.Text which is in the method GetCode newCode.Text
            string descriptionValue = tMPage.GetDescription(driver);

            Assert.That(codeValue == code, "Actual and excepted code doesn't match");
            Assert.That(descriptionValue == description, "Actual and excepted description doesn't match");
        }

        [AfterScenario]
        public void CloseTestRun()
        {
            driver.Quit();

        }
    }
}
