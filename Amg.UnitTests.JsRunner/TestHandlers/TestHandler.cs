using Amg.UnitTests.JsRunner.Locator;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amg.UnitTests.JsRunner.TestHandlers {
	public abstract class TestHandler {


		protected IElementLocator _elementLocator;
		protected IWebElement _testElement;
		protected int _testIndex;

		public abstract ConsoleColor OutputColor { get; }
		protected abstract string TitlePrefix { get; }

		public TestHandler(IElementLocator elementLocator, IWebElement testElement, int testIndex) {
			this._elementLocator = elementLocator;
			this._testElement = testElement;
			this._testIndex = testIndex;

			Console.ForegroundColor = OutputColor;
		}

		public void WriteOutput() {
			string moduleName = _elementLocator.LocateModuleName(_testElement);
			string testName = _elementLocator.LocateTestName(_testElement);
			string asserts = _elementLocator.LocateAssertSummary(_testElement);

			Console.WriteLine("{0}. {4} - {1}: {2} ({3})", _testIndex, moduleName, testName, asserts, TitlePrefix);

			WriteSpecific();
		}



		protected abstract void WriteSpecific();
	}
}
