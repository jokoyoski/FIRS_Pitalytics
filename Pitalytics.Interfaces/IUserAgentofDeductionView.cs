using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Interfaces
{
  public   interface IUserAgentofDeductionView
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is email verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is email verified; otherwise, <c>false</c>.
        /// </value>
        bool IsEmailVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is user verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is user verified; otherwise, <c>false</c>.
        /// </value>
        bool IsUserVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date verified.
        /// </summary>
        /// <value>
        /// The date verified.
        /// </value>
        System.DateTime DateVerified { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }


        // <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the firs tin.
        /// </summary>
        /// <value>
        /// The firs tin.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
         string FIRS_TIN { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
         string BVN { get; set; }

        /// <summary>
        /// Gets or sets the cac reg no.
        /// </summary>
        /// <value>
        /// The cac reg no.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
         string CACRegNo { get; set; }

        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        [Required]
         int IndustryId { get; set; }

        /// <summary>
        /// Gets or sets the website address.
        /// </summary>
        /// <value>
        /// The website address.
        /// </value>
      
           string WebsiteAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
         bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
         int UserRegistrationId { get; set; }



        /// <summary>
        /// Gets or sets the tax agent identifier.
        /// </summary>
        /// <value>
        /// The tax agent identifier.
        /// </value>
         int? AgentOfDeductionId { get; set; }
            /// <summary>
            /// 
            /// </summary>
        string ConfirmPassword { get; set; }
        /// <summary>
        /// Gets or sets the get industry list.
        /// </summary>
        /// <value>
        /// The get industry list.
        /// </value>
        IList<SelectListItem> IndustryList { get; set; }

    }
}
