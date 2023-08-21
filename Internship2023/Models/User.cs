using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Internship2023_backend.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(maximumLength: 100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        // Secure password hashing mechanism using ASP.NET Core Identity
        public string Password { get; set; } = null!;

        public bool UserEmailConfirmed { get; set; } = false;

        private static IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public void SetPassword(string password)
        {
            this.Password = _passwordHasher.HashPassword(this, password);
        }

        public bool VerifyPassword(string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(this, Password, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
