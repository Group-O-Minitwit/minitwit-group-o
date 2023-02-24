using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Minitwit7.data;

namespace Minitwit7.schemas
{
    public class CreateUser
    {
        [CustomValidation(typeof(CreateUser), "UniqueUsername", ErrorMessage = "The username is already taken.")]
        [StringLength(50, ErrorMessage = "The username cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "You have to enter a username")]
        public string Username { get; set; } = "";

        [CustomValidation(typeof(CreateUser), "UniqueEmail", ErrorMessage = "The email address is already registered.")]
        [Required(ErrorMessage = "You have to enter a valid email address")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "You have to enter a password")]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Invalid password format.")]
        public string PwHash { get; set; } = "";
    }


//     /*Custom validation for unique username, unique email and uniqueId , we need to have a connection to a real data base*/
//     private static int? GetUserIdByUsername(string username, DataContext context)
//     {
//         var user = context.Users.SingleOrDefault(u => u.Username == username);
//         return user != null ? User.Id : (int?)null;
//     }

//     private static User GetUserByEmail(string email, DataContext context)
//     {
//         return context.Users.SingleOrDefault(u => u.Email == email);
//     }

//     public static ValidationResult UniqueUsername(string username, ValidationContext context)
//     {
//         var controller = context.GetService(typeof(Controller)) as Controller;
//         var db = controller?.HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;

//         if (GetUserIdByUsername(username, db) != null)
//         {
//             return new ValidationResult("The username is already taken.");
//         }
//         return ValidationResult.Success;
//     }

//     public static ValidationResult UniqueEmail(string email, ValidationContext context)
//     {
//         var controller = context.GetService(typeof(Controller)) as Controller;
//         var db = controller?.HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;

//         if (GetUserByEmail(email, db) != null)
//         {
//             return new ValidationResult("The email address is already registered.");
//         }
//         return ValidationResult.Success;
//     }
}


