using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Domain.Models
{
    public class IndustryListView : IIndustryListView
    {
        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        public int IndustryId { get; set; }
        /// <summary>
        /// Gets or sets the selected color identifier.
        /// </summary>
        /// <value>
        /// The selected color identifier.
        /// </value>
        public int SelectedIndustryId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the industry collection.
        /// </summary>
        /// <value>
        /// The industry collection.
        /// </value>
        public IList<IIndustry> IndustryCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string IndustryName { get; set; }



    }
}
