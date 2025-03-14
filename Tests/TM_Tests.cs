using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.DOM;
using ReqnrollTurnUpPortal.Pages;
using ReqnrollTurnUpPortal.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace ReqnrollTurnUpPortal.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp] 
        public void SetUpSteps()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();

            // Login page object initialization
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver);

            // Home page object initialization
            HomePage homePage = new HomePage();
            homePage.NavigateToTMPage(driver);

        }
        [Test]
        public void CreateTime_Test()
        {

            // TM page object initialization
            TMPage tMPage = new TMPage();
            tMPage.CreateTimeRecord(driver);
        }
        [Test]
        public void EditTime_Test()
        {
            TMPage tMPage = new TMPage();
            //String code = "editedcode";
            //tMPage.EditTimeRecord(driver, code);
            tMPage.EditTimeRecord(driver, "editedcode");
        }
        [Test]
        public void DeleteTime_Test()
        {
            TMPage tMPage = new TMPage();
            tMPage.DeleteTimeRecord(driver);
        }
        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
