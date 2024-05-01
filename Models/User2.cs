using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class User2
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Enter Valid Email Id")]
        [Required(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}