using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Repositories.Queries;
using Pitalytics.Repositories.Models;

namespace Pitalytics.Repositories.Services
{
    public class GeneralRepository : IGeneralRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        public GeneralRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        #region IncomeType        
        /// <summary>
        /// Gets the type of the income.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIncomeType</exception>
        public IList<IIncomeType> GetIncomeType()

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetIncomeType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIncomeType", e);
            }
        }

        /// <summary>
        /// Gets the income type by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetIncomeTypeById</exception>
        public IIncomeType GetIncomeTypeById(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetIncomeTypeById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIncomeTypeById", e);
            }
        }





        /// <summary>
        /// Gets the income type by branch identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetIncomeTypeById</exception>
        public IEnumerable<IIncomeType> GetIncomeTypeByBranchId(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetIncomeTypeByBranchId(dbContext, Id).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIncomeTypeByBrranchId", e);
            }
        }

        /// <summary>
        /// Edits the type of the income.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// incomeTypeView
        /// or
        /// incometypeDetails
        /// </exception>
        public string EditIncomeType(IIncomeTypeListView incomeTypeView)
        {
            var result = string.Empty;
            if (incomeTypeView == null) throw new ArgumentNullException(nameof(incomeTypeView));
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var incometypeDetails = dbContext.IncomeTypes.SingleOrDefault(x => x.IncomeTypeId == incomeTypeView.IncomeTypeId);
                    if (incometypeDetails == null) throw new ArgumentNullException(nameof(incometypeDetails));

                    incometypeDetails.IncomeTypeName = incomeTypeView.IncomeTypeName;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveIncomeType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the income type description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIncomeTypeDescriptionByValue</exception>
        public IIncomeType GetIncomeTypeDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getIncomeTypeDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIncomeTypeDescriptionByValue", e);
            }

        }





        /// <summary>
        /// Gets the income type jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIncomeTypeJurisdiction</exception>
        public IJurisdictionIncomeType GetIncomeTypeJurisdiction(int jurisdictionId, int incomeTypeId)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getIncomeTypeJurisdiction(dbContext, jurisdictionId, incomeTypeId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIncomeTypeJurisdiction", e);
            }

        }



        /// <summary>
        /// Gets the income type by jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIncomeTypeByJurisdiction</exception>
        public IEnumerable<IJurisdictionIncomeType> GetIncomeTypeByJurisdiction(int jurisdictionId)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.GetIncomeTypeByJurisdiction(dbContext, jurisdictionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIncomeTypeByJurisdiction", e);
            }

        }


        /// <summary>
        /// Saves the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveIncomeType</exception>
        public string SaveIncomeTypeInfo(IIncomeTypeListView incomeTypeView)
        {
            var result = string.Empty;
            if (incomeTypeView == null)
            {
                throw new ArgumentException("AdminSaveIncomeType");
            }

            var newRecord = new IncomeType
            {
                IncomeTypeName = incomeTypeView.IncomeTypeName,
                WHT_Rate = "10",
                IsActive = true,

            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.IncomeTypes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveIncomeType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// Saves the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveIncomeType</exception>
        public string SaveIncomeTypeJurisdictionInfo(IIncomeTypeListView incomeTypeListView)
        {
            var result = string.Empty;
            if (incomeTypeListView == null)
            {
                throw new ArgumentException("incomeTypeListView");
            }

            var newRecord = new JurisdictionIncomeType
            {
                IncomeTypeId = incomeTypeListView.IncomeTypeId,
                JurisdictionId = incomeTypeListView.JurisdictionId,
                IsActive=true,
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.JurisdictionIncomeTypes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveIncomeTypeJursidction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the income type information.
        /// </summary>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">incomeTypeId</exception>
        /// <exception cref="ArgumentNullException">IncomeTypeDetails</exception>
        public string DeleteIncomeTypeInfo(int incomeTypeId)
        {
            var result = string.Empty;

            if (incomeTypeId < 1)
            {
                throw new ArgumentException(nameof(incomeTypeId));
            }

            try
            {
                using (
                   var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var IncomeTypeDetails = dbContext.IncomeTypes.SingleOrDefault(x => x.IncomeTypeId == incomeTypeId);

                    if (IncomeTypeDetails == null) throw new ArgumentNullException(nameof(IncomeTypeDetails));
                    IncomeTypeDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }

            catch (Exception e)
            {
                result = string.Format("DeleteIncomeType - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }




        /// <summary>
        /// Deletes the income type by jurisdiction.
        /// </summary>
        /// <param name="jursdictionId">The jursdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// incomeTypeId
        /// or
        /// jursdictionId
        /// </exception>
        public string DeleteIncomeTypeByJurisdiction(int jursdictionId, int incomeTypeId)
        {
            var result = string.Empty;

            if (incomeTypeId < 1)
            {
                throw new ArgumentException(nameof(incomeTypeId));
            }
            if (jursdictionId < 1)
            {
                throw new ArgumentException(nameof(jursdictionId));
            }
            try
            {
                using (
                   var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var IncomeTypeDetails = dbContext.JurisdictionIncomeTypes.SingleOrDefault(x => x.IncomeTypeId == incomeTypeId && x.JurisdictionId == jursdictionId);

                    if (IncomeTypeDetails != null)
                    {
                        IncomeTypeDetails.IsActive = false;
                    }

                    dbContext.SaveChanges();
                }
            }

            catch (Exception e)
            {
                result = string.Format("DeleteIncomeTypeJuridiction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateIncomeType(int Id) 
        {
            var result = string.Empty;

            try
            {
                // calling our database 
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var incomeType = dbContext.IncomeTypes.SingleOrDefault(x => x.IncomeTypeId == Id);
                    if (incomeType != null)
                    {
                        incomeType.IsActive = true;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }





        #endregion





        #region Industry 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateIndustry(int Id)
        {
            var result = string.Empty;

            try
            {
                // calling our database 
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var industry = dbContext.Industries.SingleOrDefault(x => x.IndustryId == Id);
                    if (industry != null)
                    {
                        industry.IsActive = true;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }
        /// <summary>
        /// Gets the industry.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIndustry</exception>
        public IList<IIndustry> GetIndustry()
        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetIndustry(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIndustry", e);
            }
        }
        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIndustryById</exception>
        public IIndustry GetIndustryById(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetIndustryById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIndustryById", e);
            }
        }
        /// <summary>
        /// Gets the industry description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIndustryDescriptionByValue</exception>
        public IIndustry GetIndustryDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getIndustryDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIndustryDescriptionByValue", e);
            }

        }
        /// <summary>
        /// Edits the industry.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// industryView
        /// or
        /// industryDetails
        /// </exception>
        public string EditIndustry(IIndustryListView industryView)
        {
            var result = string.Empty;
            if (industryView == null) throw new ArgumentNullException(nameof(industryView));
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var industryDetails = dbContext.Industries.SingleOrDefault(x => x.IndustryId == industryView.IndustryId);
                    if (industryDetails == null) throw new ArgumentNullException(nameof(industryDetails));

                    industryDetails.IndustryName = industryView.IndustryName;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveIndustry - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Saves the industry information.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveIndustry</exception>
        public string SaveIndustryInfo(IIndustryListView industryView)
        {
            var result = string.Empty;
            if (industryView == null)
            {
                throw new ArgumentException("AdminSaveIndustry");
            }

            var newRecord = new Industry
            {
                IndustryName = industryView.IndustryName,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.Industries.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveIndustry - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Deletes the industry information.
        /// </summary>
        /// <param name="IndustryId">The industry identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">IndustryId</exception>
        /// <exception cref="ArgumentNullException">IndustryDetails</exception>
        public string DeleteIndustryInfo(int IndustryId)
        {
            var result = string.Empty;
            if (IndustryId < 1)
            {
                throw new ArgumentException(nameof(IndustryId));
            }


            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var IndustryDetails = dbContext.Industries.SingleOrDefault(x => x.IndustryId == IndustryId);
                    if (IndustryDetails == null) throw new ArgumentNullException(nameof(IndustryDetails));
                    IndustryDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteIndustry - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        #endregion


        #region  Jurisdiction 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateJurisidcition(int Id)
        {
            var result = string.Empty;

            try
            {
                // calling our database 
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var jurisdiction = dbContext.Jurisdictions.SingleOrDefault(x => x.JurisdictionId == Id);
                    if (jurisdiction != null)
                    {
                        jurisdiction.IsActive = true;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }
        /// <summary>
        /// Gets the jurisdiction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetJurisdiction</exception>
        public IList<IJurisdiction> GetJurisdiction()

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetJurisdictions(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetJurisdiction", e);
            }
        }

        /// <summary>
        /// Gets the jurisdiction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetJurisdictionById</exception>
        public IJurisdiction GetJurisdictionById(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = LookupQueries.GetJurisdictionById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetJurisdictionById", e);
            }
        }




        /// <summary>
        /// Gets the jurisdiction by branch identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetJurisdictionById</exception>
        public IBranchJurisdiction GetJurisdictionByBranchId(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = LookupQueries.GetJurisdictionByBranchId(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetJurisdictionById", e);
            }
        }
        /// <summary>
        /// Gets the jurisdiction description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetJurisdictionDescriptionByValue</exception>
        public IJurisdiction GetJurisdictionDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.GetJurisdictionDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetJurisdictionDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Edits the jurisdiction.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// jurisdictionView
        /// or
        /// colorDetails
        /// </exception>
        public string EditJurisdiction(IJurisdictionListView jurisdictionView)
        {
            var result = string.Empty;
            if (jurisdictionView == null) throw new ArgumentNullException(nameof(jurisdictionView));
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var juridictionDetails = dbContext.Jurisdictions.SingleOrDefault(x => x.JurisdictionId == jurisdictionView.JurisdictionId);
                    if (juridictionDetails == null) throw new ArgumentNullException(nameof(juridictionDetails));

                    juridictionDetails.JurisdictionName = jurisdictionView.JurisdictionName;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("EditJurisdiction  - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the jurisdiction information.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveJurisdiction</exception>
        public string SaveJurisdictionInfo(IJurisdictionListView jurisdictionView)
        {
            var result = string.Empty;
            if (jurisdictionView == null)
            {
                throw new ArgumentException("AdminSaveJurisdiction");
            }

            var newRecord = new Jurisdiction
            {
                IsActive = true,
                JurisdictionName = jurisdictionView.JurisdictionName,

            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.Jurisdictions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveJurisdiction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Deletes the jurisdiction information.
        /// </summary>
        /// <param name="JurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">JurisdictionId</exception>
        /// <exception cref="ArgumentNullException">JurisdictionIdDetails</exception>
        public string DeleteJurisdictionInfo(int JurisdictionId)
        {
            var result = string.Empty;
            if (JurisdictionId < 1)
            {
                throw new ArgumentException(nameof(JurisdictionId));
            }


            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var JurisdictionIdDetails = dbContext.Jurisdictions.SingleOrDefault(x => x.JurisdictionId == JurisdictionId);
                    if (JurisdictionIdDetails == null) throw new ArgumentNullException(nameof(JurisdictionIdDetails));
                    JurisdictionIdDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteJurisdiction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion



        #region  AgentOf Deduction


        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public string DeactivateAgentOfDeduction(int agentOfDeductionId)
        {
            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var agentOfDeductionDetails = dbContext.AgentOfDeductionInfoes.SingleOrDefault(x => x.AgentOfDeductionId == agentOfDeductionId);
                    if (agentOfDeductionDetails != null)
                    {

                        var userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == agentOfDeductionDetails.UserRegistrationId);
                        userDetails.IsActive = false;

                        var branches = dbContext.AdminUserTables.Where(x => x.AdminId == agentOfDeductionDetails.UserRegistrationId).ToList();
                       
                        foreach (var j in branches)
                        {
                            userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == j.UserId);
                            userDetails.IsActive = false;
                        }
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Deactivate Agent Of Deduction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }






        /// <summary>
        /// Activates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public string ActivateAgentOfDeduction(int agentOfDeductionId)
        {
            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var agentOfDeductionDetails = dbContext.AgentOfDeductionInfoes.SingleOrDefault(x => x.AgentOfDeductionId == agentOfDeductionId);
                    if (agentOfDeductionDetails != null)
                    {

                        var userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == agentOfDeductionDetails.UserRegistrationId);
                        userDetails.IsActive = true;

                        var branches = dbContext.AdminUserTables.Where(x => x.AdminId == agentOfDeductionDetails.UserRegistrationId).ToList();
                        foreach (var j in branches)
                        {
                            userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == j.UserId);
                            userDetails.IsActive = true;
                        }
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Deactivate Agent Of Deduction - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Gets the agent of deduction.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAgentOfDeduction</exception>
        public IList<IAgentOfDeduction> GetAgentOFDeduction()
        {

            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetAgentOfDeduction(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAgentOfDeduction", e);
            }
        }


        #endregion



        #region TaxAuthority   

        /// <summary>
        /// Gets the tax authority.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTaxAuthority</exception>
        public IList<ITaxAuthority> GetTaxAuthority()
        {

            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetTaxAuthority(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxAuthority", e);
            }
        }



        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public string DeActivateTaxAuthority(int taxAuthorityId)
        {
            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var taxAuthorityDetails = dbContext.TaxAuthorities.SingleOrDefault(x => x.TaxAuthorityId == taxAuthorityId);
                    if (taxAuthorityDetails != null)
                    {

                        var userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == taxAuthorityDetails.UserRegistrationId);
                        userDetails.IsActive = false;

                        var users = dbContext.AdminUserTables.Where(x => x.AdminId == taxAuthorityDetails.UserRegistrationId);

                        foreach (var j in users)
                        {
                            userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == j.UserId);
                            userDetails.IsActive = false;
                        }
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Deactivate Tax Authority - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }






        /// <summary>
        /// Activates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public string ActivateTaxAuthority(int taxAuthorityId)
        {
            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var taxAuthorityDetails = dbContext.TaxAuthorities.SingleOrDefault(x => x.TaxAuthorityId == taxAuthorityId);
                    if (taxAuthorityDetails != null)
                    {

                        var userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == taxAuthorityDetails.UserRegistrationId);
                        userDetails.IsActive = true;

                        var users = dbContext.AdminUserTables.Where(x => x.AdminId == taxAuthorityDetails.UserRegistrationId);
                        foreach (var j in users)
                        {
                            userDetails = dbContext.UserRegistrations.SingleOrDefault(x => x.UserRegistrationId == j.UserId);
                            userDetails.IsActive = true;
                        }
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Deactivate  Tax Authority - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        #endregion



        #region Inland Revenue Setup   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateInlandRevenue(int Id)
        {
            var result = string.Empty;

            try
            {
                // calling our database 
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var inlandRevenue = dbContext.InlandRevenues.SingleOrDefault(x => x.InlandRevenueId == Id);
                    if (inlandRevenue != null)
                    {
                        inlandRevenue.IsActive = true;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                result = string.Format("view - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Gets the inland revenue.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetInlandRevenue</exception>
        public IList<IInlandRevenue> GetInlandRevenue()

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.getInlandRevenue(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetInlandRevenue", e);
            }
        }


        public IInlandRevenue GetInlandRevenueById(int Id)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord =
                        LookupQueries.GetInlandRevenueById(dbContext, Id);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetInlandRevenueById", e);
            }
        }

        public IInlandRevenue GetInlandRevenueNameByValue(string inlandRevenueName)
        {
            try
            {
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext();
                {

                    var aRecord = LookupQueries.getInlandRevenueNameByValue(dbContext, inlandRevenueName);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetInlandRevenueNameByValue", e);
            }

        }

        public string EditInlandRevenue(IInlandRevenueListView inlandRevenueView)
        {
            var result = string.Empty;
            if (inlandRevenueView == null) throw new ArgumentNullException(nameof(inlandRevenueView));
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var inlandRevenueDetails = dbContext.InlandRevenues.SingleOrDefault(x => x.InlandRevenueId == inlandRevenueView.InlandRevenueId);
                    if (inlandRevenueDetails == null) throw new ArgumentNullException(nameof(inlandRevenueDetails));

                    inlandRevenueDetails.InlandRevenueName = inlandRevenueView.InlandRevenueName;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveColor - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Saves the inland revenue information.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">AdminSaveInlandRevenue</exception>
        public string SaveInlandRevenueInfo(IInlandRevenueListView inlandRevenueView)
        {
            var result = string.Empty;
            if (inlandRevenueView == null)
            {
                throw new ArgumentException("AdminSaveInlandRevenue");
            }

            var newRecord = new InlandRevenue
            {DateCreated=DateTime.Now,
                IsActive = true,
                InlandRevenueName = inlandRevenueView.InlandRevenueName,
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.InlandRevenues.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveInlandRevenue - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the inland revenue information.
        /// </summary>
        /// <param name="InlandRevenueId">The inland revenue identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">InlandRevenueId</exception>
        /// <exception cref="ArgumentNullException">InlandRevenueDetails</exception>
        public string DeleteInlandRevenueInfo(int InlandRevenueId)
        {
            var result = string.Empty;
            if (InlandRevenueId < 1)
            {
                throw new ArgumentException(nameof(InlandRevenueId));
            }


            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var InlandRevenueDetails = dbContext.InlandRevenues.SingleOrDefault(x => x.InlandRevenueId == InlandRevenueId);
                    if (InlandRevenueDetails == null) throw new ArgumentNullException(nameof(InlandRevenueDetails));
                    InlandRevenueDetails.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteTiming - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion

        #region FileType      
        /// <summary>
        /// Gets the type of the file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetFileType</exception>
        public IList<IFileType> GetFileType()
        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetFileType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetFileType", e);
            }
        }


        #endregion



    }
}