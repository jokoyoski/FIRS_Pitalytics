//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pitalytics.Repositories.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxReport
    {
        public int TaxReportId { get; set; }
        public string Year { get; set; }
        public int IncomeTypeId { get; set; }
        public string BVN { get; set; }
        public decimal IncomeAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public string BeneficiaryTIN { get; set; }
    }
}
