﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Account
{
    public class RegisterVm
    {
        [MinLength(3)]
        public string Name { get; set; }
        [MinLength(3)]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
    