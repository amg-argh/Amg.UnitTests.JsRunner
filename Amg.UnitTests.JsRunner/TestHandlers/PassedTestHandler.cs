using Amg.UnitTests.JsRunner.Locator;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amg.UnitTests.JsRunner.TestHandlers {
	public class PassedTestHandler : TestHandler {

		public PassedTestHandler(IElementLocator elementLocator, IWebElement testElement,int testIndex) : base(elementLocator, testElement,testIndex) { }

		public override ConsoleColor OutputColor {
			get { return ConsoleColor.Green; }
		}

		protected override string TitlePrefix {
			get { return "Passed"; }
		}

		protected override void WriteSpecific() {
		}
	}
}
