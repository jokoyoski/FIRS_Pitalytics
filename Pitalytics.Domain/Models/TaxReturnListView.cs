using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pitalytics.Interfaces;

namespace Pitalytics.Domain.Models
{
    public class TaxReturnListView : ITaxReturnListView
    {

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int SelectedBranchId { get; set; }

        /// <summary>
        /// Gets or sets the selected jursidction identifier.
        /// </summary>
        /// <value>
        /// The selected jursidction identifier.
        /// </value>
        public int SelectedJursidctionId { get; set; }

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
        public IList<ITaxReturn> TaxReturnCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction list.
        /// </summary>
        /// <value>
        /// The jurisdiction list.
        /// </value>
        public IList<SelectListItem> JurisdictionList { get; set; }
        /// <summary>
        /// Gets or sets the agent of deduction list.
        /// </summary>
        /// <value>
        /// The agent of deduction list.
        /// </value>
        public IList<SelectListItem> AgentOfDeductionList { get; set; }
        /// <summary>
        /// Gets or sets the incometype.
        /// </summary>
        /// <value>
        /// The incometype.
        /// </value>
        public  IList<SelectListItem> Incometype { get; set; }

        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        /// <value>
        /// The branch.
        /// </value>
     public   IList<SelectListItem> Branch { get; set; }
        /// <summary>
        /// Gets or sets the branchid.
        /// </summary>
        /// <value>
        /// The branchid.
        /// </value>
        public int BranchId { get; set; }

      
      
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the agent of deduction identifier.
        /// </summary>
        /// <value>
        /// The agent of deduction identifier.
        /// </value>
        public int AgentOfDeductionId { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        public int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the tax return.
        /// </summary>
        /// <value>
        /// The tax return.
        /// </value>
        public IList<ITaxReturn> TaxReturn { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int IncomeTypeId { get; set; }

    }
}
