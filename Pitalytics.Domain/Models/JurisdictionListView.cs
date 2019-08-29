using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Domain.Models
{
    public class JurisdictionListView : IJurisdictionListView
    {

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int SelectedJurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string SelectedDescription { get; set; }


        /// <summary>
        /// Gets or sets the income type collection.
        /// </summary>
        /// <value>
        /// The income type collection.
        /// </value>
        public IList<IJurisdiction> JurisdictionCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        public string JurisdictionName { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        public int JurisdictionId { get; set; }


    }
}
