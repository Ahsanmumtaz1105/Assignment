using System.Configuration;
using ExcerciseTestAutoFramework.TestBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace ExcerciseTestAutoFramework.Pages.Travelex
{   
    /// <summary>
    /// This class is to captured all possible action/methods, properties of HomePage of Travelex app.
    /// </summary>
    class HomePage : TestBaseWeb
    {
        // Get the URL of the application under test
        public static string WikipediaURL = ConfigurationManager.AppSettings["TavelexURL"];

        // Identifier

        public static string headingSlider = "h4";
        public static string cssSliderHeader = "div[class='sliderdb slick-slide slick-active']";

        /// <summary>
        /// Get the default Article on Display after page resize.
        /// </summary>
        /// <returns>Heading of the article</returns>
        public static string DefaultArticleOnDisplay()
        {
            var slider = driver.FindElement(By.CssSelector(cssSliderHeader));
            Actions actions = new Actions(driver);
            actions.MoveToElement(slider);
            actions.Perform();
            string sliderHeading = slider.FindElement(By.TagName(headingSlider)).Text;
            return sliderHeading;
        }
        /// <summary>
        /// Slide left the article using Mouse drag, and return the new article heading
        /// </summary>
        /// <returns></returns>
        public static string SlideLeftAndGetTheLandingSlide()
        {
            var BeforeslideElement = driver.FindElement(By.CssSelector(cssSliderHeader));
            var sliderHeader = BeforeslideElement.FindElement(By.TagName(headingSlider));
            Actions move = new Actions(driver);
            move.DragAndDropToOffset(sliderHeader, -100, 0).Build().Perform();
            Thread.Sleep(4000);
            var afterSlideElement = driver.FindElement(By.CssSelector(cssSliderHeader));
            string afterSlideHeading = afterSlideElement.FindElement(By.TagName(headingSlider)).Text;
            return afterSlideHeading;
        }
    }
}

