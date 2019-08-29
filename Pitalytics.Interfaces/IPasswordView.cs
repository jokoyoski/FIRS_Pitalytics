using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pitalytics.Interfaces
{
    public interface IPasswordView
    {
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        string code { get; set; }

        /// <summary>
        /// Gets or sets the code.
        [Required]
        [DisplayName("New Password")]
        string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "wrong")]
        string ConfirmPassword { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int userId { get; set; }


    }
}