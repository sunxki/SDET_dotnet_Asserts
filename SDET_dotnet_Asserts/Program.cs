 using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//input[@class='gLFyf gsfi']");
        By GoogleSearIcon = By.XPath("//div[@class='FPdoLc lJ9FBc']//following::input[@class='gNO89b']");
        By UnoSquareGoogleResult = By.XPath("//div//following::h3[@class='LC20lb DKV0Md' and contains(text(),'Unosquare: Digital Transformation Services | Agile')]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//a[@class='nav-link' and text()='Services']");
        By PracticeAreas = By.XPath("//a[@class='nav-link' and text()='Practice Areas']");
        By ContactUs = By.XPath("//a[contains(@class,'nav-link') and text()='Contact Us']");
        By OurDNA = By.XPath("//a[contains(@class,'nav-link') and text()='Our Dna']");
        By Articles_Events = By.XPath("//a[contains(@class,'nav-link') and text()='Articles & Events']");
        By h2Text = By.XPath("//h2[contains(text(),'digital transform')]");
        #endregion 
        static void Main(string[] args)
        {

            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            //Write the locator for the Google Search Bar
            element = Browser.FindElement(program.GoogleSearchBar);

            // Write Assert True that element is present [Google Search] button
            Assert.IsTrue(Browser.FindElement(program.GoogleSearchBar).Displayed);

            //Send the text "Unosquare" to the Text Bar
            program.SendText(element, "Unosquare");

            // Find the Search Button
            element = Browser.FindElement(program.GoogleSearIcon);
            // Click on the Search Button
            program.Click(element);

            // Write Assert Equal [Unosquare: Digital Transformation Services | Agile Staffing ...] vs [Element.text]

            // Locate the first result corresponding to Unosquare and click on the Link
            element = Browser.FindElement(program.UnoSquareGoogleResult);
            Assert.AreEqual("Unosquare: Digital Transformation Services | Agile Staffing ...", element.Text);
            program.Click(element);

            // Write Assert True that element is present [Our Dna] menu object
            Assert.IsTrue(Browser.FindElement(program.OurDNA).Displayed);

            // Write Assert True that element is present [Articles & Events] menu object
            Assert.IsTrue(Browser.FindElement(program.Articles_Events).Displayed);

            // Write Assert Equal [Digital transformation solutions] vs [Element.text] h2 object
            Console.WriteLine(Browser.FindElement(program.h2Text).Text);
            Assert.IsTrue(Browser.FindElement(program.h2Text).Text.Contains("DIGITAL TRANSFORMATION"));


            //Locate the Service Menu and Click the element
            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            //Locate the Practice Areas Menu and Click the Element
            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            //Locate the Contact Us Menu and Click the Element
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

        }
    }
}
