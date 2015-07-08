using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amg.UnitTests.JsRunner.Locator {
	public class QUnitElementLocator : IElementLocator {
		public IList<IWebElement> LocateAllTests(IWebElement fromElement) {
			return fromElement.FindElements(By.CssSelector("#qunit-tests > li"));
		}
		
		public string LocateModuleName(IWebElement fromElement) {
			return fromElement.FindElement(By.ClassName("module-name")).Text;
		}

		public string LocateTestName(IWebElement fromElement) {
			return fromElement.FindElement(By.ClassName("test-name")).Text;
		}

		public string LocateAssertSummary(IWebElement fromElement) {
			return fromElement.FindElement(By.ClassName("counts")).Text;
		}
		
		public IList<IWebElement> LocateAssertList(IWebElement fromElement) {
			return fromElement.FindElements(By.CssSelector(".qunit-assert-list li"));
		}

		public string LocateAssertMessage(IWebElement fromElement) {
			return fromElement.FindElement(By.ClassName("test-message")).Text;
		}

		public string LocateAssertExpected(IWebElement fromElement) {
			return fromElement.FindElement(By.CssSelector(".test-expected pre")).Text;
		}

		public string LocateAssertActual(IWebElement fromElement) {
			return fromElement.FindElement(By.CssSelector(".test-actual pre")).Text;
		}

		public string LocateAssertSource(IWebElement fromElement) {
			return fromElement.FindElement(By.CssSelector(".test-source pre")).Text;
		}

		public bool TestDidPass(IWebElement testElement) {
			return testElement.GetAttribute("class") == "pass";
		}
	}
}
