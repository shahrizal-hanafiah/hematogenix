﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hematogenix.Shared.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
