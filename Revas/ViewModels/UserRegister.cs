﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revas.ViewModels
{
    public class UserRegister
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}