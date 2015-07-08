using Amg.UnitTests.JsRunner.Locator;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amg.UnitTests.JsRunner.TestHandlers {
	public class FailedTestHandler : TestHandler {

		public FailedTestHandler(IElementLocator elementLocator, IWebElement testElement,int testIndex) : base(elementLocator, testElement,testIndex) { }

		public override ConsoleColor OutputColor {
			get { return ConsoleColor.Red; }
		}

		protected override string TitlePrefix {
			get { return "Failed"; }
		}


		protected override void WriteSpecific() {
			var assertList = _elementLocator.LocateAssertList(_testElement);

			int assertIndex = 0;

			foreach(IWebElement assert in assertList) {
				++assertIndex;

				string message = _elementLocator.LocateAssertMessage(assert);
				Console.WriteLine(" -- {0}. {1}", assertIndex, message);

				if(_elementLocator.TestDidPass(assert)) {
					continue;
				}

				string expected = _elementLocator.LocateAssertExpected(assert);
				string actual = _elementLocator.LocateAssertActual(assert);
				string source = _elementLocator.LocateAssertSource(assert);
				
				Console.WriteLine("    -- Expected: {0}", expected);
				Console.WriteLine("    -- Actual  : {0}", actual);
				Console.WriteLine("    -- Source  : {0}", source);
			}
		}
	}
}
