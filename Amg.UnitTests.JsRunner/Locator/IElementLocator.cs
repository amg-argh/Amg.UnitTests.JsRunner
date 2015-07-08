using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amg.UnitTests.JsRunner.Locator {
	public interface IElementLocator {
		IList<IWebElement> LocateAllTests(IWebElement fromElement);
		string LocateModuleName(IWebElement fromElement);
		string LocateTestName(IWebElement fromElement);
		string LocateAssertSummary(IWebElement fromElement);
		IList<IWebElement> LocateAssertList(IWebElement fromElement);
		string LocateAssertMessage(IWebElement fromElement);
		string LocateAssertExpected(IWebElement fromElement);
		string LocateAssertActual(IWebElement fromElement);
		string LocateAssertSource(IWebElement fromElement);

		bool TestDidPass(IWebElement testElement);
	}
}
