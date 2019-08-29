using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface ITaxReturn
    {
        /// <summary>
        /// Gets or sets the tax return identifier.
        /// </summary>
        /// <value>
        /// The tax return identifier.
        /// </value>
        int TaxReturnId { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary tin.
        /// </summary>
        /// <value>
        /// The beneficiary tin.
        /// </value>
        string BeneficiaryTin { get; set; }

        /// <summary>
        /// Gets or sets the name of the beneficiary.
        /// </summary>
        /// <value>
        /// The name of the beneficiary.
        /// </value>
        string BeneficiaryName { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        string BVN { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary address.
        /// </summary>
        /// <value>
        /// The beneficiary address.
        /// </value>
        string BeneficiaryAddress { get; set; }

        /// <summary>
        /// Gets or sets the invoice no.
        /// </summary>
        /// <value>
        /// The invoice no.
        /// </value>
        string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the contract date.
        /// </summary>
        /// <value>
        /// The contract date.
        /// </value>
        System.DateTime ContractDate { get; set; }

        /// <summary>
        /// Gets or sets the contract description.
        /// </summary>
        /// <value>
        /// The contract description.
        /// </value>
        string ContractDescription { get; set; }

        /// <summary>
        /// Gets or sets the contract amount.
        /// </summary>
        /// <value>
        /// The contract amount.
        /// </value>
        string ContractAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the contract.
        /// </summary>
        /// <value>
        /// The type of the contract.
        /// </value>
        string ContractType { get; set; }

        /// <summary>
        /// Gets or sets the WHT rate.
        /// </summary>
        /// <value>
        /// The WHT rate.
        /// </value>
        string WHT_Rate { get; set; }

        /// <summary>
        /// Gets or sets the WHT amount.
        /// </summary>
        /// <value>
        /// The WHT amount.
        /// </value>
        string WHT_Amount { get; set; }

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int IncomeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        int UserRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user registration.
        /// </summary>
        /// <value>
        /// The name of the user registration.
        /// </value>
        int UserRegistrationName { get; set; }

        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        int BranchId { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        string BranchName { get; set; }
        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        string IncomeTypeName { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int AgentOfDeductionId { get; set; }

    }
}
