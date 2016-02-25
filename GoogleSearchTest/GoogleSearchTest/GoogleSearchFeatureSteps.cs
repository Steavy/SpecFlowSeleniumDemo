using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace GoogleSearchTest
{
    [Binding] // This can only be used once.
    public partial class GoogleSearchFeatureSteps
    {
        IWebDriver driver;
        string BrowserType = "Firefox";
        
        [Given(@"I navigate to the page (.*)")]
        public void GivenINavigateToThePage(string StartPage)
        {
            if (BrowserType == "Chrome")
            { driver = new ChromeDriver(); }
            else if (BrowserType == "IE")
            { driver = new InternetExplorerDriver(); }
            else if (BrowserType == "Firefox")
               { driver = new FirefoxDriver(); }
            string UrlGoogle = "https://www." + StartPage + ".bd";                         
            driver.Navigate().GoToUrl(UrlGoogle);
        }

        [Given(@"I see the page is loaded")]
        public void GivenISeeThePageIsLoaded()
        {
           if (BrowserType == "IE") 
                {
                Assert.AreEqual("WebDriver", driver.Title);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3000));
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

                {
                    if (wait == null)
                        wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

                    //wait.Until(driver);
                    wait.Until(d => d.FindElement(By.Id("hplogo")));
                }
                Assert.AreEqual("Google", driver.Title);
            }
            else
            { Assert.AreEqual("Google", driver.Title); }
        }

        [When(@"I enter Search Keyword in the Search Text box")]
        public void WhenIEnterSearchKeywordInTheSearchTextBox(Table table)
        {
            string searchText = table.Rows[0]["Keyword"].ToString();
            driver.FindElement(By.Name("q")).SendKeys(searchText);
        }

        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()
        {
            driver.FindElement(By.Name("btnG")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [Then(@"Search items (.*) shows the items related to SpecFlow")]
        public void ThenSearchItemsShowsTheItemsRelatedToSpecFlow(String Answer)
        {
            Assert.AreEqual((Answer), driver.FindElement(By.XPath("//h3/a")).Text);
            driver.Close();
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
            driver.Dispose();// Actively dispose it, doesn't seem to do so itself
        }
    }
}
