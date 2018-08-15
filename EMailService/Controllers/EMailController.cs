using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EMailService.Models;

namespace EMailService.Controllers
{
	// we get an Email inbound but dont know what kind of messafe it contains until we parse it
    public class EMailController : ApiController
    {
	    // POST: api/EMail
        public async Task<IHttpActionResult> PostEmail(string body)
	    {
		    if (!ModelState.IsValid)
		    {
			    return BadRequest(ModelState);
		    }
			//
			// Parse the incoming body and see what we have
			// We are looking for:
			// EITHER an XML dom with EXPENSE as the parent node
			// OR a series of tags relating to a vendor reservation
			//
		    var expense = new Expense();
            return Ok(expense);
	    }
    }
}
