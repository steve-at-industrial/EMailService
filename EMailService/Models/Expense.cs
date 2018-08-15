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
    }
}