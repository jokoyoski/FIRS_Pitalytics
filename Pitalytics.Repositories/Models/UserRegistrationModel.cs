using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Repositories.Models
{

 
    public class UserRegistrationModel : IUserRegistration
    {
        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is email verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is email verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmailVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is user verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is user verified; otherwise, <c>false</c>.
        /// </value>
        public bool? IsUserVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date verified.
        /// </summary>
        /// <value>
        /// The date verified.
        /// </value>
        public System.DateTime DateVerified { get; set; }
    }

    public class EmailVerificationView :IEmailVerificationView
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>

        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
       public  string ProcessingMessage { get; set; }
    }
}

