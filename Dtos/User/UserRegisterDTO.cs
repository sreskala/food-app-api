using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace food_tracker_api.Dtos.User
{
    public class UserRegisterDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}