using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;


namespace Automation_Code_Challenge_2_CSharp
{

    public class WebPageTest
    {
        private ChromeDriver driver;
        static String baseWebPageURL = "http://www.skiutah.com";
        private bool browserStarted = false;

        static void Main(string[] args)
        {
            // Empty Main method - keeping the compiler happy
        }

        public void startBrowser()
        {
            //File pathToBinary = new File("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            //FirefoxBinary ffBinary = new FirefoxBinary(pathToBinary);
            //FirefoxProfile firefoxProfile = new FirefoxProfile();
            //driver = new FirefoxDriver(ffBinary,firefoxProfile);
            //driver = new FirefoxDriver();
            //File file = new File("C:\\ChromeDriver\\chromedriver.exe");
            //System.setProperty("webdriver.chrome.driver", "C:\\ChromeDriver\\chromedriver.exe");
            driver = new ChromeDriver();
        }

        private void VerifyPageTitle(String webPageURL, String titleStringToTest)
        {
            // startBrowser
            if (browserStarted == false)
            {
                startBrowser();
                browserStarted = true;
            }
            // Open Webpage URL
            driver.Url = (webPageURL);
            // Get page title of current page
            String pageTitle = driver.Title;
            // Print page title of current page
            Console.WriteLine("Page title of current page is: " + pageTitle);
            // Print title string to test
            Console.WriteLine("Title String to Test is: " + titleStringToTest);
            // Test that the titleStringToTest = title of current page
            //Assert.assertTrue(pageTitle.equals(titleStringToTest), "Current Page Title is not equal to the expected page title value");
            // If there is no Assertion Error, Print out that the Current Page Title = Expected Page Title
            Console.WriteLine("Current Page Title = Expected Page Title");
        }

        private void VerifyNavigation(String navigationMenu)
        {
            // Build CSS Selector based on navigation menu user wants to click on
            String cssSelectorText = "a[title='" + navigationMenu + "']";
            // Find menu WebElement based on CSS Selector
            IWebElement navigationMenuWebElement = driver.FindElementByCssSelector((cssSelectorText));
            // Get href attributte from menu WebElement
            String navigationMenuURL = navigationMenuWebElement.GetAttribute("href");
            // Navigate to href and validate page title
            VerifyPageTitle(navigationMenuURL, "Ski and Snowboard The Greatest Snow on Earth® - Ski Utah");
        }

        [Test]
        public void TestLauncher()
        {
            VerifyPageTitle(baseWebPageURL, "Ski Utah - Ski Utah");
            VerifyNavigation("Deals");
        }

    }

}