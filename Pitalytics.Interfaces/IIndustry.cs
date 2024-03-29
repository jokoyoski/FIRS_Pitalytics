﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces 
{
    public interface IIndustry
    {
        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        int IndustryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the industry.
        /// </summary>
        /// <value>
        /// The name of the industry.
        /// </value>
        string IndustryName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

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
        Nullable<System.DateTime> DateCreated { get; set; }

    }
}
