using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringCTWebClient.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CompanyId { get; set; }
    }
}