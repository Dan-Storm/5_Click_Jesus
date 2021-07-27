using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace HPATechnicalChallengeAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            // Navigate to test URL
            driver.Navigate().GoToUrl("http://hpadevtest.azurewebsites.net/");

            // Step 1 click Box 1
            driver.FindElement(By.Id("Box1")).Click();

            //Dismiss Alert
            DismissAlert();

            // Step 2 set focus on Box 2 and send the 'tab' key
            driver.FindElement(By.Id("Box3")).SendKeys(Keys.Tab);

            //Dismiss Alert
            DismissAlert();

            // Step 3 select radio button
            String optionVal = driver.FindElement(By.Id("optionVal")).Text;
            var radioButton = driver.FindElement(By.XPath($"//input[@value='{optionVal}']"));
            radioButton.Click();

            //Dismiss Alert
            DismissAlert();

            //Step 4 select can from dropdown
            String selectionVal = driver.FindElement(By.Id("selectionVal")).Text;
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select")));
            select.SelectByValue($"{selectionVal}");

            //Dismiss Alert
            DismissAlert();

            // Step 5
            // get placeholder value and autofill input field
            var path = "/html[1]/body[1]/div[5]/center[1]/div[1]/div[1]/div[1]/center[1]/table[1]/tbody[1]/";
            for (var i = 1; i <= 9; i++)
            {
                var form = driver.FindElement(By.XPath($"{path}tr[{i}]/td[1]/input[1]"));
                String formData = driver.FindElement(By.XPath($"{path}tr[{i}]/td[1]/input[1]"))
                    .GetAttribute("placeholder");
                form.SendKeys(formData);
            }

            var submitButton = driver.FindElement(By.XPath("//button[contains(text(),'Submit')]"));
            submitButton.Click();

            //Dismiss Alert
            DismissAlert();

            // Step 6 scroll to X and insert result of step 5
            var result = driver.FindElement(By.Id("formResult")).Text;
            var inputNumStr = driver.FindElement(By.Id("lineNum")).Text;
            // Convert string to number
            var inputNum = Convert.ToInt32(inputNumStr);
            var resultInput = driver.FindElement(By.XPath($"/html[1]/body[1]/div[4]/center[1]/div[1]/center[1]/table[1]/tbody[1]/tr[{inputNum}]/td[2]/input[1]"));

            // Scroll to specified input
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", resultInput);
            // Clear input field
            resultInput.Clear();
            // Submit result
            resultInput.SendKeys(result);
            resultInput.SendKeys(Keys.Enter);

            //Dismiss Alert
            DismissAlert();

            // Step 7 click Box 7-10 and wait 6 seconds between each.
            for (var i = 7; i <= 10; i++)
            {
                driver.FindElement(By.Id($"Box{i}")).Click();
                // Pause thread for 6 seconds
                Thread.Sleep(6000);
                //Dismiss Alert
                DismissAlert();
            }

            void DismissAlert()
            {
                // Dismiss Alert
                driver.SwitchTo().Alert().Accept();
            }
        }
    }
}