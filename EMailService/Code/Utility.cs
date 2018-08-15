using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMailService.Code
{
    public class Utility
    {
        /// <summary>
        /// Search the inout text for the tag specified and return the contents
        /// we can return either the payload (whats between the tags) or the whole thing (including the tags)
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="nodeName"></param>
        /// <param name="stripTags"></param>
        /// <returns></returns>
	    public string ExtractXMLText(string inputText, string nodeName, bool stripTags)
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
    }
}