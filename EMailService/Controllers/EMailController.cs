using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using EMailService.Code;
using EMailService.Models;

namespace EMailService.Controllers
{
	// we get an Email inbound but dont know what kind of messafe it contains until we parse it
    public class EMailController : ApiController
    {
	    public async Task<IHttpActionResult> GetExpense(string body)
	    {
		    if (!ModelState.IsValid)
		    {
			    return BadRequest(ModelState);
		    }

		    var expense = Utility.GetExpenseResponse(body);
		    return Ok(expense);
	    }

	    public async Task<IHttpActionResult> GetReservation(string body)
	    {
		    if (!ModelState.IsValid)
		    {
			    return BadRequest(ModelState);
		    }

		    var reservation = Utility.GetReservationResponse(body);
		    return Ok(reservation);
        }




    }
}
