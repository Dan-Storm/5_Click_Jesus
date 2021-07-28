using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Click_Jesus
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            // Navigate to random Wikipedia page
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Special:Random");

            //List of words script will reference 
            var jesusWords = new List<string>{
                "JESUS", "CATHOLIC", "POPE", "BISHOP", "PREIST", "RELIGION", "FAITH", "GOD", "BAPTIST",
                "METHODIST", "LUTHERAN", "PASTOR", "BIBLE", "THEOLOGY", "MEXICO", "ITALY", "ROME", "VATICAN", "GUATEMALA", "UNITED STATES", "SPAIN", "SPANISH", "LATIN",
                "CANADA", "UNITED KINGDOM", "IRELAND", "FRANCE", "GERMANY", "ALBANIA", "BELARUS", "GREECE", "RUSSIA", "MACEDONIA", "ROMANIA", "UKRAINE",
                "AUSTRALIA", "BRAZIL", "ARGENTINA", "COLUMBIA", "CHILE", "PARAGUAY", "ANDORRA", "CROATIA", "POLAND", "MALTA", "MONACO", "PHILIPPEANS", "VENEZUELA",
                "HAITI", "COSTA RICA", "AFRICA", "SOUTH AMERICA", "NORTH AMERICA", "EUROPE", "ASIA", "AMERICA", "FRENCH", "ITALIAN", "INDIA", "CHINA", "CHRIST", "CHURCH"
                };

            var lastLinkClicked = null;

            for(var i = 1; i <= 5; i++)
                {     
                        HMElement match = null;
                        var anchorTags = driver.GetElementsByTagName("a");
                        foreach(string word in jesusWords)
                        {
                            foreach(var item in anchorTags)
                            {
                                    if (item.InnerHtml == null)
                                    {
                                            continue;
                                    }            
                                    if(item.InnerHtml.ToUpper().Contains(word) && item.GetAttribute("href").ToUpper().Contains("WIKI") && !item.InnerHtml.ToUpper().Contains("IMG") && !item.InnerHtml.ToUpper().Contains("LATTER") && !item.InnerHtml.ToUpper().Contains("NAME_OF"))
                                    {
                                        match = item;
                                        Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!found link containing {word}");
                                        break;
                                    }
                                    else
                                            continue;                                    
                            }
                            Console.WriteLine();
                            Console.WriteLine($"!!!!!!!!!!!!!{word}");
                            Console.WriteLine();
                            if(match != null)
                            {
                                    match.Click();
                                    lastLinkClicked = match;
                                    Console.WriteLine();
                                    Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Clicked link containing {word}. Click Number {i}");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        if(match == null)
                        {
                            for(var x = 1; x <= anchorTags.Count; i++)
                            {           
                                    Console.WriteLine();
                                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!NOT THAT LINK");
                                    Console.WriteLine();
                                    Random r = new Random();
                                    int rInt = r.Next(0, anchorTags.Count);
                                    var randomLink = driver.GetElementsByTagName("a")[rInt];
                                if(randomLink.GetAttribute("href").ToUpper().Contains("WIKI")  && !randomLink.GetAttribute("href").ToUpper().Contains("EDIT"))
                                            {
                                                randomLink.Click();
                                                lastLinkClicked = randomLink;
                                                break;
                                            }
                                    else
                                            {
                                                continue;   
                                            }
                            }
                            Thread.Sleep(3000);
                            Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!picked random link with the {i} click");
                        }
                        if(browser.GetURL == "https://en.wikipedia.org/wiki/Jesus")
                        {
                            Console.WriteLine($"You found Jesus in {i} clicks. Holy Spirit that's awesome!");
                            break;
                        }
                }
        }
    }
}