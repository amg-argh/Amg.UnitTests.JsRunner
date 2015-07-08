using Amg.UnitTests.JsRunner.Locator;
using Amg.UnitTests.JsRunner.TestHandlers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amg.UnitTests.JsRunner {
	//This needs an interface
	public class JsTestRunner {
		private readonly IWebDriver _driver;
		private readonly IElementLocator _elementLocator;

		public JsTestRunner(IWebDriver driver, IElementLocator elementLocator) {
			_driver = driver;
			_elementLocator = elementLocator;
		}

		private void WriteHeading(ConsoleColor color, string middleLine) {
			Console.ForegroundColor = color;
			Console.WriteLine("--------------------------------------");
			Console.WriteLine(middleLine);
			Console.WriteLine("--------------------------------------");
		}

		public bool ProcessAllTests(string url) {
			_driver.Navigate().GoToUrl(url);

			WriteHeading(ConsoleColor.Cyan, "-------- Starting JsUnitTests --------");

			int testIndex = 0;
			int failedTests = 0;

			IWebElement body = _driver.FindElement(By.TagName("body"));

			var tests = _elementLocator.LocateAllTests(body);
			foreach(IWebElement testResult in tests) {
				++testIndex;

				bool passed = _elementLocator.TestDidPass(testResult);
				TestHandler testHandler;
				if(passed){
					testHandler = new PassedTestHandler(_elementLocator, testResult, testIndex);
				}
				else {
					testHandler = new FailedTestHandler(_elementLocator, testResult, testIndex);
					failedTests++;
				}					
				testHandler.WriteOutput();
			}

			if(failedTests > 0) {
				WriteHeading(ConsoleColor.Red, String.Format("Total: {0} of {1} tests failed", failedTests, testIndex));
				return false;
			}
			else {
				WriteHeading(ConsoleColor.Green, "---------- All tests passed ----------");
				return true;
			} 
		}

	}
}
