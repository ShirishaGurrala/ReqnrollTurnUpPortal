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
        [Given("I logged into turnup Portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();

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

        [When("edited time and material record with {string}")]
        public void WhenEditedTimeAndMaterialRecordWith(string code)
        {
            TMPage tMPage = new TMPage();
            tMPage.EditTimeRecord(driver, code);

        }
         
        [Then("The edited record {string} should be successfully edited")]
        public void ThenTheEditedRecordShouldBeSuccessfullyEdited(string code)
        {
            TMPage tMPage = new TMPage();


            string codeValue = tMPage.GetCode(driver); //code is equivalent to Iwebelement.Text which is in the method GetCode newCode.Text
            string description = tMPage.GetDescription(driver);
          
            Assert.That(codeValue == code, "Actual and excepted code doesn't match");
            Assert.That(description == code + " description", "Actual and excepted description doesn't match");

        }
    }
}
