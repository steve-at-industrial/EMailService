using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMailService.Models
{
    public class Expense
    {
		public string CostCentre { get; set; }
		public string Paymentmethod { get; set; }
		public decimal Total { get; set; }
		public bool IsValid { get; set; }
		public List<string> ErrorMessages { get; set; }

	    public  Expense()
	    {
		    IsValid = true;
		    ErrorMessages = new List<string>();
		    CostCentre = "UNKNOWN";
	    }
    }
}