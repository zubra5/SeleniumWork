using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeTaskSelenium.Entities.Interfaces;
using OpenQA.Selenium;

namespace HomeTaskSelenium.Entities
{
	public class PersonalMenu : BaseComponent
	{
		public PersonalMenu(IWebDriver driver)
			: base(driver)
		{
		}

		public void Expand()
		{
		}

		public void Collapse()
		{
		}

		public void Select(string menuItem)
		{

		}
	}
}
