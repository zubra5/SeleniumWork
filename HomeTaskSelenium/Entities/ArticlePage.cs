using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeTaskSelenium.Entities.Interfaces;
using OpenQA.Selenium;

namespace HomeTaskSelenium.Entities
{
	public class ArticlePage : BasePage
	{
		public Article Article
		{
			get
			{
				Article result = new Article();
				result.Title = this.driver.FindElement(By.XPath("//div[contains(@class,'news-header__title')]")).Text;
				return result;
			}
		}

		public ArticlePage(IWebDriver driver)
			: base(driver)
		{

		}
	}
}
