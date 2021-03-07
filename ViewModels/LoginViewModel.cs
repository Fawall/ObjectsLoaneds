using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ObjectsLoaneds.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email {get; set;}
        
        [Required]
        [Display(Name = "Usuário")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }


    }
}
