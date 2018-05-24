using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HomeTaskSelenium.Utils
{
	public static class Waiter
	{
		private const int TimeoutSec = 10;
		public static void WaitDocumentCompleteState(IWebDriver driver)
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(TimeoutSec)).Until((d) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
		}
	}
}
