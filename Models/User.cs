using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Lastname")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Enter Valid Email Id")]
        [Required(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Password")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage ="Enter Valid Contact Number")]
        [Display(Name = "ContactNo")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DOB { get; set; }

     
        [Required(ErrorMessage ="Please Enter Valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Please Confirm Your Password")]
        [Compare("Password",ErrorMessage ="Passwords did not match")]
        public string Confirm{ get; set; }

       
       
    }
}