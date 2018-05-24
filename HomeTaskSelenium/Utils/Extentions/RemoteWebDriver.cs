using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace HomeTaskSelenium.Utils.Extentions
{
	public static class RemoteWebDriver
	{
		public static bool IsClickable(this OpenQA.Selenium.Remote.RemoteWebDriver driver, IWebElement element)
		{
			if (element != null && element.Displayed && element.Enabled)
			{
				return true;
			}
				
			return false;
		}

	}
}
