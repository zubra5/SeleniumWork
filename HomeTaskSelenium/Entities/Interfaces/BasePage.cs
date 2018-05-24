using OpenQA.Selenium;
using HomeTaskSelenium.Utils;

namespace HomeTaskSelenium.Entities.Interfaces
{
	public abstract class BasePage : BaseComponent
	{
		public BasePage(IWebDriver driver) : base(driver)
		{
		
		}

		public virtual void SwitchTo(bool waitCompleteState)
		{
			driver.SwitchTo().Window(handle);
			if (waitCompleteState)
			{
				Waiter.WaitDocumentCompleteState(driver);
			}
		}

		public virtual void Close()
		{
			driver.SwitchTo().Window(handle);
			driver.Close();
		}
	}
}
