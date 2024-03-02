using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OfficeOpenXml;
using System.IO;

namespace SeleniumUnitTest
{
    [TestClass]
    public class SampleTest
    {
        IWebDriver driver;
        [TestMethod]
        public void Login()
        {
            string edgeDriverPath = @"F:\CSE\SeleniumUnitTest2\SeleniumUnitTest2\SeleniumUnitTest\drivers\";
            EdgeOptions options = new EdgeOptions();
            driver = new EdgeDriver(edgeDriverPath, options);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://carepro-training.ihmafrica.com/");
            Thread.Sleep(9000);

            //login
            driver.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div/div[1]/input")).SendKeys("tester");
            Thread.Sleep(800);
            driver.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div/div[2]/div[2]/input")).SendKeys("tester2023!");
            Thread.Sleep(800);
            driver.FindElement(By.XPath(" //*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div/div[4]/button")).Click();
            Thread.Sleep(8000);


        }

        [TestMethod]
        public void addvital()
        {
            Login();
            //selection
            IWebElement lovTriggerElement1 = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[1]/div[1]/select"));
            lovTriggerElement1.Click();
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement lovPopup1 = wait1.Until(driverr =>
                driver.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div[1]/div[1]/select")).Displayed ? driver.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div[1]/div[1]/select")) : null);
            Thread.Sleep(800);
            IWebElement valueToSelect1 = lovPopup1.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div[1]/div[1]/select/option[6]"));
            valueToSelect1.Click();


            IWebElement lovTriggerElement2 = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[1]/div[2]/select"));
            lovTriggerElement1.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement lovPopup2 = wait2.Until(driverr =>
                driver.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div[1]/div[2]/select")).Displayed ? driver.FindElement(By.XPath("//*[@id='root']/div[2]/div[2]/div/div/div[3]/form/div[1]/div[2]/select")) : null);
            Thread.Sleep(2000);
            IWebElement valueToSelect2 = lovPopup2.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[1]/div[2]/select/option[6]"));
            valueToSelect2.Click();


            IWebElement lovTriggerElement3 = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[1]/div[3]/div/div[2]/input"));
            lovTriggerElement3.Click();
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement lovPopup3 = wait3.Until(driverr =>
                driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[1]/div[3]/div/div[2]/input")).Displayed ? driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[1]/div[3]/div/div[2]/input")) : null);
            Thread.Sleep(2500);
            IWebElement valueToSelect3 = lovPopup3.FindElement(By.XPath("//*[@id='test_scroll_2']/div/div/div[1]"));
            valueToSelect3.Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div/div[3]/form/div[3]/button")).Click();
            Thread.Sleep(8000);

            //NRC
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/div/div[2]/form/div[1]/div/div/input")).SendKeys("111111111");
            Thread.Sleep(800);
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/div/div[2]/form/div[2]/button")).Click();
            Thread.Sleep(2000);

            //attend patient
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/div/div[3]/div/div/div/div[2]/div[2]/button[3]")).Click();
            Thread.Sleep(8000);

            //vital
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/div/div/div[2]/div/div[2]/a/div")).Click();
            Thread.Sleep(8000);

            //add new records
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div/div/div[1]/div/button")).Click();
            Thread.Sleep(8000);

            //data entry
            try
            {
               
                string filePath = @"F:\CSE\SeleniumUnitTest2\SeleniumUnitTest2\Sample Dataset.csv";
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("CSV file not found: " + filePath);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

               
                Random random = new Random();
                int randomRowIndex = random.Next(1, lines.Length); 
                string randomRow = lines[randomRowIndex]; 

                string[] values = randomRow.Split(',');

                if (values.Length != 11)
                {
                    Console.WriteLine($"Invalid number of columns in CSV file at random row.");
                    return;
                }

                string col1 = values[0];
                string col2 = values[1];
                string col3 = values[2];
                string col4 = values[3];
                string col5 = values[4];
                string col6 = values[5];
                string col7 = values[6];
                string col8 = values[7];
                string col9 = values[8];
                string col10 = values[9];
                string col11 = values[10];

                // FillDataToWebpage(driver, col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11);
                FillDataToWebpage(driver, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10]);

            }
            finally
            {

            }
        }

        static void FillDataToWebpage(IWebDriver driver, string col1, string col2, string col3, string col4, string col5, string col6, string col7, string col8, string col9, string col10, string col11)
        {
            
            IWebElement weight = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[3]/div/input"));
            weight.Clear();
            weight.SendKeys("col4");
            Thread.Sleep(800);
            IWebElement height = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[4]/div/input"));
            height.Clear();
            height.SendKeys("col5");
            Thread.Sleep(800);
            IWebElement temp = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[5]/div/input"));
            temp.Clear();
            temp.SendKeys("col6");
            Thread.Sleep(800);
            IWebElement systolic = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[6]/div/input"));
            systolic.Clear();
            systolic.SendKeys("col7");
            Thread.Sleep(800);
            IWebElement diastolic = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[7]/div/input"));
            diastolic.Clear();
            diastolic.SendKeys("col8");
            Thread.Sleep(800);
            IWebElement PR = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[9]/div/input"));
            PR.Clear();
            PR.SendKeys("col9");
            Thread.Sleep(800);
            IWebElement res = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[10]/div/input"));
            res.SendKeys("col10");
            Thread.Sleep(800);
            IWebElement os = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[1]/div/div/div/div[11]/div/input"));
            os.SendKeys("col11");
            Thread.Sleep(800);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 1000)");
            IWebElement submitButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/div/div[2]/div/div/div[2]/div/form/div[2]/div/button[2]/span"));
            submitButton.Click();
        
        }
    }

   
}


