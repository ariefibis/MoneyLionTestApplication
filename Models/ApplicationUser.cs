using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLionTestApplication.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string DOB { get; set; }
        public string Name { get; set; }

        public string SSN { get; set; }
    }
}
