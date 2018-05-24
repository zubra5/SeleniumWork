using HomeTaskSelenium.Entities.Interfaces;
using OpenQA.Selenium;
using System.Globalization;
using HomeTaskSelenium.Utils;
using HomeTaskSelenium.Utils.Extentions;
namespace HomeTaskSelenium.Entities
{
	using OpenQA.Selenium.Remote;

	public class Section : BaseComponent
	{
		private IWebElement mainArticleElement;

		protected IWebElement element {
			get
			{
				string selector = string.Format(CultureInfo.CurrentCulture, "//header/h2/a[text()='{0}']", this.Name);
				return driver.FindElement(By.XPath(selector));
			}
		}

		public Article MainArticle { get; set; }

		public string TitleMainArticle { get; set; }

		public string Name { get; set; }

		public Section(string name, IWebDriver driver)
			: base(driver)
		{
			Name = name;
			string selector = string.Format(CultureInfo.CurrentCulture, "//header/h2/a[text()='{0}']", this.Name);
			IWebElement parentElement = element.FindElement(By.XPath("//ancestor::div[contains(@class, 'b-main-page-grid-4')]"));
			mainArticleElement = parentElement.FindElement(By.XPath("//div[contains(@class,'b-main-page-news-2__main-news-title')]/h2/a"));
			this.MainArticle = new Article();
			this.MainArticle.Title = mainArticleElement.Text;
			this.MainArticle.Link.IsClickable = (driver as RemoteWebDriver).IsClickable(mainArticleElement);
		}

		public void OpenMainArticle()
		{
			mainArticleElement.Click();
			Waiter.WaitDocumentCompleteState(this.driver);
		}
	}
}
