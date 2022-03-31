using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestHeavenSolutionsPolitrip.PageObjects;
using TestHeavenSolutionsPolitrip.PageObjects.RegisterPage;
using TestHeavenSolutionsPolitrip.Utils;

namespace TestHeavenSolutionsPolitrip.Tests
{
    [TestClass]   
    public class RegisterTests
    {
        private IWebDriver driver;

        private RegisterPage registerPage;

        [TestInitialize]
        public void RegisterSetup()
        {
            driver = new ChromeDriver();
            //loginPage = new LoginPage(driver);
            registerPage = new RegisterPage(driver);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://politrip.com");
            var homePage = new HomePage(driver);
            homePage.BtnCookies.Click();
            //Thread.Sleep(2000);

            WaitHelpers.WaitElementIsVisible(driver, homePage.SignUp);
            homePage.BtnSignUp.Click();
        }
        [TestCleanup]
        public void RegisterCleanUp()
        {

            driver.Quit();
        }

        [TestMethod]
        public void a_Should_successfully_created_new_account()
        {
            var newRegisterBO = new NewRegisterBO()
            {
                FirstName = "Octavian",
                LastName = "Morarita",
                Email = "octavianmorarita@gmail.com",
                Password = "Tester01",
                RepeatPassword = "Tester01",
                choice = "Web-Search",
                LblRegister = "Octavian Morarita"

            };
            var homePage = registerPage.RegisterApplication(newRegisterBO);
            //homePage.hoverMouseIcon();
            //homePage.btnMyProfile.Click();

        }

        [TestMethod]
        public void b_Should_deny_registration_for_email_already_used()
        {
            var newRegisterBO = new NewRegisterBO()
            {
                FirstName = "Octavian",
                LastName = "Morarita",
                Email = "octavianmorarita@gmail.com",
                Password = "Tester01",
                RepeatPassword = "Tester01",
                choice = "Social networks",
                LblRegister = "Octavian Tester"

            };
            var homePage = registerPage.DuplicateEmail(newRegisterBO);
            Assert.AreEqual("An user with this email is already registered", registerPage.LblEmailUsed.Text);
        }

    }
}
