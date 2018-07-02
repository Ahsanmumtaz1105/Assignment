using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExcerciseTestAutoFramework.Pages.Wikipedia;
using ExcerciseTestAutoFramework.TestUtility;
using ExcerciseTestAutoFramework.TestBase;
using ExcerciseTestAutoFramework.TestScripts.Wikipedia;

namespace ExcerciseTestAutoFramework.TestScripts.WebTest.Wikipedia
{
    [TestClass]
    public class TestWikipedia
    {
        public string webapplication = "Wikipedia";     // declare the webapplication

        [TestCategory("Travelex"), TestCategory("WebTest"), TestMethod]
        public void TestPageTitle()
        {
            // Test Data 
            string expectedPageTitle = "Wikipedia, the free encyclopedia";
            GenericMethods.LoadPage(webapplication); // Load the Wikipedia page
            string actualPageTitle = GenericMethods.GetPageTitle(); // Get the title of the page 
            CustomValidator.AreEquals(expectedPageTitle, actualPageTitle, "Page title Mismatched");
        }

        [TestCategory("Travelex"), TestCategory("WebTest"), TestMethod]
        public void TestDidYouMeanSuggestion()
    {
        // Test Data
        string searchString = "furry rabbits";
        string expectedString  = "Did you mean: fury rabbit";

        GenericMethods.LoadPage(webapplication); // Load the Wikipedia page
        WikipediaMainPage.InputSearch(searchString);  // Search string to the input box and click search
        string actualSuggestionString = SearchResultsPage.GetSuggestionString(); 
        CustomValidator.AreEquals(expectedString, actualSuggestionString, "Suggestion String mismatched");
    }

        [TestCategory("Travelex"), TestCategory("WebTest"), TestMethod]
        public void TestSearchResultsCount()
        {
            // Test Data
            string suggestionString = "furry rabbits";
            string expectedResultInfo = "1 – 21";
            int expectedResultCount = 20;

            GenericMethods.LoadPage(webapplication); // Load the Wikipedia page
            WikipediaMainPage.InputSearch(suggestionString);  // Input search string to the input box and click search
            string resultInfo = SearchResultsPage.GetResultInfo();
            CustomValidator.AreEquals(expectedResultInfo, resultInfo, "Result info mismatched");
            int actualResultCount = SearchResultsPage.GetCountOfSearchResult(); // ResultInfo count  
            CustomValidator.AreEquals(expectedResultCount, actualResultCount,
                "Expected search result count is mismatched to actual");

        }

        [TestCategory("Travelex"), TestCategory("WebTest"), TestMethod]
        public void TestFirstResultTitleAndContentTable()
        {
            // Test Data
            string suggestionString = "furry rabbits";
            string selectResultIndex = "1"; // Select First Link from the result info
            string expectedAarticleTitle = "Furry fandom - Wikipedia";

            GenericMethods.LoadPage(webapplication); // Load the Wikipedia page
            WikipediaMainPage.InputSearch(suggestionString);  // Input search string to the input box and click search
            SearchResultsPage.selectGivenResultLink(selectResultIndex); // Select the first article
            string actualArticlePageTitle = GenericMethods.GetPageTitle();  // Title of the page
            CustomValidator.AreEquals(expectedAarticleTitle, actualArticlePageTitle, "Title mismatched");
            ArticlePage.CheckTableOfContents(); // Verify the Table of Content on article page.
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestBaseWeb.driver.Quit();  // Destroy the driver object in clean up
        }

    }
}
    

