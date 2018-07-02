using ExcerciseTestAutoFramework.TestBase;
using OpenQA.Selenium;

namespace ExcerciseTestAutoFramework.TestScripts.Wikipedia
{
    /// <summary>
    /// This class contains all possible actions/methods of SearchResults page.
    /// </summary>
    class SearchResultsPage : TestBaseWeb
    {
        // Locators Identifiers
        public static string cNameSearchDidYouMeanString = "searchdidyoumean";
        public static string xPathResultInfo = "//*[@id='mw-search-top-table']/div[2]/strong[1]";
        public static string xPathSearchResultList = "//*[@id='mw-content-text']/div[2]/ul";
        public static string partialPathLinkToSearchResult = $"/li[index]/div[index]/a";

        /// <summary>
        /// Find the Suggestion String displayed over the page.
        /// </summary>
        /// <returns>Found SuggestionString</returns>
        public static string GetSuggestionString()
        {
            IWebElement searchDidYouMean = driver.FindElement(By.ClassName(cNameSearchDidYouMeanString));
            return searchDidYouMean.Text;
        }

        /// <summary>
        /// To get the result Info displayed over the page
        /// </summary>
        /// <returns>Found result Info</returns>
        public static string GetResultInfo()
        {
            return driver.FindElement(By.XPath(xPathResultInfo)).Text;
        }

        /// <summary>
        /// To Get the count of the search results over the page
        /// </summary>
        /// <returns>Count</returns>
        public static int GetCountOfSearchResult()
        {
            IWebElement ul = driver.FindElement(By.XPath(xPathSearchResultList));
            var lstSearchResults = ul.FindElements(By.TagName("li"));
            return lstSearchResults.Count;
        }
        /// <summary>
        /// Click on the requested search result.
        /// </summary>
        /// <param name="lnkIndex"></param>
        public static void selectGivenResultLink(string lnkIndex)
        {
            string lnkToSelect = partialPathLinkToSearchResult.Replace("index", lnkIndex);
            string createPathOfResultLink = xPathSearchResultList + lnkToSelect;
            driver.FindElement(By.XPath(createPathOfResultLink)).Click();
        }
    }
}
