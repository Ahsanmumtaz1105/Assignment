# Assignment
A Bare bones test automation framework to test Web/API app using MS VS 2015 unit testing framework.
Here I used custome page object model. Where each application page is mapped to a class and can be identify by their page name. 
Put into a repository called pages.
Created TestBase repository, to contain TestBaseWeb and TestBaseAPI. Objective is to use same framework to maintain Web and API automation tests.
There is another repository called TestScripts which which again having sub directories called WebTest and APITest, to segreegate web and API tests.
WebTest contains again having subdirectories on the application under test name i.e. Travelex, Wikipedia to contains specific application test, 
for better mantainability and readability.
Created a TestUtility repository to contain any generic actions, and validator class. 
Validator class is extension of Asserts, idea of having this to capture screenshot on every failure and log details in the putput.
Use Excapsulation, Inheritance to reusable code and less maintainability.
Test Scripts does not contain any direct call to webdriver. This way, if any changes happend to the application, it handles to the pageClassess 
and a few changes to handle the changes and TestScripts need not be changed. It's basically loosely bind with webdriver.
Web driver instance created only once in Testbase and it access to the page classes by inherting the Testbase class.
All configuration is set into App.Config i.e. AUT URL, API URL, Test Result Repo, Screenshot directory.
Test can be run through commnand line using MSTest. I've added category i.e. WebTest, APITest and AUT name i.e. Travelex, Wikipedia.
One can run the tests from command line using MSTest following is an example
MSTest /testcontainer: Assignment\ExcerciseTestAutoFramework\ExcerciseTestAutoFramework\bin\Debug\ExcerciseTestAutoFramework.dll /category:"WebTest"

Note: I didn't get time to write APITest, as I was out of this weekend. Though, I love to work on APITest as well if time permits.
