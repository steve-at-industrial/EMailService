using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMailService.Models
{
    public class Reservation
    {
		public string Vendor { get; set; }
		public string Description { get; set; }
		public DateTime ReservationDate { get; set; }
	    public bool IsValid { get; set; }
	    public List<string> ErrorMessages { get; set; }
	    public Reservation()
	    {
		    IsValid = true;
		    ErrorMessages = new List<string>();
	    }
    }
}