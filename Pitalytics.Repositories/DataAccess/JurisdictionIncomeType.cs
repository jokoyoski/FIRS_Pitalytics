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
    
    public partial class JurisdictionIncomeType
    {
        public int JurisdictionIncomeTypeId { get; set; }
        public int JurisdictionId { get; set; }
        public int IncomeTypeId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}
