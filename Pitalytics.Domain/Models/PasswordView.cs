using  Pitalytics.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pitalytics.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPasswordView" />
    public class PasswordView:IPasswordView
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        
        public string code { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [DisplayName("Password")]
      public  string Password { get; set; }
        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password do not match.")]
        public   string ConfirmPassword { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int userId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }


    }
}
