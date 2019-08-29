using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Interfaces
{
    public interface IIncomeTypeListView
    {

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int SelectedIncomeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string SelectedDescription { get; set; }


        /// <summary>
        /// Gets or sets the income type collection.
        /// </summary>
        /// <value>
        /// The income type collection.
        /// </value>
        IList<IIncomeType> IncomeTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        string IncomeTypeName { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int IncomeTypeId { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction list.
        /// </summary>
        /// <value>
        /// The jurisdiction list.
        /// </value>
        IList<SelectListItem> JurisdictionList { get; set; }
        /// <summary>
        /// Gets or sets the income type list.
        /// </summary>
        /// <value>
        /// The income type list.
        /// </value>
        IList<SelectListItem> IncomeTypeList { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction income types.
        /// </summary>
        /// <value>
        /// The jurisdiction income types.
        /// </value>
        IList<IJurisdictionIncomeType> jurisdictionIncomeTypes { get; set; }
    }
}
