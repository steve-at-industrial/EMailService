using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMailService.Code;


namespace EMailService.Tests
{
    [TestClass]
    public class Utility
    {
        [TestMethod]
        public void Test_ExtractXMLText_AllValid()
        {
	        var inputText = "<START>Test</START>";
	        var nodeName = "START";
	        var result = EMailService.Code.Utility.ExtractXMLText(inputText, nodeName, true);
	        Assert.AreEqual("Test", result);
        }

	    [TestMethod]
	    public void Test_Expense_AllValid()
	    {
		    var inputText = "<expense><cost_centre>c</cost_centre><total>123.45</total><payment_method>cash</payment_method></expense>";
		    var result = EMailService.Code.Utility.GetExpenseResponse(inputText);
			Assert.IsTrue(result.IsValid);
		    Assert.AreEqual("c", result.CostCentre);
			Assert.AreEqual("cash",result.Paymentmethod);
			Assert.AreEqual(Convert.ToDecimal(123.45),result.Total);
	    }

	    [TestMethod]
	    public void Test_Expense_MissingCostCentre()
	    {
		    var inputText = "<expense><cost_centre></cost_centre><total>123.45</total><payment_method>cash</payment_method></expense>";
		    var result = Code.Utility.GetExpenseResponse(inputText);
		    Assert.IsTrue(result.IsValid);
		    Assert.AreEqual("UNKNOWN", result.CostCentre);
	    }

	    [TestMethod]
	    public void Test_Expense_MissingTotal()
	    {
		    var inputText = "<expense><cost_centre>c</cost_centre><payment_method>cash</payment_method></expense>";
		    var result = Code.Utility.GetExpenseResponse(inputText);
		    Assert.IsFalse(result.IsValid);
		    Assert.AreEqual(1, result.ErrorMessages.Count);
		    Assert.AreEqual("Missing total", result.ErrorMessages[0]);
	    }

	    [TestMethod]
	    public void Test_Expense_BadlyFormedXML()
	    {
		    var inputText = "<expense><cost_centre>c</cost_centre><payment_method>cash</payment_method>";
		    var result = Code.Utility.GetExpenseResponse(inputText);
		    Assert.IsFalse(result.IsValid);
		    Assert.AreEqual(1, result.ErrorMessages.Count);
		    Assert.AreEqual("Expense tag missing", result.ErrorMessages[0]);
	    }

	    [TestMethod]
	    public void Test_Reservation_AllValid()
	    {
		    var inputText = "<vendor>vendor</vendor><description>description</description><date>12 August 2017</date>";
		    var result = Code.Utility.GetReservationResponse(inputText);
		    Assert.IsTrue(result.IsValid);
	    }

    }
}
