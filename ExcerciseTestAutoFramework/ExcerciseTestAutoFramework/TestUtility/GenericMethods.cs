using System;
using ExcerciseTestAutoFramework.TestBase;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ExcerciseTestAutoFramework.TestUtility
{
    /// <summary>
    /// This class is maintain the generic methods across the application.
    /// </summary>
    class GenericMethods: TestBaseWeb
    {
        // Get the URL of the application under test
        public static string WikipediaURL = ConfigurationManager.AppSettings["WikipediaURL"];
        public static string Travelex = ConfigurationManager.AppSettings["TravelexURL"];

        /// <summary>
        /// Load the application page on the driver.
        /// Take the webapp name and mapped it config URL.
        /// </summary>
        /// <param name="webapp"></param>
        public static void LoadPage(string webapp)
        {
            CreateDriverInstance();
            if (webapp.ToLower()=="wikipedia")
            {
                driver.Navigate().GoToUrl(WikipediaURL);
            }   
            else if (webapp.ToLower()=="travelex")
            {
                driver.Navigate().GoToUrl(Travelex);
            }

            else
            {
                Assert.Fail("Parameter Application is incorrect " + webapp);
            }
        }

        /// <summary>
        /// Capture the page title to the given driver instance. 
        /// </summary>
        /// <returns> title of the page in string.</returns>
        public static string GetPageTitle()
        {
            return TestBaseWeb.driver.Title;
        }

        /// <summary>
        /// Resize the driver window. 
        /// </summary>
        /// <param name="widhth"> Xoffset </param>
        /// <param name="height">Y offset</param>
        public static void resizePage(int widhth, int height)
        {
            Size windowSize = new System.Drawing.Size(widhth, height);
            driver.Manage().Window.Size = windowSize;
        }
    }
}
