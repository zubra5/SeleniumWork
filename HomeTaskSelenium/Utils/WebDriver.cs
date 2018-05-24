using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace HomeTaskSelenium.Utils
{
	public static class WebDriver
	{
		public static IWebDriver Init()
		{
			string browserName = AppConfig.Instance.BrowserName;
			IWebDriver instance;

				switch (browserName)
				{
					case "Chrome":
						ChromeOptions choptions = new ChromeOptions();
						instance = new ChromeDriver(choptions);
						break;

					case "FireFox":
					FirefoxOptions ffOptions = new FirefoxOptions();
						ffOptions.Profile = InitFirefoxProfile();
						ffOptions.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
						ffOptions.UseLegacyImplementation = true;
						instance = new FirefoxDriver(ffOptions);
						break;

					case "Internet Explorer":
						instance = new InternetExplorerDriver(InitIeOptions());
						break;

					case "Microsoft Edge":
						EdgeOptions edgeOptions = new EdgeOptions();
						instance = new EdgeDriver(edgeOptions);
						break;

					default:
						instance = new ChromeDriver();
						break;
				}
			
			instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			try
			{
				instance.Manage().Window.Maximize();
			}
			catch (NoSuchElementException) { }
			return instance;
		}

		private static InternetExplorerOptions InitIeOptions()
		{
			InternetExplorerOptions options = new InternetExplorerOptions();
			options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
			options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
			options.EnablePersistentHover = false;
			options.RequireWindowFocus = true;
			return options;
		}


		/// <summary>
		/// Initializes firefox
		/// </summary>
		private static FirefoxProfile InitFirefoxProfile()
		{
			FirefoxProfile profile = new FirefoxProfile();
			profile.SetPreference("browser.download.dir", AppConfig.Instance.WorkDir);
			profile.SetPreference("browser.download.folderList", 2);
			profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/x-excel, application/x-msexcel, application/excel, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword");
			profile.SetPreference("browser.helperApps.neverAsk.openFile", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/x-excel, application/x-msexcel, application/excel, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword");
			profile.SetPreference("intl.accept_languages", AppConfig.Instance.LocaleCode);
			return profile;
		}
	}
}
