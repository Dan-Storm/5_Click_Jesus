#Dan Storm Junior Developer HPA Automation Technical Challenge

## Research Process

After reading through the instructions, the majority of tasks are new to me. I will need to research most all of them to complete this challenge.

My first google search is “automate web page console application c#”

After reading several responses on Stack Overflow and a few blog posts it seems like Selenium WebDriver might be my best option. Having never used Selenium WebDrive before, my next course of action is to read several blog posts and watch a few youtube tutorials to familiarize myself with what the framework does. Before I start coding, I want to make sure that Selenium does what I need it to do.

I have watched several tutorials on basic selenium automation and feel confident that this is the approach I would like to use to tackle this challenge.

I have created a new C# .NET Framework console application in Visual Studio and installed Selenium.WebDriver as well as Selenium.WebDriver.ChromeDriver

***First Task*** open browser to Specific URL and click box 1.
One of the tutorials I watched referenced this specific action. I go back and rewatch that section of the tutorial to find this solution.

***Second Task***  Dismiss the alert.
Here I hit a bit of a roadblock. I didn’t consider that I would have to dismiss the alert so I carried on to trying Step 2 on the website. After I ran into a runtime error, I had to backtrack to figure out what had gone wrong. I did a quick search on dismissing alerts in selenium and found my solution in a blog post. Since I figured I would need to dismiss several alerts, I created and internal method to perform this task.

***Third Task*** focus on box 2 and send tab key.
This one was fairly straightforward. The documentation for SendKeys was helpful here.

***Fourth Task***  Select radio button
Here I hit another roadblock. I didn’t realize at first that the option to select was changing dynamically. Once I did, the solution came quickly. By parsing out a stackoverflow post in Java I was able to target the value between the span tags and use it to dynamically select the correct radio button.

***Fifth Task*** Select variable from dropdown
Ready for a dynamically changing required value from my experience with the previous task, I refreshed the page several times to see if the value was changing. When I discovered it was, I used a similar method as I did on the previous task to dynamically get the correct value from the dropdown.

***Sixth Task*** Fill out and submit form 
Here I hit another roadblock. I didn’t realize until I tried targeting the value from the second date input that they had the same Id, as did the city, state, and country inputs. I knew then that I had to target the fields in a different way. XPath was the first idea that came to mind. Researching a little more, I decided that absolute path was a good option for targeting the fields. After some trial and error where I manually tried to enter the absolute XPath, I couldn’t get it to work. So I searched for a way to find the absolute XPath. I found a google chrome extension called ChroPath which targeted the element and generated the absolute XPath. With this tool, I was able to easily find the absolute and relative paths of the rest of the inputs and fill them in dynamically with the placeholder text. Then I targeted the submit button and clicked it.

***Seventh Task*** Capture the result of the form submission and paste it into X line after scrolling to X line.
Ready for another dynamic task, I knew I would have to get the input value in the same way as I had before. I used that input value to dynamically scroll to the correct input. I found how to do this on Stack Overflow. I stored the result, cleared the input field and inserted the result.

***Eighth Task*** Click through the remaining boxes 
I knew this one couldn’t be so simple as clicking the remaining boxes and after observing the wait times between clicks several times, discovered that they varied. I targeted the javascript and created a loop that clicked through the boxes and dismissed the alerts after the maximum possible interval set by the javascript. 
# 5_Click_Jesus
