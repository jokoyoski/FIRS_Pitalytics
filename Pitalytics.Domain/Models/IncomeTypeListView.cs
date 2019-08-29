using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pitalytics.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pitalytics.Domain.Models
{
    public class IncomeTypeListView : IIncomeTypeListView
    {

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int SelectedIncomeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        public string SelectedIncomeTypeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the WHT rate.
        /// </summary>
        /// <value>
        /// The WHT rate.
        /// </value>
        public string SelectedWHT_Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool SelectedIsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> SelectedDateCreated { get; set; }

        /// <summary>
        /// Gets or sets the income type collection.
        /// </summary>
        /// <value>
        /// The income type collection.
        /// </value>
        public IList<IIncomeType> IncomeTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
       
        [StringLength(40, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        public string IncomeTypeName { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int IncomeTypeId { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        public int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction list.
        /// </summary>
        /// <value>
        /// The jurisdiction list.
        /// </value>
        public IList<SelectListItem> JurisdictionList { get; set; }
        /// <summary>
        /// Gets or sets the income type list.
        /// </summary>
        /// <value>
        /// The income type list.
        /// </value>
        public IList<SelectListItem> IncomeTypeList { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction income types.
        /// </summary>
        /// <value>
        /// The jurisdiction income types.
        /// </value>
        public IList<IJurisdictionIncomeType> jurisdictionIncomeTypes { get; set; }

    }
}
