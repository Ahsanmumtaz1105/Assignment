using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcerciseTestAutoFramework.TestBase
{
   /// <summary>
   /// Test Base class of Web based application. 
   /// It contains the properties and methods to create web driver.
   /// </summary>
    public class TestBaseWeb
    {
        public static string browser;
        public static IWebDriver driver;
        /// <summary>
        /// To Create a web driver instance. 
        /// Intialize the web driver instance based on the configured or passed Browser 
        /// </summary>

        public static void CreateDriverInstance()
        {
            browser = ConfigurationManager.AppSettings["Browser"];
            if (browser.ToLower() == "firefox")
            {
                driver = new FirefoxDriver();
            }
            else if (browser.ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Window.Maximize();
            TimeSpan timeoutValue = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = timeoutValue;
        }

        /// <summary>
        /// Overloaded method, take browser and create the browser instance.
        /// </summary>
        /// <param name="browser"> get browser</param>
        /// <returns></returns>

        public static IWebDriver CreateDriverInstance(string browser)
        {
            try
            {
                if (browser.ToLower() == "firefox")
                {
                    driver = new FirefoxDriver();
                }
                else if (browser.ToLower() == "edge")
                {
                    driver = new EdgeDriver();
                }
                else if (browser.ToLower() == "chrome")
                {
                    driver = new ChromeDriver();
                }

                driver.Manage().Window.Maximize();
                TimeSpan timeoutValue = TimeSpan.FromSeconds(60);
                driver.Manage().Timeouts().ImplicitWait = timeoutValue;
                return driver;
            }
            catch (Exception exp)
            {
                Assert.Inconclusive(exp.Message, "Browser Instance Creation failed");
                return null;
            }
        }


    }
}

