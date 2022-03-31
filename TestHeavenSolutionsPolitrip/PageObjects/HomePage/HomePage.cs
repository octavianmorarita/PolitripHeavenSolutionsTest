using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestHeavenSolutionsPolitrip.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement BtnCookies => driver.FindElement(By.Id("cookiescript_close"));
        public By SignUp = By.XPath("//a[@id='qa_header-signup']");
        public IWebElement BtnSignUp => driver.FindElement(By.XPath("//a[@id='qa_header-signup']"));

        public IWebElement btnMyProfile => driver.FindElement(By.Id("qa_header-profile"));

        public void hoverMouseIcon()
        {
            Actions action = new Actions(driver);
            IWebElement btnIcon = driver.FindElement(By.CssSelector("span[class=profile-icon]"));
            action.MoveToElement(btnIcon).Perform();

        }

    }
}
