using System;
using HomeTaskSelenium.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using HomeTaskSelenium.Entities;

namespace HomeTaskSelenium.Tests
{
	[TestFixture]
	public class MainTest
	{
		private IWebDriver _driver;

		private const string SectionName = "Люди";
		private const string Url = "https://www.onliner.by/";

		[SetUp]
		public void SetUp()
		{
			_driver = WebDriver.Init();
			_driver.Navigate().GoToUrl(Url);
		}

		[Test]
		public void WorkWithPeopleSection()
		{
			//sign in
			if (AppConfig.Instance.ShouldLogOn)
			{
				StartPage startPage = new StartPage(_driver);
				bool isLogOn = startPage.LogOn(AppConfig.Instance.LoginName, AppConfig.Instance.Password);
				Assert.IsTrue(isLogOn, "You are not log in");
			}

			//verify link for main article is clickable
			Section peopleSection = new Section(SectionName, this._driver);
			Article mainArticle = peopleSection.MainArticle;
			Assert.IsTrue(mainArticle.Link.IsClickable, "Link for main article is not clickable");

			//open first article
			peopleSection.OpenMainArticle();

			//verify article title
			ArticlePage mainArticlePage = new ArticlePage(this._driver);
			Assert.AreEqual(
				mainArticlePage.Article.Title,
				mainArticle.Title,
				"Article title is not the same for ‘Article’ details and ‘News’ pages");
		}

		[TearDown]
		public void TearDown()
		{
			try
			{
				((IJavaScriptExecutor)_driver).ExecuteScript("window.close();");
				_driver.Close();
			}
			catch (Exception) { }
			_driver.Quit();
			_driver = null;
		}
	}
}
