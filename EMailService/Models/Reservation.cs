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
    }
}