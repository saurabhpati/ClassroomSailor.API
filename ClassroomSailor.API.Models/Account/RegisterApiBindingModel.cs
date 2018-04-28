using System;
using System.ComponentModel.DataAnnotations;

namespace ClassroomSailor.API.Models.Account
{
    public class RegisterApiBindingModel
    {
        [Required(ErrorMessage = "Username  is required")]
        [StringLength(128, ErrorMessage = "Username cannot exceed 128 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare(nameof(Password), ErrorMessage = "Does not match with Password.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(255, ErrorMessage = "First name cannot be more than 255 characters.")]
        public string FirstName { get; set; }

        [StringLength(255, ErrorMessage = "Middle name cannot be more than 255 characters")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(255, ErrorMessage = "First name cannot be more than 255 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        [StringLength(128, ErrorMessage = "Email cannot exceed 128 characters")]
        public string Email { get; set; }

        [StringLength(16)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date of birth")]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
