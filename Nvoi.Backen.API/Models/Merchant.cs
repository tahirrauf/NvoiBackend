using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nvoi.Backen.API.Models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string RegisteredName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebURL { get; set; }
        public DateTime DateModifield { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public string Logo { get; set; }
        public int AddressId { get; set; }
    }
}