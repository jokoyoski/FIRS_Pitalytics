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
    
    public partial class AgentOfDeductionInfo
    {
        public int AgentOfDeductionId { get; set; }
        public string CompanyName { get; set; }
        public string FIRS_TIN { get; set; }
        public string BVN { get; set; }
        public string CACRegNo { get; set; }
        public int IndustryId { get; set; }
        public string WebsiteAddress { get; set; }
        public bool IsVerified { get; set; }
        public int UserRegistrationId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}
