using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WoltersKluwerAssignment
{
    public class BrowserManager
    {
        IWebDriver driver { get; set; }

        public IWebDriver LaunchApplication()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://todomvc.com/examples/react/dist/";
            return driver;
        }

        public void CloseApplication()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}