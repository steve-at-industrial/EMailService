using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using EMailService.Models;

namespace EMailService.Code
{
    public static class Utility
    {
        /// <summary>
        /// Search the inout text for the tag specified and return the contents
        /// we can return either the payload (whats between the tags) or the whole thing (including the tags)
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="nodeName"></param>
        /// <param name="stripTags"></param>
        /// <returns></returns>
	    public static string ExtractXMLText(string inputText, string nodeName, bool stripTags)
	    {
		    try
		    {
			    var shiftedText = inputText.ToUpper();
			    var openingTag = "<" + nodeName.ToUpper() + ">";
			    var closingTag = "</" + nodeName.ToUpper() + ">";
			    var startPos = shiftedText.IndexOf(openingTag);
			    var endPos = shiftedText.IndexOf(closingTag);
				// need both tags
                if (startPos == -1 || endPos == -1)
			    {
				    return String.Empty;
			    }
				// need the starying tag BEFORE the ending tag
			    if (startPos > endPos)
			    {
				    return String.Empty;
			    }
				//
                // we have beginning and end tags so return the space in between
                //
                // do we want the tags as well?
				//
                if (stripTags)
			    {
				    startPos += openingTag.Length;
			    }
			    else
			    {
				    endPos += closingTag.Length;
			    }

			    var result = inputText.Substring(startPos, endPos - startPos);
			    return result;
		    }
		    catch (Exception ex)
		    {
			    throw new Exception("Error extracting XML text");
		    }
	    }
        /// <summary>
        /// Parse our body for an EXPENSE
        /// This is public so we can run our unit tests
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Expense GetExpenseResponse(string body)
        {
            bool foundTotalNode = false;
            var result = new Expense();
            // pull out the whole XML from the input
            var expenseText = ExtractXMLText(body, "expense", false);
            if (expenseText == String.Empty)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("Expense tag missing");
                return result;
            }
            // our text should be a valid XML structure
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(expenseText);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("Expense XML is badly formed");
                result.ErrorMessages.Add(ex.Message);
                return result;
            }

            // work through the nodes
            // assume the ones we want are directly below the parent - anything else is an invalid structure anyway
            if (xmlDoc.HasChildNodes)
            {
                var expensenode = xmlDoc.ChildNodes[0];
                XmlNodeList nodes = expensenode.ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    if (node.Name.ToLower() == "cost_centre" && !String.IsNullOrEmpty(node.InnerText))
                    {
                        result.CostCentre = node.InnerText;
                    }

                    if (node.Name.ToLower() == "total")
                    {
                        foundTotalNode = true;
                        try
                        {
                            result.Total = Convert.ToDecimal(node.InnerText);
                        }
                        catch (Exception ex)
                        {
                            result.IsValid = false;
                            result.ErrorMessages.Add("Total is not numeric");
                        }

                    }

                    if (node.Name.ToLower() == "payment_method")
                    {
                        result.Paymentmethod = node.InnerText;
                    }
                }
            }

            // rules say we need a total BUT the total might be zero so we need to check the node EXISTENCE and not it's value
            if (!foundTotalNode)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("Missing total");
            }
            return result;
        }
	    public static Reservation GetReservationResponse(string body)
	    {
		    var result = new Reservation();
		    // pull out the vendor from the input
		    var vendor = ExtractXMLText(body, "vendor", true);
		    if (vendor == String.Empty)
		    {
			    return null;
		    }
		    var description = ExtractXMLText(body, "description", true);
		    var date = ExtractXMLText(body, "date", true);
		    // ALL these fields are mandatory so anything missing is a fail
		    // note we do not need to explicitly check for invalid XML tags. A missing tag will return an emtpy value
		    if (vendor == String.Empty)
		    {
			    result.IsValid = false;
			    result.ErrorMessages.Add("Missing vendor");
		    }
		    if (description == String.Empty)
		    {
			    result.IsValid = false;
			    result.ErrorMessages.Add("Missing description");
		    }
		    if (date == String.Empty)
		    {
			    result.IsValid = false;
			    result.ErrorMessages.Add("Missing date");
		    }

		    result.Description = description;
		    result.Vendor = vendor;
		    try
		    {
			    result.ReservationDate = DateTime.Parse(date);
		    }
		    catch (Exception ex)
		    {
			    result.IsValid = false;
			    result.ErrorMessages.Add("Invalid date");
            }
		    	
		    return result;
	    }
    }
}