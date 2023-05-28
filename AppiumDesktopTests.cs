using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumTest
{
    public class Tests
    {
        private const string Appiumbaseurl = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\monka\OneDrive\Desktop\Contactbook\ContactBook-DesktopClient.NET6\ContactBook-DesktopClient.exe";
        private WindowsDriver<WindowsElement> driver;
        private WindowsDriver<WindowsElement> driverWindow;
        private AppiumOptions appiumOptions;
        private AppiumOptions appiumOptionsWindow;


        [SetUp]
        public void SetUp()
        {
            this.appiumOptions = new AppiumOptions()
            { PlatformName = "Windows" };
            appiumOptions.AddAdditionalCapability("app", appLocation);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(Appiumbaseurl), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            this.appiumOptionsWindow = new AppiumOptions()
            { PlatformName = "Windows" };
            appiumOptionsWindow.AddAdditionalCapability("app", "Root");
            this.driverWindow = new WindowsDriver<WindowsElement>(new Uri(Appiumbaseurl), appiumOptionsWindow);
            driverWindow.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.FindElementByAccessibilityId("textBoxApiUrl").SendKeys("https://simeontodorovv-1.simeontodorovv.repl.co/api");
            driver.FindElementByAccessibilityId("buttonConnect").Click();
            driverWindow.FindElementByAccessibilityId("textBoxSearch").SendKeys("steve");
            driverWindow.FindElementByAccessibilityId("buttonSearch").Click();
            var name = driverWindow.FindElementByXPath("/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@Name=\"Search Contacts\"][@AutomationId=\"SearchContactsForm\"]/DataGrid[@Name=\"Enter a keyword for searching:\"][@AutomationId=\"dataGridViewContacts\"]/Custom[@Name=\"Row 0\"]/DataItem[@Name=\"FirstName Row 0, Not sorted.\"]").Text;
            var lastname = driverWindow.FindElementByXPath("/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@Name=\"Search Contacts\"][@AutomationId=\"SearchContactsForm\"]/DataGrid[@Name=\"Enter a keyword for searching:\"][@AutomationId=\"dataGridViewContacts\"]/Custom[@Name=\"Row 0\"]/DataItem[@Name=\"LastName Row 0, Not sorted.\"]").Text;
            Assert.That(name, Is.EqualTo("Steve"));
            Assert.That(lastname, Is.EqualTo("Jobs"));
        }
    }
}