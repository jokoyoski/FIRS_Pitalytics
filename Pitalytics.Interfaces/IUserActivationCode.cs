﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IUserActivationCode
    {
        /// <summary>
        /// Gets or sets the user activation code1.
        /// </summary>
        /// <value>
        /// The user activation code1.
        /// </value>
        int UserActivationCodeId { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        int UserRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the activation code.
        /// </summary>
        /// <value>
        /// The activation code.
        /// </value>
        string ActivationCode { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        System.DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is used.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is used; otherwise, <c>false</c>.
        /// </value>
        bool IsUsed { get; set; }
       
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

    }
}
