using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExcerciseTestAutoFramework.Pages.Travelex;
using ExcerciseTestAutoFramework.TestUtility;
using ExcerciseTestAutoFramework.TestBase;
using System.Collections.Generic;


namespace ExcerciseTestAutoFramework.TestScripts.WebTest.Travelex
{
    [TestClass]
    public class TestTravelex
    {
        public string webapplication = "Travelex";  // Appication under test

        [TestMethod]
        public void TestArticlesSlider()
        {
            // Test Data
            int width = 550;    // size in pixels
            int height = 800;   // size in pixels
            // Slider data
            List<string> sliderHeading = new List<string>(new string[] { "Travelex Money Card",
                "International money transfer", "Buy foreign currency", "Track rates" });

            GenericMethods.LoadPage(webapplication); // Load the Wikipedia page
            GenericMethods.resizePage(width, height);
            string headingArticle = HomePage.DefaultArticleOnDisplay();
            CustomValidator.AreEquals(sliderHeading[0], headingArticle, "Default Article Mismatched");
            // Verify heading of each article after sliding left
            for (int i = 1; i < sliderHeading.Count; i++)
            {
                headingArticle = HomePage.SlideLeftAndGetTheLandingSlide();
                CustomValidator.AreEquals(sliderHeading[i], headingArticle, "After Slide Arrticle Mismatched");
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            TestBaseWeb.driver.Quit();
        }

    }
}
    

