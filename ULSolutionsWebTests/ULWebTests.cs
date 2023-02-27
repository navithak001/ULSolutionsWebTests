using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ULTechnologyTests
{
    [TestFixture]
    public class ULWebTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.ul.com/";

            driver.Manage().Window.Maximize();            
        }

        [Test]
        public void Given_Navigated_To_UL_Solutions_Verify_Footer_Headings()
        {
                     
            var headings = ListOfFooterHeadings();
            Assert.AreEqual(headings.Count, 3);
            Assert.True(headings.Contains("Careers".ToUpper()));
            Assert.True(headings.Contains("Help and Support".ToUpper()));
            Assert.True(headings.Contains("Contact Center".ToUpper()));   
            

        }

        [Test]
        public void Given_Navigated_To_UL_Solutions_Verify_Navigation_To_WorkingAtULSolutions()
        {   
            Thread.Sleep(500);
            Allowcookies();
            Thread.Sleep(500);
            WorkingAtULSolutions();
            Thread.Sleep(500);
        }

        [Test]
        public void Given_Navigated_To_UL_Solutions_Verify_Navigation_To_GlobalJobSearch()
        {
            Thread.Sleep(500);
            Allowcookies();
            Thread.Sleep(500);
            GlobalJobSearch();
            Thread.Sleep(500);
        }

        [Test]
        public void Given_Navigated_To_UL_Solutions_Verify_Navigation_To_USJobSearch()
        {
            Thread.Sleep(500);
            Allowcookies();
            Thread.Sleep(500);
            USJobSearch();
            Thread.Sleep(500);
        }

        //DenyCookies
        public void Denycookies()
        {
            IWebElement DenycookieButton = driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonDecline"));
            DenycookieButton.Click();

        }

        //AllowCookies
        public void Allowcookies()
        {
            IWebElement AllowcookieButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            AllowcookieButton.Click();
        }        

        public List<string> ListOfFooterHeadings()
        {
            List<string> subHeadings = new List<string>();
            var footerElems = driver.FindElements(By.ClassName("menu-item-no-link"));
            for (int i = 0; i < footerElems.Count; i++)
            {                
                subHeadings.Add(footerElems[i].Text);
            }
            
            return subHeadings;
        }

        //Working at ULSolutions
        public void WorkingAtULSolutions()
        {
            IWebElement WorkingAtULSolutions = driver.FindElement(By.XPath("//a[@title='Working at UL Solutions']"));
            WorkingAtULSolutions.Click();
            driver.Navigate().Back();
        }

        public void GlobalJobSearch()
        {
            IWebElement GlobalJobSearch = driver.FindElement(By.XPath("//a[@title='Global Job Search ']"));
            GlobalJobSearch.Click();
            driver.Navigate().Back();
        }

        public void USJobSearch()
        {
            IWebElement USJobSearch = driver.FindElement(By.XPath("//a[@title='US Job Search']"));
            USJobSearch.Click();
            driver.Navigate().Back();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
