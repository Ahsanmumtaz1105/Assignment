using System.Configuration;
using OpenQA.Selenium;
using ExcerciseTestAutoFramework.TestBase;

namespace ExcerciseTestAutoFramework.Pages.Wikipedia
{
    /// <summary>
    /// Page Class to create object of Specific page to access it's method and properties
    /// Any action perfom over the page should be handlded here.
    /// </summary>
    class WikipediaMainPage : TestBaseWeb
    {
        // Identifiers
        public static string inputSearchBox = "search";
        public static string searchName = "searchButton";

        /// <summary>
        /// Pass Search text to the input box of search
        /// </summary>
        /// <param name="searchStringValue"></param>
        public static void InputSearch(string searchStringValue)
        {
            driver.FindElement(By.Name(inputSearchBox)).SendKeys(searchStringValue);
            driver.FindElement(By.ClassName(searchName)).Click();
        }
    }
}
