using System.Linq;
using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Repositories.Models;
using System.Collections.Generic;

namespace Pitalytics.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class AccountQueries
    {
        /// <summary>
        /// Gets the registration by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        internal static IUserRegistration getRegistrationByEmail(PitalyticsEntities db, string email)
        {
            var result = (from d in db.UserRegistrations
                          where d.Email.Equals(email)
                          select new UserRegistrationModel
                          {
                              IsActive=d.IsActive,
                              Email = d.Email,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              PhoneNumber = d.PhoneNumber,
                              UserRegistrationId = d.UserRegistrationId,
                              Password = d.Password,
                              IsUserVerified = d.IsUserVerified
                          }).FirstOrDefault();

            var a = result;
            return result;
        }
        /// <summary>
        /// Gets the system admin users.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRegistration> GetSystemAdminUsers(PitalyticsEntities db, int userId)
        {
            var result = (from d in db.AdminUserTables


                          where d.AdminId == userId

                          join f in db.UserRegistrations on d.UserId equals f.UserRegistrationId
                         

                          select new Models.UserRegistrationModel
                          {
                              IsActive=f.IsActive,
                              UserRegistrationId = f.UserRegistrationId,
                              DateCreated = f.DateCreated,
                              Email = f.Email,
                             
                              FirstName = f.FirstName,
                              IsUserVerified = f.IsUserVerified,
                              LastName = f.LastName,
                              PhoneNumber = f.PhoneNumber,
                             

                          }).OrderBy(x => x.UserRegistrationId);
            return result;
        }
        /// <summary>
        /// Gets the users system admin identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static  IUserRegistration GetAdminByUserId(PitalyticsEntities db, int userId)
        {
            var result = (from d in db.AdminUserTables


                          where d.UserId == userId

                          join f in db.UserRegistrations on d.AdminId equals f.UserRegistrationId


                          select new Models.UserRegistrationModel
                          {
                              IsActive = f.IsActive,
                              UserRegistrationId = f.UserRegistrationId,
                              DateCreated = f.DateCreated,
                              Email = f.Email,

                              FirstName = f.FirstName,
                              IsUserVerified = f.IsUserVerified,
                              LastName = f.LastName,
                              PhoneNumber = f.PhoneNumber,


                          }).SingleOrDefault();
            return result;
        }



        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRegistration> GetUserRegistration(PitalyticsEntities db)
        {
            var result = (from d in db.UserRegistrations

                          select new UserRegistrationModel
                          {
                              Email = d.Email,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              PhoneNumber = d.PhoneNumber,
                              UserRegistrationId = d.UserRegistrationId,



                          }).OrderBy(x => x.UserRegistrationId);

            var a = result;
            return result;
        }



        /// <summary>
        /// Gets the agent of deduction identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IAgentOfDeduction GetAgentOfDeductionId(PitalyticsEntities db, int userId)
        {
            var result = (from d in db.AgentOfDeductionInfoes
                          where d.UserRegistrationId == userId
                          select new AgentOfDeductionModel
                          {

                              AgentOfDeductionId = d.AgentOfDeductionId



                          }).FirstOrDefault();

            var a = result;
            return result;
        }







        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IUserRegistration getUserById(PitalyticsEntities db, int Id)
        {
            var result = (from d in db.UserRegistrations
                          where d.UserRegistrationId.Equals(Id)
                          select new UserRegistrationModel
                          {
                              Email = d.Email,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              PhoneNumber = d.PhoneNumber,
                              UserRegistrationId = d.UserRegistrationId,

                              Password = d.Password,

                              IsUserVerified = d.IsUserVerified
                          }).FirstOrDefault();

            var a = result;
            return result;
        }

        /// <summary>
        /// Checks the activation code.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        internal static IUserActivationCode CheckActivationCode(PitalyticsEntities db, string code)
        {
            var result = (from d in db.UserActivationCodes
                          where d.ActivationCode.Equals(code)
                          where d.IsUsed == false
                          where d.ExpirationDate > System.DateTime.Now
                          select new UserActivationCodeModel
                          {
                              UserRegistrationId = d.UserRegistrationId,
                              ActivationCode = d.ActivationCode,
                              ExpirationDate = d.ExpirationDate,
                              IsUsed = d.IsUsed
                          }).FirstOrDefault();


            return result;
        }

        /// <summary>
        /// Gets the user role action collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRolesModel> GetUserRoleActionCollection(PitalyticsEntities db, string email)
        {


            var result = (from d in db.UserRoles
                          where d.Email == email

                          join s in db.Roles on d.RoleId equals s.RoleId

                          select new UserRolesModel
                          {
                              UserRolesId = s.RoleId,
                              UserRolesDescription = s.RoleName
                          }


                );
            return result;
        }


        /// <param name="db">The database.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        internal static IRoleStatus GetAdminUserRoleByRole(PitalyticsEntities db, string role)
        {


            var result = (from d in db.RoleStatus

                          where d.AdminRole == role
                    join g in db.Roles on d.UserRole equals g.RoleName
                   join m in db.Roles on d.AdminRole equals m.RoleName

                         

                          select new RoleStatusModel
                          {
                              UserRole = d.UserRole,
                             UserRoleId = g.RoleId,
                              AdminRole=d.AdminRole,
                           AdminRoleId=m.RoleId
                              
                          }


                ).SingleOrDefault();
            return result;
        }







        /// <summary>
        /// Gets the name of the agent of deduction by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyName">Name of the company.</param>
        /// <returns></returns>
        internal static IAgentOfDeduction GetAgentOfDeductionByCacNumber(PitalyticsEntities db, string cacNumber)
        {


            var result = (from d in db.AgentOfDeductionInfoes

                          where d.CACRegNo == cacNumber


                          select new AgentOfDeductionModel
                          {
                             CompanyName=d.CompanyName
                          }


                ).SingleOrDefault();
            return result;
        }





        /// <summary>
        /// Gets the tax authority by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static ITaxAuthority GetTaxAuthorityById(PitalyticsEntities db, int userId)
        {


            var result = (from d in db.TaxAuthorities

                          where d.UserRegistrationId==userId


                          select new TaxAuthorityModel
                          {
                             JurisdictionId=d.JurisdictionId
                          }
                          
                ).SingleOrDefault();
            return result;
        }





        /// Gets the users system admin identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRegistration> GetUnRegisteredUsers(PitalyticsEntities db, int userId)
        {
            var result = (from d in db.AdminUserTables


                          where d.AdminId == userId

                          join f in db.UserRegistrations on d.UserId equals f.UserRegistrationId
                          where f.IsActive==false 

                          select new Models.UserRegistrationModel
                          {
                              IsActive = f.IsActive,
                              UserRegistrationId = f.UserRegistrationId,
                              DateCreated = f.DateCreated,
                              Email = f.Email,

                              FirstName = f.FirstName,
                              IsUserVerified = f.IsUserVerified,
                              LastName = f.LastName,
                              PhoneNumber = f.PhoneNumber,


                          }).OrderBy(x=>x.UserRegistrationId);
            return result;
        }


        /// <summary>
        /// Gets the registered users.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRegistration> GetRegisteredUsers(PitalyticsEntities db, int userId)
        {
            var result = (from d in db.AdminUserTables


                          where d.AdminId == userId

                          join f in db.UserRegistrations on d.UserId equals f.UserRegistrationId
                          where f.IsActive == true 

                          select new Models.UserRegistrationModel
                          {
                              IsActive = f.IsActive,
                              UserRegistrationId = f.UserRegistrationId,
                              DateCreated = f.DateCreated,
                              Email = f.Email,

                              FirstName = f.FirstName,
                              IsUserVerified = f.IsUserVerified,
                              LastName = f.LastName,
                              PhoneNumber = f.PhoneNumber,


                          }).OrderBy(x=>x.UserRegistrationId);
            return result;
        }





        /// <summary>
        /// Gets the user roles collection.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserRolesModel> GetUserRolesCollection(PitalyticsEntities db)
        {


            var result = (from d in db.Roles




                          select new UserRolesModel
                          {
                              UserRolesDescription = d.RoleName,
                              UserRolesId = d.RoleId
                          }

                ).OrderBy(x => x.UserRolesId);
            return result;
        }

        /// <summary>
        /// Gets the user role action collection identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<int> GetUserRoleActionCollectionId(PitalyticsEntities db, string email)
        {
            var result = (from d in db.UserRoles
                              // join s in db.AppRoles on d.AppRoleId equals s.AppRoleId
                          where d.Email == email
                          select d.RoleId);
            return result;
        }
    }
}