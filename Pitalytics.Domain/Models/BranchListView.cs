using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Models
{
    public class BranchListView : IBranchListView
    {
        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        /// 
        /// 
      
        public int BranchId { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        /// 
       
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength =5)]
        public  string BranchName { get; set; }


        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
      public  int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
         public  string JurisdictionName { get; set; }
        /// <summary>
        /// Gets or sets the agent of deduction identifier.
        /// </summary>
        /// <value>
        /// The agent of deduction identifier.
        /// </value>
       public int AgentOfDeductionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the agent of deduction.
        /// </summary>
        /// <value>
        /// The name of the agent of deduction.
        /// </value>
         public   string AgentOfDeductionName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
     public   string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
      public  bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
      public  Nullable<System.DateTime> DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
      public  int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
          public  string UserName { get; set; }
        /// <summary>
        /// Gets or sets the branch collection.
        /// </summary>
        /// <value>
        /// The branch collection.
        /// </value>
      public  IList<IBranch> BranchCollection { get; set; }

        /// Gets or sets the branch names.
        /// </summary>
        /// <value>
        /// The branch names.
        /// </value>
      public  IList<SelectListItem> BranchNames { get; set; }

        /// <summary>
        /// Gets or sets the user names.
        /// </summary>
        /// <value>
        /// The user names.
        /// </value>
     public   IList<SelectListItem> UserNames { get; set; }
        /// <summary>
        /// Gets or sets the user names.
        /// </summary>
        /// <value>
        /// The user names.
        /// </value>
   public IList<SelectListItem> JurisdictionNames { get; set; }

        /// <summary>
        /// Gets or sets the income type names.
        /// </summary>
        /// <value>
        /// The income type names.
        /// </value>
        public IList<SelectListItem> IncomeTypeNames { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the file type identifier.
        /// </summary>
        /// <value>
        /// The file type identifier.
        /// </value>
        public int?  FileTypeId { get; set; }
    }
}
