using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ExcerciseTestAutoFramework.TestBase;
using ExcerciseTestAutoFramework.TestUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcerciseTestAutoFramework.Pages.Wikipedia
{
    /// <summary>
    /// This class contains all possible action/methods, properties of Article Page
    /// Display after search.
    /// </summary>
    class ArticlePage: TestBaseWeb
    {
        // Identifier
        public static string idTableOfContent = "toc";
        public static string tagNameTableHeading = "h2";
        public static string xpathListTableOfContent = "//*[@id='toc']/ul";

        /// <summary>
        /// Verify the table of content presents or not article page
        /// </summary>
        public static void CheckTableOfContents()
        {
            IWebElement divTableOfContent = driver.FindElement(By.Id(idTableOfContent));
            string heading = divTableOfContent.FindElement(By.TagName(tagNameTableHeading)).Text;
            CustomValidator.IsNotNullOrEmpty(heading, "There is no Heading");
            IWebElement ul = driver.FindElement(By.XPath(xpathListTableOfContent));
            var lstSearchResults = ul.FindElements(By.TagName("li"));
            foreach(IWebElement lstItem in lstSearchResults)
            {
                CustomValidator.IsNotNullOrEmpty(lstItem.Text, "List Item is missing"); 
            }



        }
    }
}
