using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExcerciseTestAutoFramework.TestBase;
using OpenQA.Selenium;
using System.Diagnostics;
using System;
using System.Configuration;

namespace ExcerciseTestAutoFramework.TestUtility
{
    /// <summary>
    /// Extension of UnitTesting Assert methods. Inherit TestBaseWeb class
    /// Capture screen shot when test fails. And log the stack trace on the failure
    /// </summary>
    class CustomValidator : TestBaseWeb
    {
        /// <summary>
        /// To compare the expected and actual object passed. 
        /// Fail the test if mismatched and log the message.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>

        public static string errScreenShot = ConfigurationManager.AppSettings["ErrorScreenShot"];
        public static void AreEquals(object expected, object actual, string message)
        {
            try
            {
                // compare the type of objects exepected vs actual.
                TestContext.ReferenceEquals(expected.GetType(), actual.GetType());
                Assert.AreEqual(expected, actual, message); // Compare the actual vs expected.
            }
  
            catch (AssertFailedException exp)
            {
                Console.WriteLine(exp.Message.ToString());
                // Get call stack
                StackTrace stackTrace = new StackTrace();
                // Get calling method name
                string testMethodName = stackTrace.GetFrame(1).GetMethod().Name;
                // Get the timestamp i.e.20180630180244
                String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot(); // Take the screenshot.
                string errorPageName = testMethodName + timeStamp;  // file name of the error file. 
                ss.SaveAsFile(errScreenShot + errorPageName + ".png", ScreenshotImageFormat.Png);
                driver.Quit();  // Distroy the driver object.
                Debug.WriteLine(exp.ToString());    // Write the detail failure in the output.
                Assert.Fail();  // failed the test.

            }
            // Catch the ReferenceEquals method exception,  report type mismatched, and the test
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
                driver.Quit();  // Destroy the driver object.
                Assert.Fail();  // Fail the test.
            }
        }

        /// <summary>
        /// Verify that object should not be null.
        /// Fail the test if mismatched and log the message, also captured the screenshot
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        public static void IsNotNullOrEmpty(object actual, string message)
        {
            try
            {
                if (actual == null)
                {
                    Assert.Fail("Object is Null");
                }
                if (actual.GetType() == typeof(string))
                {
                    Assert.AreNotEqual(Convert.ToString(actual), "", "Object is Empty");
                }
            }

            catch (AssertFailedException exp)
            {
                Console.WriteLine(exp.Message.ToString());
                // Get call stack
                StackTrace stackTrace = new StackTrace();
                // Get calling method name
                string testMethodName = stackTrace.GetFrame(1).GetMethod().Name;

                // Get the timestamp i.e.20180630180244
                String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string errorPageName = testMethodName + timeStamp;
                ss.SaveAsFile(errScreenShot + errorPageName + ".png", ScreenshotImageFormat.Png);
                driver.Quit();
                Debug.WriteLine(exp.ToString());
                Assert.Fail();

            }
        }
    }
}
