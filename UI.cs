using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;


namespace BritQAUITesting
{
    public class Tests
    {
        IWebDriver driver;
        //Locators
        public By locSearchButton = By.CssSelector("button[aria-label='Search button']");
        public By locSearchArea = By.CssSelector("input[placeholder='Search for people, services or...']");
        public By locResults = By.CssSelector("div[class='result'] a");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.britinsurance.com/ ");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test1()
        {
            Thread.Sleep(10);
            driver.FindElement(locSearchButton).Click();
            Thread.Sleep(10);
            driver.FindElement(locSearchArea).SendKeys("IFRS 17");
            Thread.Sleep(3);
            IReadOnlyCollection<IWebElement> lstResultselments = driver.FindElements(locResults);
            List<String> lstResults = new List<string>();
            foreach (IWebElement elment in lstResultselments)
            {
                lstResults.Add(elment.Text);
            }
            Assert.IsTrue(lstResults.Contains("Financials"));
            Assert.IsTrue(lstResults.Contains("Interim results for the six months ended 30 June 2022"));
            Assert.IsTrue(lstResults.Contains("Results for the year ended 31 December 2023"));
            Assert.IsTrue(lstResults.Contains("Interim Report 2023"));
            Assert.IsTrue(lstResults.Contains("Kirstin Simon"));
        }

        [TearDown]
        public void DeleteWebDriver()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}