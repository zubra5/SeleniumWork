using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HomeTaskSelenium.Entities.Interfaces
{
	public abstract class BaseComponent
	{
		protected IWebDriver driver;

		protected string handle;

		public BaseComponent(IWebDriver driver)
		{
			this.driver = driver;
			handle = this.driver.CurrentWindowHandle;
			PageFactory.InitElements(this.driver, this);
		}
	}
}
