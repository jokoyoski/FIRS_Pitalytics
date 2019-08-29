using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
  public  interface IChangePasswordView
    {
        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        [Required]
        [DisplayName("Old Password")]
        string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        [Required]
        [DisplayName("New Password")]
        string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm new password.
        /// </summary>
        /// <value>
        /// The confirm new password.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]
        string ConfirmNewPassword { get; set; }

        string ProcessingMessage { get; set; }
    }
}
