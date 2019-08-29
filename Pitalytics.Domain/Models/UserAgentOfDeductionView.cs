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
   public  class UserAgentOfDeductionView :IUserAgentofDeductionView
    {

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        
         public  string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public   string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public     string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// 
        [Required]
        [StringLength(100,ErrorMessage ="The {0} must be at least {2} characters long.",MinimumLength =6)]
        [DataType(DataType.Password)]

        public string Password { get; set; }


        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password do not match.")]
        public  string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// 

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
        /// Gets or sets a value indicating whether this instance is email verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is email verified; otherwise, <c>false</c>.
        /// </value>
     public    bool IsEmailVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is user verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is user verified; otherwise, <c>false</c>.
        /// </value>
      public  bool IsUserVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
     public    bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
     public    System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date verified.
        /// </summary>
        /// <value>
        /// The date verified.
        /// </value>
     public    System.DateTime DateVerified { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
       public string ProcessingMessage { get; set; }


        // <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the firs tin.
        /// </summary>
        /// <value>
        /// The firs tin.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string FIRS_TIN { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string BVN { get; set; }

        /// <summary>
        /// Gets or sets the cac reg no.
        /// </summary>
        /// <value>
        /// The cac reg no.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CACRegNo { get; set; }

        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        [Required]
        public int IndustryId { get; set; }

        /// <summary>
        /// Gets or sets the website address.
        /// </summary>
        /// <value>
        /// The website address.
        /// </value>
         public string WebsiteAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }

      
       
        /// <summary>
        /// Gets or sets the tax agent identifier.
        /// </summary>
        /// <value>
        /// The tax agent identifier.
        /// </value>
        public int? AgentOfDeductionId { get; set; }

        /// <summary>
        /// Gets or sets the get industry list.
        /// </summary>
        /// <value>
        /// The get industry list.
        /// </value>
        public IList<SelectListItem> IndustryList { get; set; }

    }




}
