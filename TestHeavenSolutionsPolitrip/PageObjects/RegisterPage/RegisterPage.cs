using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestHeavenSolutionsPolitrip.Utils;

namespace TestHeavenSolutionsPolitrip.PageObjects.RegisterPage
{
    public class RegisterPage
    {
        public IWebDriver driver;

        public RegisterPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By FirstName = By.Id("first-name");
        public IWebElement TxtFirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement TxtLastName => driver.FindElement(By.CssSelector("input[id='last-name']"));
        public IWebElement TxtEmail => driver.FindElement(By.XPath("//input[@formcontrolname='email']"));
        public IWebElement TxtPassword => driver.FindElement(By.CssSelector("input[id='sign-up-password-input']"));
        public IWebElement TxtRepeatPassword => driver.FindElement(By.CssSelector("input[id='sign-up-confirm-password-input']"));
        public IWebElement TxtConfirmPassword => driver.FindElement(By.Name("confirmPassword"));


        public IWebElement Participant => driver.FindElement(By.CssSelector("div[id='qa_signup-participant']"));

        private By choice = By.Id("sign-up-heard-input");
        public IWebElement DdlChoice => driver.FindElement(choice);

        private By SubmitReg = By.XPath("//button[@id=' qa_loader-button']");
        public IWebElement BtnSubmit => driver.FindElement(By.XPath("//button[@id=' qa_loader-button']"));

        public IWebElement LblEmailUsed => driver.FindElement(By.CssSelector("div[id='sign-up-error-div']"));

        public void selectChoice(NewRegisterBO newRegisterBO)
        {
            var selectTara = new SelectElement(DdlChoice);
            selectTara.SelectByText(newRegisterBO.choice);
        }

        public HomePage RegisterApplication(NewRegisterBO newRegisterBO)
        {
            //Thread.Sleep(2000);
            WaitHelpers.WaitElementIsVisible(driver, FirstName);
            TxtFirstName.SendKeys(newRegisterBO.FirstName);
            TxtLastName.SendKeys(newRegisterBO.LastName);
            TxtEmail.SendKeys(newRegisterBO.Email);
            TxtPassword.SendKeys(newRegisterBO.Password);
            TxtRepeatPassword.SendKeys(newRegisterBO.RepeatPassword);
            selectChoice(newRegisterBO);

            //Thread.Sleep(1000);
            WaitHelpers.WaitElementIsVisible(driver, SubmitReg);
            BtnSubmit.Click();
            //Thread.Sleep(1000);

            //scroll window down
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");


            Thread.Sleep(1000);

            Participant.Click();

            return new HomePage(driver);
        }

        public HomePage DuplicateEmail(NewRegisterBO newRegisterBO)
        {
            //Thread.Sleep(2000);
            WaitHelpers.WaitElementIsVisible(driver, FirstName);
            TxtFirstName.SendKeys(newRegisterBO.FirstName);
            TxtLastName.SendKeys(newRegisterBO.LastName);
            TxtEmail.SendKeys(newRegisterBO.Email);
            TxtPassword.SendKeys(newRegisterBO.Password);
            TxtRepeatPassword.SendKeys(newRegisterBO.RepeatPassword);
            selectChoice(newRegisterBO);

            //Thread.Sleep(1000);
            WaitHelpers.WaitElementIsVisible(driver, SubmitReg);
            BtnSubmit.Click();
            Thread.Sleep(1000);

            return new HomePage(driver);
        }

    }
}
