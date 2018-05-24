using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeTaskSelenium.Entities.Interfaces;
using OpenQA.Selenium;

namespace HomeTaskSelenium.Entities
{
	using HomeTaskSelenium.Utils;

	public class OrderPage: BaseComponent
	{
		private const string MenuItem = "Заказы на сервисе «Услуги»";

		private const string Title = "Заказы на услуги";

		public bool IsOpened {
			get
			{
				return this.driver.Title == Title;
			}
		}
		public OrderPage(IWebDriver driver)
			: base(driver)
		{

		}

		public void Open()
		{
			if (IsOpened)
			{
				return;
			}

			PersonalMenu menu = new PersonalMenu(this.driver);
			menu.Select(MenuItem);
			Waiter.WaitDocumentCompleteState(this.driver);
		}

		public bool NewOrder(string section, string title, string description)
		{
			if (!IsOpened)
			{
				this.Open();
			}
			this.driver.FindElement(By.ClassName("project-navigation__button ng-scope")).Click();
			SelectSection(section);
			TypeTitle(title);
			TypeDescription(description);
			this.driver.FindElement(By.XPath("//button[contains(@class,'service-form__button')]")).Click();
			return ValidateCreatingOfNewOrder();
		}

		private void SelectSection(string section)
		{
		}

		private void TypeTitle(string title)
		{
		}

		private void TypeDescription(string description)
		{
		}

		private bool ValidateCreatingOfNewOrder()
		{
			return false;
		}
	}
}
