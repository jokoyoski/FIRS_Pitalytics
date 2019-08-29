using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Repositories.Models;
using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;

namespace Pitalytics.Repositories.Queries
{
    internal static class LookupQueries
    {
        #region IncomeType

        /// <summary>
        /// Gets the type of the income.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IIncomeType> GetIncomeType(PitalyticsEntities db)
        {
            var result = (from d in db.IncomeTypes
                        
                          select new Models.IncomeTypeModel
                          {
                              IncomeTypeId = d.IncomeTypeId,
                              IncomeTypeName = d.IncomeTypeName,
                              Description = d.Description,
                              WHT_Rate = d.WHT_Rate,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }).OrderBy(x => x.Description);
            return result;
        }


        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IIncomeType> GetIncomeTypeByBranchId(PitalyticsEntities db, int branchId)
        {
            var result = (from d in db.BranchJurisdictions
                          where d.BranchId == branchId
                          join s in db.JurisdictionIncomeTypes on d.JurisdictionId equals s.JurisdictionId
                          join w in db.IncomeTypes on s.IncomeTypeId equals w.IncomeTypeId
                          select new IncomeTypeModel
                          {
                              IncomeTypeId = w.IncomeTypeId,
                              IncomeTypeName = w.IncomeTypeName
                          }
                ).OrderBy(x => x.IncomeTypeId);
            return result;
        }

        /// <summary>
        /// Gets the type of the income.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IJurisdictionIncomeType> GetIncomeTypeByJurisdiction(PitalyticsEntities db, int jurisditionId)
        {
            var result = (from d in db.JurisdictionIncomeTypes
                          where d.JurisdictionId == jurisditionId
                          join f in db.IncomeTypes on d.IncomeTypeId equals f.IncomeTypeId
                          where f.IsActive==true
                          join r in db.Jurisdictions on d.JurisdictionId equals r.JurisdictionId
                         
                          select new Models.JurisdictionIncomeTypeModel
                          {
                              IncomeTypeName = f.IncomeTypeName,
                              JurisdictionName = r.JurisdictionName,
                              IncomeTypeId = d.IncomeTypeId,
                              JurisdictionId = d.JurisdictionId,
                              IsActive=d.IsActive
                          }).OrderBy(x => x.IncomeTypeId);
            return result;
        }

        /// <summary>
        /// Gets the income type by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IIncomeType GetIncomeTypeById(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.IncomeTypes
                          where d.IncomeTypeId.Equals(Id)
                          select new IncomeTypeModel
                          {
                              IncomeTypeId = d.IncomeTypeId,
                              IncomeTypeName = d.IncomeTypeName,
                              Description = d.Description,
                              WHT_Rate = d.WHT_Rate,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }
                         ).SingleOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the income type description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IIncomeType getIncomeTypeDescriptionByValue(PitalyticsEntities db, string description)
        {
            var result = (from d in db.IncomeTypes
                          where d.IncomeTypeName.Equals(description)
                          select new IncomeTypeModel
                          {
                              IncomeTypeId = d.IncomeTypeId,
                              IncomeTypeName = d.IncomeTypeName,
                              Description = d.Description,
                              WHT_Rate = d.WHT_Rate,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }
                         ).FirstOrDefault();
            return result;
        }



        /// <summary>
        /// Gets the income type jurisdiction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="jurisidctionId">The jurisidction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        internal static IJurisdictionIncomeType getIncomeTypeJurisdiction(PitalyticsEntities db, int jurisidctionId, int incomeTypeId)
        {
            var result = (from d in db.JurisdictionIncomeTypes
                          where d.JurisdictionId.Equals(jurisidctionId) && d.IncomeTypeId == incomeTypeId
                          select new JurisdictionIncomeTypeModel
                          {
                              IncomeTypeId = d.IncomeTypeId
                          }
                         ).FirstOrDefault();
            return result;
        }

        #endregion







        #region Jusridsiction
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IJurisdiction> GetJurisdictions(PitalyticsEntities db)
        {
            var result = (from d in db.Jurisdictions
                         
                          select new JurisdictionModel
                          {
                              JurisdictionId = d.JurisdictionId,
                              JurisdictionName = d.JurisdictionName,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              Description = d.Description
                          }).OrderBy(x => x.Description);
            return result;
        }
        /// <summary>
        /// Gets the jurisdiction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IJurisdiction GetJurisdictionById(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.Jurisdictions
                          where d.JurisdictionId.Equals(Id)
                          select new JurisdictionModel
                          {
                              JurisdictionId = d.JurisdictionId,
                              JurisdictionName = d.JurisdictionName,
                              Description = d.Description,
                              IsActive=d.IsActive
                              
                          }
                       ).SingleOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the jurisdiction by branch identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IBranchJurisdiction GetJurisdictionByBranchId(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.BranchJurisdictions
                          where d.BranchId==Id
                        
                          select new BranchJurisdictionModel
                          {
                             JurisdictionId=d.JurisdictionId

                          }
                       ).SingleOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the jurisdiction description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IJurisdiction GetJurisdictionDescriptionByValue(PitalyticsEntities db, string description)
        {
            var result = (from d in db.Jurisdictions
                          where d.JurisdictionName.Equals(description)
                          select new JurisdictionModel
                          {
                              JurisdictionName = d.JurisdictionName,
                              Description = d.Description
                          }).FirstOrDefault();
            return result;
        }


        #endregion


        #region Industry         
        /// <summary>
        /// Gets the industry.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IIndustry> GetIndustry(PitalyticsEntities db)
        {
            var result = (from d in db.Industries
                          select new Models.IndustryModel
                          {
                              IndustryId = d.IndustryId,
                              IndustryName = d.IndustryName,
                              Description = d.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IIndustry GetIndustryById(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.Industries
                          where d.IndustryId.Equals(Id)
                          select new IndustryModel
                          {
                              IndustryId = d.IndustryId,
                              IndustryName = d.IndustryName,
                              Description = d.Description,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }
                ).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the industry description by value.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        internal static IIndustry getIndustryDescriptionByValue(PitalyticsEntities db, string industryName)
        {
            var result = (from d in db.Industries
                          where d.IndustryName.Equals(industryName)
                          select new IndustryModel
                          {
                              IndustryName = d.IndustryName,
                              Description = d.Description
                          }).FirstOrDefault();
            return result;

        }

        #endregion




        #region Agent of Deduction
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IAgentOfDeduction> GetAgentOfDeduction(PitalyticsEntities db)
        {
            var result = (from d in db.AgentOfDeductionInfoes
                          join s in db.Industries on d.IndustryId equals s.IndustryId
                          join w in db.UserRegistrations on d.UserRegistrationId equals w.UserRegistrationId
                          select new Models.AgentOfDeductionModel
                          {
                              AgentOfDeductionId = d.AgentOfDeductionId,
                              BVN = d.BVN,
                              IndustryName = s.IndustryName,
                              CACRegNo = d.CACRegNo,
                              DateCreated = d.DateCreated,
                              CompanyName = d.CompanyName,
                              FIRS_TIN = d.FIRS_TIN,
                              IndustryId = d.IndustryId,
                              IsActive = w.IsActive,
                              IsVerified = d.IsVerified,
                              UserRegistrationId = d.UserRegistrationId,
                              WebsiteAddress = d.WebsiteAddress
                          }).OrderBy(x => x.AgentOfDeductionId);
            return result;
        }








        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>


        #endregion

        #region TaxAuthority       

        internal static IEnumerable<ITaxAuthority> GetTaxAuthority(PitalyticsEntities db)
        {
            var result = (from d in db.TaxAuthorities
                          join s in db.InlandRevenues on d.InlandRevenueId equals s.InlandRevenueId
                          join  q in db.Jurisdictions on d.JurisdictionId equals q.JurisdictionId
                          join w in db.UserRegistrations on d.UserRegistrationId equals w.UserRegistrationId
                          select new Models.TaxAuthorityModel
                          {
                              JurisdictionName=q.JurisdictionName,
                              InlandRevenueName=s.InlandRevenueName,
                              UserRegistrationId=w.UserRegistrationId,
                              TaxAuthorityId=d.TaxAuthorityId,
                             IsActive=w.IsActive
                              
                          }).OrderBy(x => x.UserRegistrationId);
            return result;
        }





        #endregion

        #region Inland Revenue Setup    

        internal static IEnumerable<IInlandRevenue> getInlandRevenue(PitalyticsEntities db)
        {
            var result = (from d in db.InlandRevenues
                          select new Models.InlandRevenueModel
                          {
                              InlandRevenueId = d.InlandRevenueId,
                              InlandRevenueName = d.InlandRevenueName,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                          }).OrderBy(x => x.InlandRevenueName);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal static IInlandRevenue GetInlandRevenueById(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.InlandRevenues
                          where d.InlandRevenueId.Equals(Id)
                          select new InlandRevenueModel
                          {
                              InlandRevenueId = d.InlandRevenueId,
                              InlandRevenueName = d.InlandRevenueName,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                          }
                ).SingleOrDefault();
            return result;
        }

        
        internal static IInlandRevenue getInlandRevenueNameByValue(PitalyticsEntities db, string inlandRevenueName)
        {
            var result = (from d in db.InlandRevenues
                          where d.InlandRevenueName.Equals(inlandRevenueName)
                          select new InlandRevenueModel
                          {
                              InlandRevenueName = d.InlandRevenueName
                          }).FirstOrDefault();
            return result;
        }

        #endregion



        #region TaxAuthority        
        /// <summary>
        /// Gets the tax authority information.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="inlandRevenueId">The inland revenue identifier.</param>
        /// <param name="jurisidctionId">The jurisidction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITaxAuthority> GetTaxAuthorityInfo(PitalyticsEntities db,int inlandRevenueId,int jurisidctionId)
        {
            var result = (from d in db.TaxAuthorities
                          where d.InlandRevenueId==inlandRevenueId && d.JurisdictionId==jurisidctionId
                          select new Models.TaxAuthorityModel
                          {
                              InlandRevenueId = d.InlandRevenueId,
                              JurisdictionId=d.InlandRevenueId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                          }).OrderBy(x => x.JurisdictionId);
            return result;
        }


        #endregion

        #region FileType         
        /// <summary>
        /// Gets the type of the file.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IFileType> GetFileType(PitalyticsEntities db)
        {
            var result = (from d in db.FileTypes
                          select new Models.FileTypeModel
                          {
                              FileTypeId = d.FileTypeId,
                              FileName = d.FileTypeName,
                              Description = d.Description,
                            
                          }).OrderBy(x => x.Description);
            return result;
        }

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        internal static IDigitalFile GetDigitalFileDetail(PitalyticsEntities db, int digitalFileId)
        {
            var result = (from d in db.DigitalFiles
                          where d.DigitalFileId.Equals(digitalFileId)
                          select new DigitalFileModel
                          {
                              FileContent = d.FileContent,
                              DateCreated = d.DateCreated,
                              DigitalFileId = d.DigitalFileId,
                              DigitalTypeId = d.DigitalTypeId,

                              IsActive = d.IsActive,
                              FileExtension = d.FileExtension,
                              Filename = d.FileName,
                              ContentType = d.ContentType,
                              FileTypeId = d.FileTypeId

                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the tax return file.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IDigitalFile GetTaxReturnFile(PitalyticsEntities db)
        {
            var result = (from d in db.DigitalFiles


                          join s in db.FileTypes on d.FileTypeId equals s.FileTypeId
                          where d.IsActive==true & s.FileTypeName == "TaxReturnFile" 

                          select new Models.DigitalFileModel
                          {
                              FileContent = d.FileContent,
                              DateCreated = d.DateCreated,
                              DigitalFileId = d.DigitalFileId,
                              DigitalTypeId = d.DigitalTypeId,

                              IsActive = d.IsActive,
                              FileExtension = d.FileExtension,
                              Filename = d.FileName,
                              ContentType = d.ContentType,
                              FileTypeId = s.FileTypeId
                            
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the tax report file.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IDigitalFile GetTaxReportFile(PitalyticsEntities db) 
        {
            var result = (from d in db.DigitalFiles


                          join s in db.FileTypes on d.FileTypeId equals s.FileTypeId
                          where d.IsActive ==true & s.FileTypeName=="TaxReportFile"

                          select new Models.DigitalFileModel
                          {
                              FileContent = d.FileContent,
                              DateCreated = d.DateCreated,
                              DigitalFileId = d.DigitalFileId,
                              DigitalTypeId = d.DigitalTypeId,

                              IsActive = d.IsActive,
                              FileExtension = d.FileExtension,
                              Filename = d.FileName,
                              ContentType = d.ContentType,
                              FileTypeId = s.FileTypeId

                          }).FirstOrDefault();
            return result;
        }

        #endregion
    }
}


