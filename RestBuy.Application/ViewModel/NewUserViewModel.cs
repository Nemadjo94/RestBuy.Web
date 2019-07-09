using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RestBuy.Entities;

namespace RestBuy.Application.ViewModel
{
    public class NewUserViewModel

    {

        [Required, MaxLength(50)]

        public string Username { get; set; }



        [Required, DataType(DataType.Password)]

        public string Password { get; set; }



        [Required, DataType(DataType.Password), Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }

        [Display(Name = "Terms and Conditions")]

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree with the conditions!")]

        public bool TermsAndConditions { get; set; }





        internal User CreateUser() =>

            new User(this.Username, this.Password);



    }
}
