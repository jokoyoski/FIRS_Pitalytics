using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IIndustryListView
    {
        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        int IndustryId { get; set; }
        /// <summary>
        /// Gets or sets the selected color identifier.
        /// </summary>
        /// <value>
        /// The selected color identifier.
        /// </value>
        int SelectedIndustryId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the industry collection.
        /// </summary>
        /// <value>
        /// The industry collection.
        /// </value>
        IList<IIndustry> IndustryCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string IndustryName { get; set; }
    }
}
