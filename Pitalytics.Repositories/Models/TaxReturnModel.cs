﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class TaxReturnModel : ITaxReturn
    {
        /// <summary>
        /// Gets or sets the tax return identifier.
        /// </summary>
        /// <value>
        /// The tax return identifier.
        /// </value>
        public int TaxReturnId { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary tin.
        /// </summary>
        /// <value>
        /// The beneficiary tin.
        /// </value>
        public string BeneficiaryTin { get; set; }

        /// <summary>
        /// Gets or sets the name of the beneficiary.
        /// </summary>
        /// <value>
        /// The name of the beneficiary.
        /// </value>
        public string BeneficiaryName { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        public string BVN { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary address.
        /// </summary>
        /// <value>
        /// The beneficiary address.
        /// </value>
        public string BeneficiaryAddress { get; set; }

        /// <summary>
        /// Gets or sets the invoice no.
        /// </summary>
        /// <value>
        /// The invoice no.
        /// </value>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the contract date.
        /// </summary>
        /// <value>
        /// The contract date.
        /// </value>
        public System.DateTime ContractDate { get; set; }

        /// <summary>
        /// Gets or sets the contract description.
        /// </summary>
        /// <value>
        /// The contract description.
        /// </value>
        public string ContractDescription { get; set; }

        /// <summary>
        /// Gets or sets the contract amount.
        /// </summary>
        /// <value>
        /// The contract amount.
        /// </value>
        public string ContractAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the contract.
        /// </summary>
        /// <value>
        /// The type of the contract.
        /// </value>
        public string ContractType { get; set; }

        /// <summary>
        /// Gets or sets the WHT rate.
        /// </summary>
        /// <value>
        /// The WHT rate.
        /// </value>
        public string WHT_Rate { get; set; }

        /// <summary>
        /// Gets or sets the WHT amount.
        /// </summary>
        /// <value>
        /// The WHT amount.
        /// </value>
        public string WHT_Amount { get; set; }

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int IncomeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user registration.
        /// </summary>
        /// <value>
        /// The name of the user registration.
        /// </value>
        public int UserRegistrationName { get; set; }

        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        public int BranchId { get; set; }


        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
      public  string BranchName { get; set; }
        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        public string IncomeTypeName { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        public int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        public int AgentOfDeductionId { get; set; }
    }
}
