﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TicketWebServices.Models
{
    public partial class UserDetail
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsAdmin { get; set; }
        public string Email { get; set; }
    }
}
