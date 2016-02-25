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

namespace KleinenijnTest
{
    [Binding] // This can only be used once.
    public partial class KleinenijnFeatureSteps
    {
        IWebDriver driver;
        string BrowserType = "Firefox";
        
        [Given(@"Ik ga naar de volgende pagina (.*)")]
        public void IkGaNaarDeVolgendePagina(string StartPage)
        {
            if (BrowserType == "Chrome")
            { driver = new ChromeDriver(); }
            else if (BrowserType == "IE")
            { driver = new InternetExplorerDriver(); }
            else if (BrowserType == "Firefox")
               { driver = new FirefoxDriver(); }
            string UrlSite = "http://www." + StartPage;                         
            driver.Navigate().GoToUrl(UrlSite);
        }

        [Given(@"Ik zie dat de pagina geladen is")]
        public void IkZieDatDePaginaGeladenIs()
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
                Assert.AreEqual("Kleinschalige Kinderopvang Kleine Nijn - uw Gastouder in Gorredijk", driver.Title);
            }
            else
            { Assert.AreEqual("Kleinschalige Kinderopvang Kleine Nijn - uw Gastouder in Gorredijk", driver.Title); }
        }

        [When(@"I enter Search Keyword in the Search Text box")]
        public void WhenIEnterSearchKeywordInTheSearchTextBox(Table table)
        {
            string searchText = table.Rows[0]["Keyword"].ToString();
            driver.FindElement(By.Name("q")).SendKeys(searchText);
        }

        [When(@"Ik klik op de knop (.*)")]
        public void IkKlikOpDeKnop(string Knop)
        {
            driver.FindElement(By.LinkText(Knop)).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [Then(@"Wordt de tekst (.*) op een pagina van de site gevonden")]
        public void WordtDeTekstOpEenPaginaVanDeSiteGevonden(String Answer)
        {
            Assert.AreEqual((Answer), driver.FindElement(By.CssSelector("td.pageName")).Text);
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
