using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Models
{
    public class TaxAuthorityView : ITaxAuthorityView
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// 
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public   string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        /// 
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public   string LastName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// 
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public  string Email { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// 
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        public   string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password do not match.")]
      public string ConfirmPassword { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the revenue identifier.
        /// </summary>
        /// <value>
        /// The revenue identifier.
        /// </value>
    public    int InlandRevenueId { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        /// 
        [Required]
     public   int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the tax authority identifier.
        /// </summary>
        /// <value>
        /// The tax authority identifier.
        /// </value>
        /// 
        [Required]
        public int TaxAuthorityId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the inland revenue names.
        /// </summary>
        /// <value>
        /// The inland revenue names.
        /// </value>
        public IList<SelectListItem> InlandRevenueNames { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction names.
        /// </summary>
        /// <value>
        /// The jurisdiction names.
        /// </value>
        public IList<SelectListItem> JurisdictionNames { get; set; }

    }
}





