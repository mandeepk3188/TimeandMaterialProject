using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections;

namespace Time_MaterialsAutomationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ///{URL Navigation}

            IWebDriver driver = new FirefoxDriver(@"C:\VisualStudio\Drivers");
            driver.Url = "http://horse-dev.azurewebsites.net";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            ///{LoginPage}
            var loginlink = driver.FindElement(By.Id("loginLink"));
            loginlink.Click();
            Console.WriteLine("Login tab clicked");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            ///{User Credentials}
            var username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("ray");
            Console.WriteLine("Username entered");
            var password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");
            var submitbtn = driver.FindElement(By.CssSelector("input.btn.btn-default"));
            submitbtn.Click();
            Thread.Sleep(1000);
            ///{Administartion Tab Navigation}
            var admintab = driver.FindElement(By.CssSelector("a.dropdown-toggle"));
            admintab.Click();
            Console.WriteLine("Admin tab clicked");

            ///{Time&Materials Tab Navigation}
            var time_mat_tab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            Console.WriteLine(time_mat_tab.Text);
            time_mat_tab.Click();
            Thread.Sleep(1000);
            ///{AutomationTestCases_for_Time&Materials}

            ///{Create_New button verfication}
            var createnew_btn = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            createnew_btn.Click();
            ///{Entry Verification}
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var typecode = driver.FindElement(By.CssSelector("span.k-select:nth-child(2)"));
            typecode.Click();
            Console.WriteLine(typecode.Text);

            Thread.Sleep(1000);

            var typecode_time = driver.FindElement(By.XPath("/html/body/div[5]/div/ul/li[2]"));
            typecode_time.Click();
            Console.WriteLine(typecode_time.Text);

            var code = driver.FindElement(By.Id("Code"));
            code.SendKeys("Testing");

            var description = driver.FindElement(By.Id("Description"));
            description.SendKeys("Testing Module");
            Thread.Sleep(1000);
            var price = driver.FindElement(By.CssSelector(".k-formatted-value"));
            //var priceunit = price.FindElement(By.CssSelector("input.k-.k-input"));
            //var unit = priceunit.FindElement(By.ClassName("k-input"));
            // var priceunit = price.FindElement(By.Id("Price"));
            //price.Click();

            price.SendKeys("23");
            Thread.Sleep(1000);
            var savebtn = driver.FindElement(By.Id("SaveButton"));
            savebtn.Click();

        }
    }
}


 