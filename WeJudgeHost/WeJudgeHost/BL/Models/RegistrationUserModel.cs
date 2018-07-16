using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeJudgeHost.BL.Models
{
    public class RegistrationUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
    }
}
