using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amg.UnitTests.JsRunner.TestHandlers;
using Amg.UnitTests.JsRunner.Locator;

namespace Amg.UnitTests.JsRunner {
	class Program {
		static int Main(string[] args) {

			if(args.Length == 0) {
				Console.WriteLine("You must provide the URL to unit test web page as the first command line argument");
				return 1;
			}

			string url = args[0];
			
			PhantomJSDriver driver = new PhantomJSDriver();
			try { 
				IElementLocator locator = new QUnitElementLocator();
				JsTestRunner runner = new JsTestRunner(driver, locator);

				bool allTestsPassed = runner.ProcessAllTests(url);
				int result = allTestsPassed ? 0 : 1;

				return result;				
			}
			finally {
				driver.Quit();
				driver.Dispose();
			}

			
		}
	}
}
