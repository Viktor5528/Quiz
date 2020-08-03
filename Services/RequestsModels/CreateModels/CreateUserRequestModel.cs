using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Requests
{
   public class CreateUserRequestModel
    {
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
