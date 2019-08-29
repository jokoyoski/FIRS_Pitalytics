
using Aspose.Cells;
using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitalytics.Repositories.Services
{
    public class AgentOfDeductionRepository : IAgentOfDeductionRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;


        public AgentOfDeductionRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        #region Branch Setup    
      
        /// <summary>
        /// Gets the branch.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetBranch</exception>
        public IList<IBranch> GetBranch()

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.getBranch(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBranch", e);
            }
        }



        /// <summary>
        /// Gets the branch by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetBranchById</exception>
        public IBranch GetBranchById(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        AgentOfDeductionQueries.GetBranchById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBranchById", e);
            }
        }


        /// <summary>
        /// Gets the branch description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetBranchDescriptionByValue</exception>
        public IBranch GetBranchDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = AgentOfDeductionQueries.getBranchDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBranchDescriptionByValue", e);
            }

        }


        /// <summary>
        /// Edits the branch.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// branchView
        /// or
        /// branchDetails
        /// </exception>
        public string EditBranch(IBranchListView branchView)
        {
            var result = string.Empty;
            if (branchView == null) throw new ArgumentNullException(nameof(branchView));
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var branchDetails = dbContext.Branches.SingleOrDefault(x => x.BranchId == branchView.BranchId);
                    if (branchDetails == null) throw new ArgumentNullException(nameof(branchDetails));

                    branchDetails.BranchName = branchView.BranchName;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveBranch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the branch information.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">AdminSaveTiming</exception>
        public string SaveBranchInfo(IBranchListView branchView, out int branchId)
        {
            var result = string.Empty;
            if (branchView == null)
            {
                throw new ArgumentException("AdminSaveTiming");
            }

            var newRecord = new Branch
            {
                Description = branchView.BranchName,
                IsActive = true,
                BranchName = branchView.BranchName
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.Branches.Add(newRecord);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveBranch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            branchId = newRecord.BranchId;
            return result;
        }
        /// Deletes the branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">BranchId</exception>
        /// <exception cref="System.ArgumentNullException">BranchDetails</exception>
        public string ReactivateBranchInfo(int BranchId)
        {
            var result = string.Empty;
            if (BranchId < 1)
            {
                throw new ArgumentException(nameof(BranchId));
            }


            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var BranchDetails = dbContext.Branches.SingleOrDefault(x => x.BranchId == BranchId);


                    BranchDetails.IsActive = true;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteBranch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Deletes the branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">BranchId</exception>
        /// <exception cref="System.ArgumentNullException">BranchDetails</exception>
        public string DeleteBranchInfo(int BranchId)
        {
            var result = string.Empty;
            if (BranchId < 1)
            {
                throw new ArgumentException(nameof(BranchId));
            }


            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var BranchDetails = dbContext.Branches.SingleOrDefault(x => x.BranchId == BranchId);


                    BranchDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteBranch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Gets the user branch.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetBranchUser</exception>
        public IList<IBranch> GetUserBranch(int branchId)

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetBranchUserByBranchId(dbContext, branchId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBranchUser", e);
            }
        }


        /// <summary>
        /// Gets the branch by user identifier.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetBranchUser</exception>
        public IList<IBranch> GetBranchByUserId(int userId)

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetBranchUserByUserId(dbContext, userId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBranchUser", e);
            }
        }
        /// <summary>
        /// Gets the agent ofdeduction branch.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetAgentOfDeductionBranch</exception>
        public IList<IBranch> GetAgentOfdeductionBranch(int agentOfDeductionId)

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetAgentofDeductionBranch(dbContext, agentOfDeductionId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAgentOfDeductionBranch", e);
            }
        }
        /// <summary>
        /// Gets the agent ofdeduction branch byranch identifier.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAgentOfDeductionBranch</exception>
        public IAgentOfDeductionBranch GetAgentOfdeductionBranchByranchId(int branchId)

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetAgentOfDeductionByBranchId(dbContext, branchId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAgentOfDeductionBranch", e);
            }
        }

        /// <summary>
        /// Saves the branch user.
        /// </summary>
        /// <param name="branchUserView">The branch user view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">branchUserView</exception>
        public string SaveBranchUser(IBranchListView branchUserView)
        {
            var result = string.Empty;
            if (branchUserView == null) throw new ArgumentNullException(nameof(branchUserView));

            var view = new UserBranch
            {
                BranchId = branchUserView.BranchId,
                IsActive = true,
                UserRegistrationId = branchUserView.UserId
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.UserBranches.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveUserBranch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }





        /// <summary>
        /// Saves the agent of deduction branch.
        /// </summary>
        /// <param name="agentOfDeductionBranch">The agent of deduction branch.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">agentOfDeductionBranch</exception>
        public string SaveAgentOfDeductionBranch(IAgentOfDeductionBranch agentOfDeductionBranch)
        {
            var result = string.Empty;
            if (agentOfDeductionBranch == null) throw new ArgumentNullException(nameof(agentOfDeductionBranch));

            var view = new AgentOfDeductionBranch
            {
                AgentOfDeductionId = agentOfDeductionBranch.AgentOfDeductionId,
                BranchId = agentOfDeductionBranch.BranchId
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.AgentOfDeductionBranches.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Agent Of Deduction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }






        /// <summary>
        /// Saves the jurisdiction branch.
        /// </summary>
        /// <param name="branchJurisdiction">The branch jurisdiction.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">branchJurisdiction</exception>
        public string SaveJurisdictionBranch(IBranchJurisdiction branchJurisdiction)
        {
            var result = string.Empty;
            if (branchJurisdiction == null) throw new ArgumentNullException(nameof(branchJurisdiction));

            var view = new BranchJurisdiction
            {
                BranchId = branchJurisdiction.BranchId,
                JurisdictionId = branchJurisdiction.JurisdictionId
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.BranchJurisdictions.Add(view);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save JurisdictionBranch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Deletes the user branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public string DeleteUserBranch(int branchId, int userId)
        {
            var result = string.Empty;



            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var branchInfo = dbContext.UserBranches.SingleOrDefault(x => x.BranchId == branchId && x.UserRegistrationId == userId);
                    if (branchInfo != null)
                    {
                        branchInfo.IsActive = false;
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete User Branch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }




        /// Deletes the user branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public string ReactivateUserBranch(int branchId, int userId)
        {
            var result = string.Empty;



            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var branchInfo = dbContext.UserBranches.SingleOrDefault(x => x.BranchId == branchId && x.UserRegistrationId == userId);
                    if (branchInfo != null)
                    {
                        branchInfo.IsActive = true;
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Reactivate User Branch - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }




        /// <summary>
        /// Checks the user branch exist.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool CheckUserBranchExist(int branchId, int userId)
        {
            var result = string.Empty;




            using (
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
            {
                var branchInfo = dbContext.UserBranches.SingleOrDefault(x => x.BranchId == branchId && x.UserRegistrationId == userId);
                if (branchInfo != null)
                {
                    return true;
                }
                return false;
            }




        }

        #endregion


        #region Tax Returns


        #region AgentOfDeduction
        /// <sumary>
        /// Excels the upload.
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns></returns>
        public DataTable ExcelUpload(HttpPostedFileBase excelFile)
        {
            if (excelFile == null) throw new ArgumentNullException(nameof(excelFile));

            var result = string.Empty;

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(excelFile.InputStream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            int rowLength = worksheet.Cells.MaxDataRow + 1;

            if (rowLength < 1) throw new ArgumentNullException(nameof(rowLength));

            int columnLength = worksheet.Cells.MaxDataColumn;

            if (columnLength < 1) throw new ArgumentNullException(nameof(columnLength));

            // Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 1, rowLength, columnLength, true);

            if (dataTable == null) throw new ArgumentNullException(nameof(dataTable));

            return dataTable;
        }




        /// <summary>
        /// Saves the tax return information.
        /// </summary>
        /// <param name="taxReturnView">The tax return view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">taxReturnView</exception>
        public string SaveTaxReturnInfo(ITaxReturnView taxReturnView)
        {
            var result = string.Empty;
            if (taxReturnView == null) throw new ArgumentNullException(nameof(taxReturnView));

            var taxReturn = new TaxReturn()

            {
                BeneficiaryTin = taxReturnView.BeneficiaryTin,

                BeneficiaryName = taxReturnView.BeneficiaryName,
                BVN = taxReturnView.BVN,
                BeneficiaryAddress = taxReturnView.BeneficiaryAddress,
                InvoiceNo = taxReturnView.InvoiceNo,
                ContractDate = DateTime.Parse(taxReturnView.ContractDate),
                ContractAmount = taxReturnView.ContractAmount,
                ContractDescription = taxReturnView.ContractDescription,
                WHT_Rate = taxReturnView.WHT_Rate,
                WHT_Amount = taxReturnView.WHT_Amount,
                IncomeTypeId = taxReturnView.IncomeTypeId,
                UserRegistrationId = taxReturnView.UserRegistrationId,
                BranchId = taxReturnView.BranchId,
                IsActive = true,
                DateCreated = DateTime.Now,
                AgentOfDeductionId = taxReturnView.AgentOfDeductionId,
                JurisdictionId = taxReturnView.JurisdictionId
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var taxReturnInfo = dbContext.TaxReturns.FirstOrDefault(x => x.BeneficiaryTin == taxReturn.BeneficiaryTin && x.BeneficiaryAddress == taxReturn.BeneficiaryAddress
                      && x.BeneficiaryName == x.BeneficiaryName && x.BranchId == taxReturn.BranchId && x.BVN == taxReturn.BVN &&
                      x.ContractDate == taxReturn.ContractDate && x.ContractAmount == taxReturn.ContractAmount &&
                      x.IncomeTypeId == taxReturn.IncomeTypeId && x.WHT_Amount == taxReturn.WHT_Amount && x.WHT_Rate == taxReturn.WHT_Rate 
                    );
                    if(taxReturnInfo==null)
                    {
                        dbContext.TaxReturns.Add(taxReturn);
                        dbContext.SaveChanges();
                    }
                   
                }
            }


            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format(
                        "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name,
                        eve.Entry.State);

                    lstErrors.Add(msg);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        lstErrors.Add(msg);
                    }
                }

                if (lstErrors != null && lstErrors.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in lstErrors)
                    {
                        sb.Append(item + "; ");
                    }

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
                                        sb.ToString());
                }
            }

            catch (NotSupportedException e)
            {
            }
            return result;

        }




        /// Checks the user branch exist.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IList<ITaxReturn> GetTaxReturn(int agentId)
        {



            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetTaxReturn(dbContext, agentId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReturn", e);
            }


        }


        #endregion

        #region TaxAuthority        
        /// <summary>
        /// Gets the tax return by jurisdiction identifier.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTaxReturns</exception>
        public IList<ITaxReturn> GetTaxReturnByJurisdictionId(int jurisdictionId)
        {



            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetTaxReturnByJurisidctionId(dbContext, jurisdictionId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReturns", e);
            }


        }


        /// <summary>
        /// Gets the branch by jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTaxReturns</exception>
        public IList<IBranch> GetBranchByJurisdiction(int jurisdictionId)
        {



            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetBranchByJurisdictionId(dbContext, jurisdictionId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReturns", e);
            }


        }
        #endregion




        #region SystemAdmin


        /// <summary>
        /// Gets the tax return list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTaxReturns</exception>
        public IList<ITaxReturn> GetTaxReturnList()
        {



            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetTaxReturnList(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReturns", e);
            }


        }

        #endregion



        #endregion



        #region Tax Report

        /// <summary>
        /// Saves the tax report information.
        /// </summary>
        /// <param name="taxReportView">The tax report view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">taxReportView</exception>
        /// <exception cref="Exception">Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
        ///                                         sb.ToString()</exception>
        public string SaveTaxReportInfo(ITaxReportView taxReportView)
        {
            var result = string.Empty;
            if (taxReportView == null) throw new ArgumentNullException(nameof(taxReportView));

            var taxReport = new TaxReport()

            {
               BeneficiaryTIN=taxReportView.BeneficiaryTIN,
             BVN=taxReportView.BVN,
             IncomeAmount=taxReportView.IncomeAmount,
             TaxAmount=taxReportView.TaxAmount,
             IncomeTypeId=taxReportView.IncomeTypeId,
             Year=taxReportView.Year
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var taxReportInfo = dbContext.TaxReports.SingleOrDefault(x => x.BVN == taxReport.BVN && x.BeneficiaryTIN == taxReport.BeneficiaryTIN && x.IncomeAmount == taxReport.IncomeAmount
                      && x.TaxAmount == taxReport.TaxAmount && x.Year == taxReport.Year);
                    if(taxReportInfo==null)
                    {
                        dbContext.TaxReports.Add(taxReport);
                        dbContext.SaveChanges();
                    }
                  
                }
            }


            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format(
                        "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name,
                        eve.Entry.State);

                    lstErrors.Add(msg);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        lstErrors.Add(msg);
                    }
                }

                if (lstErrors != null && lstErrors.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in lstErrors)
                    {
                        sb.Append(item + "; ");
                    }

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
                                        sb.ToString());
                }
            }

            catch (NotSupportedException e)
            {
            }
            return result;

        }

        #endregion

    

       

        #region TaxReport  
        /// <summary>
        /// Gets the tax report.
        /// </summary>
        /// <param name="BVN">The BVN.</param>
        /// <param name="YearCreated">The date created.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTaxReport</exception>
        public IList<ITaxReport> GetTaxReport(string BVN, string YearCreated)
        {



            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AgentOfDeductionQueries.GetTaxReport(dbContext, BVN, YearCreated).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReport", e);
            }


        }


      
        #endregion

    }
}
