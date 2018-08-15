using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMailService.Tests
{
    [TestClass]
    public class Utility
    {
        [TestMethod]
        public void Test_ExtractXMLText_AllValid()
        {
			var utility = new EMailService.Code.Utility();
	        var inputText = "<START>Test</START>";
	        var nodeName = "START";
	        var result = utility.ExtractXMLText(inputText, nodeName, true);
	        Assert.AreEqual("Test", result);
        }
    }
}
