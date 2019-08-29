using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Interfaces
{
    public interface ITaxReturnListView
    {


        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int SelectedBranchId { get; set; }

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
        IList<ITaxReturn> TaxReturnCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the incometype.
        /// </summary>
        /// <value>
        /// The incometype.
        /// </value>
        IList<SelectListItem> Incometype { get; set; }

        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        /// <value>
        /// The branch.
        /// </value>
        IList<SelectListItem>  Branch { get; set; }

        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        int BranchId { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the agent of deduction identifier.
        /// </summary>
        /// <value>
        /// The agent of deduction identifier.
        /// </value>
        int AgentOfDeductionId { get; set; }

        /// <summary>
        /// Gets or sets the tax return.
        /// </summary>
        /// <value>
        /// The tax return.
        /// </value>
        IList<ITaxReturn> TaxReturn { get; set; }
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
        /// Gets or sets the agent of deduction list.
        /// </summary>
        /// <value>
        /// The agent of deduction list.
        /// </value>
        IList<SelectListItem> AgentOfDeductionList { get; set; }
        /// <summary
        /// 
        int SelectedJursidctionId { get; set; }

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int IncomeTypeId { get; set; }
    }
}
