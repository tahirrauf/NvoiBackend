using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nvoi.Backen.API.Models
{
    public class Address
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Id { get; set; }
    }
}