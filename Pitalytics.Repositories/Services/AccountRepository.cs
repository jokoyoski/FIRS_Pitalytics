using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Repositories.Factories;
using Pitalytics.Repositories.Models;
using Pitalytics.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Pitalytics.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IAccountRepository" />
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        public AccountRepository()
            : this(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public AccountRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public IUserRegistration GetRegistrationByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.getRegistrationByEmail(dbContext, email);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegistrationByEmail", e);
            }
        }



        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetRegistrationByEmail</exception>
        public IAgentOfDeduction GetAgentOfDeductionId(int userId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.GetAgentOfDeductionId(dbContext, userId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository AgentOfDeduction", e);
            }
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public IUserRegistration GetUserByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.getRegistrationByEmail(dbContext, email);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegistrationByEmail", e);
            }
        }




        /// <summary>
        /// Gets the user registrations by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository UserRegistrations</exception>
        public IList<IUserRegistration> GetUserRegistrationsById(int userId)
        {

            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetSystemAdminUsers(dbContext, userId).ToList();

                    var user = new UserRegistrationModel()
                    {
                        UserRegistrationId = userId
                    };
                    var userValue = list.FirstOrDefault(x => x.UserRegistrationId == userId);
                    list.Remove(userValue);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository UserRegistrations", e);
            }
        }

            /// <summary>
            /// Gets the tax authority by identifier.
            /// </summary>
            /// <param name="userId">The user identifier.</param>
            /// <returns></returns>
            /// <exception cref="ApplicationException">Repository TaxAuthority</exception>
        public ITaxAuthority GetTaxAuthorityById(int userId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.GetTaxAuthorityById(dbContext, userId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository TaxAuthority", e);
            }
        }




        /// <summary>
        /// Gets the registered users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository TaxAuthority</exception>
        public IList<IUserRegistration> GetRegisteredUsers(int userId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.GetRegisteredUsers(dbContext, userId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegisteredUsers", e);
            }
        }






        /// <summary>
        /// Gets the un registered users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegisteredUsers</exception>
        public IList<IUserRegistration> GetUnRegisteredUsers(int userId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.GetUnRegisteredUsers(dbContext, userId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegisteredUsers", e);
            }
        }


        /// <summary>
        /// Gets the admin by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAdminByuserId</exception>
        public IUserRegistration GetAdminByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var aRecord = AccountQueries.GetAdminByUserId(dbContext, userId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAdminByuserId", e);
            }
        }


        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleIdCollection</exception>
        public IList<IUserRolesModel> GetUserRoleActions(string username)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRoleActionCollection(dbContext, username).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRoleIdCollection", e);
            }
        }
        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetUserRoleIdCollection</exception>
        public IRoleStatus GetAdminRoleUserRoles(string role)
        {
          
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetAdminUserRoleByRole(dbContext, role);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAdminUserRoleByRole", e);
            }
        }







        /// <summary>
        /// Gets the name of the agent of deduction by.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAdminUserRoleByRole</exception>
        public IAgentOfDeduction GetAgentOfDeductionByCacNumber(string cacNumber)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetAgentOfDeductionByCacNumber(dbContext, cacNumber);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetCompanyName", e);
            }
        }
        /// <summary>
        /// Gets the user role actions by identifier.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleActionsById</exception>
        public IList<int> GetUserRoleActionsById(string email)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRoleActionCollectionId(dbContext, email).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRoleActionsById", e);
            }
        }
        /// <summary>
        /// Gets the user role collections.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleIdCollection</exception>
        public IList<IUserRolesModel> GetUserRoleCollections()
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRolesCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRolesCollection", e);
            }
        }


        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRegistration</exception>
        public IList<IUserRegistration> GetUserRegistration()
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.GetUserRegistration(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRegistration", e);
            }
        }




        /// <summary>
        /// Checks the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">CheckActivationCode</exception>
        public IUserActivationCode CheckActivationCode(string code)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var userActivationCode = AccountQueries.CheckActivationCode(dbContext, code);


                    return userActivationCode;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("CheckActivationCode", e);
            }
        }



        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userId">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">CheckActivationCode</exception>
        public IUserRegistration GetUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = AccountQueries.getUserById(dbContext, userId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("CheckActivationCode", e);
            }
        }


        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        /// string SaveRegistrationInfo(IRegistrationView registrationInfo, out int registrationId);
        public string SaveRegistrationInfo(IUserAgentofDeductionView registrationInfo, out int registrationId)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new UserRegistration
            {
                Password = registrationInfo.Password,
                FirstName = registrationInfo.FirstName,
                Email = registrationInfo.Email,
                DateVerified = DateTime.Now,
                LastName = registrationInfo.LastName,
                IsActive = registrationInfo.IsActive,
                PhoneNumber = registrationInfo.PhoneNumber,
                DateCreated = DateTime.Now,
                IsUserVerified = false
            };

            using (
                var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
            {
                dbContext.UserRegistrations.Add(newRecord);
                dbContext.SaveChanges();
            }
            registrationId = newRecord.UserRegistrationId;
            return result;
            ;
        }





        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        /// string SaveRegistrationInfo(IRegistrationView registrationInfo, out int registrationId);
        public string SaveRegistrationInfo(IUserView registrationInfo, out int registrationId)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new UserRegistration
            {
                Password = registrationInfo.Password,
                FirstName = registrationInfo.FirstName,
                Email = registrationInfo.Email,
                DateVerified = DateTime.Now,
                LastName = registrationInfo.LastName,
                IsActive = registrationInfo.IsActive,
                PhoneNumber = registrationInfo.PhoneNumber,
                DateCreated = DateTime.Now,
                IsUserVerified = false,
            };

            using (
                var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
            {
                dbContext.UserRegistrations.Add(newRecord);
                dbContext.SaveChanges();
            }
            registrationId = newRecord.UserRegistrationId;
            return result;
            ;
        }



        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        public string DeactivateUser(int registrationId)
        {
            var result = string.Empty;
            try
            {
                using (
               var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var users = dbContext.UserRegistrations.FirstOrDefault(x => x.UserRegistrationId == registrationId);
                    if (users.IsActive == true)
                    {
                        users.IsActive = false;
                    }
                    else
                    {
                        if (users.IsActive == false)
                        {
                            users.IsUserVerified = true;
                        }
                    }

                    dbContext.SaveChanges();
                }

            }

            catch (Exception e)
            {
                result = string.Format("Deactivate User - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }
        /// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        public string ActivateUser(int registrationId)
        {
            var result = string.Empty;
            try
            {
                using (
               var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var users = dbContext.UserRegistrations.FirstOrDefault(x => x.UserRegistrationId == registrationId);
                   
                    {
                        if (users.IsActive == false)
                        {
                            users.IsActive = true;
                        }
                    }

                    dbContext.SaveChanges();
                }

            }

            catch (Exception e)
            {
                result = string.Format("Deactivate User - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }



        /// <summary>
        /// Saves the system admin user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="SystemAdminUserTable">The system admin user table.</param>
        /// <returns></returns>
        public string SaveSystemAdminUser(int SystemAdminId, int userId)
        {


            var result = string.Empty;
            var newRecord = new AdminUserTable
            {
                AdminId = SystemAdminId,
                UserId = userId
            };

            using (
                var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
            {
                dbContext.AdminUserTables.Add(newRecord);
                dbContext.SaveChanges();
            }

            return result;
            ;
        }

        /// <summary>
        /// Saves the user roles information.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesView</exception>
        public string SaveUserRolesInfo(IUserRolesView userRolesView)
        {
            if (userRolesView == null)
            {
                throw new ArgumentNullException(nameof(userRolesView));
            }

            var result = string.Empty;
            var newRecord = new UserRole
            {
                RoleId = userRolesView.UserRolesId,

                DateCreated = DateTime.Now,
                Email = userRolesView.Email,

            };

            using (
                var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
            {
                dbContext.UserRoles.Add(newRecord);
                dbContext.SaveChanges();
            }

            return result;
            ;
        }

        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string SavePassword(IPasswordView registrationInfo)
        {
            var result = string.Empty;
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var userinfo =
                        dbContext.UserRegistrations.SingleOrDefault(
                            x => x.UserRegistrationId == registrationInfo.userId);
                    var useractive =
                        dbContext.UserActivationCodes.SingleOrDefault(x => x.ActivationCode == registrationInfo.code);
                    useractive.IsUsed = true;
                    dbContext.SaveChanges();
                    userinfo.Password = registrationInfo.Password;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePassword - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
            ;
        }




        /// <summary>
        /// Checks the current roles.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <returns></returns>
        public bool CheckCurrentRoles(string email, int userRolesId)
        {



            using (
                var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
            {
                var userinfo =
                    dbContext.UserRoles.SingleOrDefault(
                        x => x.RoleId == userRolesId && x.Email == email);

                if (userinfo == null)
                {
                    return false;
                }
                return true;
            }


        }


        /// <summary>
        /// Updates the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public string UpdateActivationCode(string code)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var userinfo = dbContext.UserActivationCodes.SingleOrDefault(x => x.ActivationCode == code);

                    if (userinfo != null)
                    {
                        var userData =
                            dbContext.UserRegistrations.SingleOrDefault(x =>
                                x.UserRegistrationId == userinfo.UserRegistrationId);

                        userData.IsUserVerified = true;
                        userData.DateVerified = DateTime.Now;
                       
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateActivationCode- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
            ;
        }


        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string CreateUserRole(string email, int role)
        {


            var result = string.Empty;
            var newRecord = new UserRole
            {
                Email = email,
                RoleId = role,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.UserRoles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Create User Role - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
            ;
        }
        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesId</exception>
        /// <exception cref="ArgumentOutOfRangeException">Email</exception>
        /// <exception cref="ApplicationException">Repository SaveUserActivationCode</exception>
        public string DeleteUserRoles(string email, int userRolesId)
        {

            var result = string.Empty;
            if (userRolesId < 0)
            {
                throw new ArgumentNullException(nameof(userRolesId));
            }

            if (email == null)
            {
                throw new ArgumentOutOfRangeException(nameof(email));
            }
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var userRoles = dbContext.UserRoles.FirstOrDefault(x => x.Email == email && x.RoleId == userRolesId);

                    dbContext.UserRoles.Remove(userRoles);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("DeleteUserRoles", e);
            }

            return result;
        }
        /// <summary>
        /// Saves the user activation code.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public string SaveUserActivationCode(int userId, string activationCode)
        {
            if (activationCode == null)
            {
                throw new ArgumentNullException(nameof(activationCode));
            }

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            var result = string.Empty;

            var userActivationCode = new UserActivationCode
            {
                ActivationCode = activationCode,
                DateCreated = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(24),
                IsUsed = false,
                UserRegistrationId = userId,
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.UserActivationCodes.Add(userActivationCode);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository SaveUserActivationCode", e);
            }

            return result;
        }


        /// <summary>
        /// Logs the user action.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theAction">The action.</param>
        /// <param name="isGranted">if set to <c>true</c> [is granted].</param>
        public void LogUserAction(string userId, string theAction, bool isGranted)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }
            if (string.IsNullOrEmpty(theAction))
            {
                throw new ArgumentNullException("theAction");
            }
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var actionLog = new ActionLog
                    {
                        Action = theAction,
                        Granted = isGranted,
                        LogDate = DateTime.Now,
                        UserEmail = userId,
                        DateStamp = DateTime.Now
                    };

                    dbContext.ActionLogs.Add(actionLog);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"LogUserAction - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}");
            }
        }

        /// <summary>
        /// Logs the user activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        public void LogUserActivity(string userId, string theActivity, string orderIdentifier)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }
            if (string.IsNullOrEmpty(theActivity))
            {
                throw new ArgumentNullException(nameof(theActivity));
            }
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var activity = new AppActivityLog
                    {
                        Activity = theActivity,
                        OrderIdentifer = orderIdentifier ?? "",
                        LogDate = DateTime.Now,
                        UserEmail = userId
                    };

                    dbContext.AppActivityLogs.Add(activity);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"LogUserActivity - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}");
            }
        }

        /// <summary>
        /// Saves the agentof deduction information.
        /// </summary>
        /// <param name="agentOfDeductionView">The agent of deduction view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">agentOfDeductionView</exception>
        public string saveAgentofDeductionInfo(IUserAgentofDeductionView agentOfDeductionView, int registrationId)
        {

            if (agentOfDeductionView == null)
            {
                throw new ArgumentNullException(nameof(agentOfDeductionView));
            }

            var result = string.Empty;
            var newRecord = new AgentOfDeductionInfo
            {
                BVN = agentOfDeductionView.BVN,
                CACRegNo = agentOfDeductionView.CACRegNo,
                CompanyName = agentOfDeductionView.CompanyName,
                DateCreated = DateTime.Now,

                FIRS_TIN = agentOfDeductionView.FIRS_TIN,
                IndustryId = agentOfDeductionView.IndustryId,
                IsActive = true,
                IsVerified = false,
                UserRegistrationId = registrationId,
                WebsiteAddress = agentOfDeductionView.WebsiteAddress,


            };

            try
            {
                using (
              var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.AgentOfDeductionInfoes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Save Agent of Deduction - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}");
            }



            return result;
            ;
        }




        /// <summary>
        /// Saves the agentof deduction information.
        /// </summary>
        /// <param name="agentOfDeductionView">The agent of deduction view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">agentOfDeductionView</exception>
        public string saveTaxAuthorityInfo(ITaxAuthorityView taxAuthorityView, int registrationId)
        {

            if (taxAuthorityView == null)
            {
                throw new ArgumentNullException(nameof(taxAuthorityView));
            }

            var result = string.Empty;
            var newRecord = new TaxAuthority
            {
              
                DateCreated = DateTime.Now,

              
                UserRegistrationId = registrationId,
                Description=taxAuthorityView.Description,
                InlandRevenueId=taxAuthorityView.InlandRevenueId,
                JurisdictionId=taxAuthorityView.JurisdictionId,
                IsActive=true


            };

            try
            {
                using (
              var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.TaxAuthorities.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Save Tax Authority - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}");
            }



            return result;
            ;
        }

        public string SaveRegistrationInfo(ITaxAuthorityView registrationInfo, out int registrationId)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new UserRegistration
            {
                Password = registrationInfo.Password,
                FirstName = registrationInfo.FirstName,
                Email = registrationInfo.Email,
                DateVerified = DateTime.Now,
                LastName = registrationInfo.LastName,
                IsActive = registrationInfo.IsActive,
                PhoneNumber = registrationInfo.PhoneNumber,
                DateCreated = DateTime.Now,
                IsUserVerified = false
            };

            using (
                var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
            {
                dbContext.UserRegistrations.Add(newRecord);
                dbContext.SaveChanges();
            }
            registrationId = newRecord.UserRegistrationId;
            return result;
            ;
        }


        /// <summary>
        /// Gets the tax authority.
        /// </summary>
        /// <param name="revenueId">The revenue identifier.</param>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleActionsById</exception>
        public IList<ITaxAuthority> GetTaxAuthority(int revenueId, int jurisdictionId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetTaxAuthorityInfo(dbContext, revenueId,jurisdictionId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRoleActionsById", e);
            }
        }
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public string ChangePassword(IChangePasswordView changePassword, string email)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)dbContextFactory.GetDbContext())
                {
                    var userInfo = this.GetUserByEmail(email);
                    if (userInfo != null)
                    {
                        userInfo.Password = changePassword.NewPassword;
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Change Password - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
            ;

        }
    }
}

