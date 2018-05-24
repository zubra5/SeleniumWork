using System;
using System.Configuration;

namespace HomeTaskSelenium.Utils
{
	public class AppConfig
	{
		private static AppConfig config;

		public static AppConfig Instance
		{
			get
			{
				if (config == null)
				{
					config = new AppConfig();
				}
				return config;
			}
		}

		private AppConfig()
		{

		}
		
		public string Password => ConfigurationManager.AppSettings["Password"];

		public string LoginName => ConfigurationManager.AppSettings["LoginName"];

		public string WorkDir => ConfigurationManager.AppSettings["WorkDir"] + (ConfigurationManager.AppSettings["WorkDir"].EndsWith("\\") ? "" : "\\");

		public string LocaleCode => ConfigurationManager.AppSettings["LocaleCode"];
		
		public string BrowserName => ConfigurationManager.AppSettings["BrowserName"];

		public bool ShouldLogOn => Convert.ToBoolean(ConfigurationManager.AppSettings["ShouldLogOn"]);
	}

}
