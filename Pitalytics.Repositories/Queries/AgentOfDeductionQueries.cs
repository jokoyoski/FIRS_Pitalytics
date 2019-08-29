using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Repositories.Queries
{
    public class AgentOfDeductionQueries
    {
        #region Branch Setup        
        /// <summary>
        /// Gets the branch.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBranch> getBranch(PitalyticsEntities db)
        {
            var result = (from d in db.Branches
                          select new Models.BranchModel
                          {
                              BranchId = d.BranchId,
                              BranchName = d.BranchName,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Description = d.Description
                          }).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the branch by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IBranch GetBranchById(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.Branches
                          where d.BranchId.Equals(Id)
                          select new BranchModel
                          {
                              BranchId = d.BranchId,
                              Description = d.Description
                          }
                ).SingleOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the agent of deduction by branch identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IAgentOfDeductionBranch GetAgentOfDeductionByBranchId(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.AgentOfDeductionBranches
                          where d.BranchId.Equals(Id)
                          select new AgentOfDeductionBranchModel
                          {
                              BranchId = d.BranchId,
                            AgentOfDeductionId=d.AgentOfDeductionId
                          }
                ).SingleOrDefault();
            return result;
        }

        /// </summary>


        /// <summar



        /// <summary>
        /// Gets the branch description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IBranch getBranchDescriptionByValue(PitalyticsEntities db, string description)
        {
            var result = (from d in db.Branches
                          where d.Description.Equals(description)
                          select new BranchModel
                          {
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }

        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBranch> GetBranchUserByBranchId(PitalyticsEntities db, int branchId)
        {
            var result = (from d in db.UserBranches
                         
                          
                          join s in db.Branches on d.BranchId equals s.BranchId

                          join u in db.UserRegistrations on d.UserRegistrationId equals u.UserRegistrationId
                          join w in db.BranchJurisdictions on d.BranchId equals w.BranchId
                          join ux in db.Jurisdictions on w.JurisdictionId equals ux.JurisdictionId
                          where d.BranchId == branchId && s.IsActive==true
                          select new Models.BranchModel
                          {
                              BranchName = s.BranchName,
                              BranchId=s.BranchId,
                              Email = u.Email,
                              UserName=u.FirstName,
                              JurisdictionName=ux.JurisdictionName,
                              IsActive=d.IsActive,
                              UserId=u.UserRegistrationId,
                          }).OrderBy(x => x.BranchId);
            return result;
        }


        /// <summary>
        /// Gets the branch user by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBranch> GetBranchUserByUserId(PitalyticsEntities db, int userId)
        {
            var result = (from d in db.UserBranches

                          where d.UserRegistrationId==userId
                          join s in db.Branches on d.BranchId equals s.BranchId
                          where s.IsActive==true
                          select new Models.BranchModel
                          {
                              BranchName = s.BranchName,
                              BranchId = s.BranchId,
                              IsActive=d.IsActive
                          }).OrderBy(x => x.BranchId);
            return result;
        }


        





        /// <summary>
        /// Gets the branch user by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBranch> GetBranchByJurisdictionId(PitalyticsEntities db, int jurisidictionId)
        {
            var result = (from d in db.BranchJurisdictions

                          where d.JurisdictionId ==jurisidictionId
                          join s in db.Branches on d.BranchId equals s.BranchId
                          where s.IsActive==true

                          select new Models.BranchModel
                          {
                              BranchName = s.BranchName,
                              BranchId = s.BranchId,

                          }).OrderBy(x => x.BranchId);
            return result;
        }





        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserBranch> GetBranchUser(PitalyticsEntities db)
        {
            var result = (from d in db.UserBranches
                          join s in db.Branches on d.BranchId equals s.BranchId
                          join u in db.UserRegistrations on d.UserRegistrationId equals u.UserRegistrationId
                          select new Models.UserBranchModel
                          {
                              BranchName = s.BranchName,
                              UserName = u.Email
                          }).OrderBy(x => x.UserBranchId);
            return result;
        }


        /// <summary>
        /// Gets the branch user.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IBranch> GetAgentofDeductionBranch(PitalyticsEntities db, int agentOfDeductionId)
        {
            var result = (from d in db.AgentOfDeductionBranches

                          join  b in db.Branches on d.BranchId equals b.BranchId
                          join s in db.BranchJurisdictions on d.BranchId equals s.BranchId
                          join w in db.Jurisdictions on s.JurisdictionId equals w.JurisdictionId
                          where d.AgentOfDeductionId==agentOfDeductionId 
                          
                          select new Models.BranchModel
                          {
                              BranchId = d.BranchId,
                              AgentOfDeductionId = agentOfDeductionId,
                              JurisdictionName=w.JurisdictionName,
                              BranchName = b.BranchName,
                              IsActive=b.IsActive

                          }).OrderBy(x => x.BranchId);
            return result;
        }






        #endregion



        #region TaxReturns        
        /// <summary>
        /// Gets the tax returns.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="BranchId">The branch identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <param name="StartDate">The start date.</param>
        /// <param name="EndDate">The end date.</param>
        /// <returns></returns>
        internal static IEnumerable<ITaxReturn> GetTaxReturn(PitalyticsEntities db, int agentOfDeductionId)
        {
            var result = (from d in db.TaxReturns


                        where d.AgentOfDeductionId== agentOfDeductionId
                          join f in db.Branches on d.BranchId equals f.BranchId
                         join s in db.UserRegistrations on d.UserRegistrationId equals s.UserRegistrationId
                         join m in db.IncomeTypes on d.IncomeTypeId equals m.IncomeTypeId
                          select new Models.TaxReturnModel
                          {
                              TaxReturnId=d.TaxReturnId,
                              BeneficiaryTin=d.BeneficiaryTin,
                              BeneficiaryAddress=d.BeneficiaryAddress,
                              BeneficiaryName=d.BeneficiaryName,
                              BranchName=f.BranchName,
                              BVN=d.BVN,
                              ContractAmount=d.ContractAmount,
                              ContractDate=d.ContractDate,
                               IncomeTypeName=m.IncomeTypeName,
                               Email=s.Email,
                               WHT_Amount=d.WHT_Amount,
                               WHT_Rate=d.WHT_Rate,
                               InvoiceNo=d.InvoiceNo,
                              AgentOfDeductionId = d.AgentOfDeductionId,
                               BranchId=d.BranchId,
                               IncomeTypeId=d.IncomeTypeId,
                               JurisdictionId=d.JurisdictionId
                              
                          }).OrderBy(x => x.TaxReturnId);
            return result;
        }





        /// <summary>
        /// Gets the tax return by jurisidction identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITaxReturn> GetTaxReturnByJurisidctionId(PitalyticsEntities db, int jurisdictionId)
        {
            var result = (from d in db.TaxReturns


                          where d.JurisdictionId == jurisdictionId
                          join f in db.Branches on d.BranchId equals f.BranchId
                          join s in db.UserRegistrations on d.UserRegistrationId equals s.UserRegistrationId
                          join m in db.IncomeTypes on d.IncomeTypeId equals m.IncomeTypeId
                          select new Models.TaxReturnModel
                          {
                              TaxReturnId = d.TaxReturnId,
                              BeneficiaryTin = d.BeneficiaryTin,
                              BeneficiaryAddress = d.BeneficiaryAddress,
                              BeneficiaryName = d.BeneficiaryName,
                              BranchName = f.BranchName,
                              BVN = d.BVN,
                              ContractAmount = d.ContractAmount,
                              ContractDate = d.ContractDate,
                              IncomeTypeName = m.IncomeTypeName,
                              Email = s.Email,
                              WHT_Amount = d.WHT_Amount,
                              WHT_Rate = d.WHT_Rate,
                              InvoiceNo = d.InvoiceNo,
                              AgentOfDeductionId = d.AgentOfDeductionId,
                              BranchId = d.BranchId,
                              IncomeTypeId = d.IncomeTypeId,
                              JurisdictionId = d.JurisdictionId

                          }).OrderBy(x => x.TaxReturnId);
            return result;
        }




        /// Gets the tax return by jurisidction identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITaxReturn> GetTaxReturnList(PitalyticsEntities db)
        {
            var result = (from d in db.TaxReturns


                          join f in db.Branches on d.BranchId equals f.BranchId
                          join s in db.UserRegistrations on d.UserRegistrationId equals s.UserRegistrationId
                          join m in db.IncomeTypes on d.IncomeTypeId equals m.IncomeTypeId
                          select new Models.TaxReturnModel
                          {
                              TaxReturnId = d.TaxReturnId,
                              BeneficiaryTin = d.BeneficiaryTin,
                              BeneficiaryAddress = d.BeneficiaryAddress,
                              BeneficiaryName = d.BeneficiaryName,
                              BranchName = f.BranchName,
                              BVN = d.BVN,
                              ContractAmount = d.ContractAmount,
                              ContractDate = d.ContractDate,
                              IncomeTypeName = m.IncomeTypeName,
                              Email = s.Email,
                              WHT_Amount = d.WHT_Amount,
                              WHT_Rate = d.WHT_Rate,
                              InvoiceNo = d.InvoiceNo,
                              AgentOfDeductionId = d.AgentOfDeductionId,
                              BranchId = d.BranchId,
                              IncomeTypeId = d.IncomeTypeId,
                              JurisdictionId = d.JurisdictionId

                          }).OrderBy(x => x.TaxReturnId);
            return result;
        }



        #endregion

        #region TaxReport and IncomeReport        
        /// <summary>
        /// Gets the tax report.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="BVN">The BVN.</param>
        /// <param name="DateCreated">The date created.</param>
        /// <returns></returns>
        internal static IEnumerable<ITaxReport> GetTaxReport(PitalyticsEntities db, string BVN, string YearCreated)
        {
            var result = (from d in db.TaxReports

                          where d.Year==YearCreated && d.BVN==BVN
                         
                          join f in db.IncomeTypes on d.IncomeTypeId equals f.IncomeTypeId
                        
                          select new Models.TaxReportModel
                          {
                            
                              IncomeTypeName=f.IncomeTypeName,
                              TaxReportId=d.TaxReportId,
                           BeneficiaryTIN=d.BeneficiaryTIN,
                           IncomeAmount=d.IncomeAmount,
                           TaxAmount=d.TaxAmount,
                           BVN=d.BVN,
                           Year = d.Year
                          }).OrderBy(x => x.TaxReportId);
            return result;
        }

       
        #endregion

    }
}