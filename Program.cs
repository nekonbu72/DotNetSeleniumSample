
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotNetSeleniumSample
{
    class HelloSelenium
    {
        static void Main()
        {
            // カレントディレクトリに geckodriver.exe を置く
            var currentDir = Directory.GetCurrentDirectory();
            using (IWebDriver driver = new FirefoxDriver(currentDir))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl("https://www.google.com/ncr");
                driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
                var firstResult = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h3>div")));
                Console.WriteLine(firstResult.GetAttribute("textContent"));
            }
        }
    }
}