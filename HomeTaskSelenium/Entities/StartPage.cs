using HomeTaskSelenium.Entities.Interfaces;
using OpenQA.Selenium;
using System.Linq;
using HomeTaskSelenium.Utils;

namespace HomeTaskSelenium.Entities
{
	public class StartPage:BasePage
	{
		public StartPage(IWebDriver driver)
			: base(driver)
		{

		}

		public bool LogOn(string username, string password)
		{
			this.driver.FindElement(By.CssSelector(".auth-bar__item--text")).Click();
			Waiter.WaitDocumentCompleteState(this.driver);
			IWebElement usernameElement = this.driver.FindElement(By.XPath("//input[@data-field='login' and @type='text']"));
			IWebElement passwordElement = this.driver.FindElement(By.XPath("//input[@data-field='login' and @type='password']"));
			usernameElement.Clear();
			usernameElement.SendKeys(username);
			passwordElement.Clear();
			passwordElement.SendKeys(password);
			this.driver.FindElement(By.CssSelector("button.auth-box__auth-submit")).Click();
			Waiter.WaitDocumentCompleteState(this.driver);
			if (this.driver.FindElements(By.XPath("//div[@id='auth-container']")).Count > 0)
			{
				this.driver.FindElement(By.CssSelector(".modal-close")).Click();
				return false;
			}

			driver.SwitchTo().Window(driver.WindowHandles.Last());
			return true;
		}
	}
}
