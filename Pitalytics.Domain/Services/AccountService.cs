using AA.Infrastructure.Interfaces;

using Pitalytics.Interfaces;
using Pitalytics.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;

using Pitalytics.Domain.Utilities;
using Environment = AA.Infrastructure.Utility.Environment;
using Pitalytics.Domain.Resources;
//using Pitalytic.Interfaces.ValueTypes;

namespace Pitalytics.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IAccountService" />
    public class AccountService : IAccountService
    {
        private readonly IAccountViewsModelFactory accountViewsModelFactory;

        private readonly IEmailFactory emailFactory;

        private readonly IAgentOfDeductionFactory agentOfDeductionFactory;


        private readonly IFormsAuthenticationService formsAuthentication;

        private readonly IGeneralRepository generalRepository;

        private readonly ISessionStateService session;

        private readonly IAgentOfDeductionRepository agentOfDeductionRepository;
        private readonly IAccountRepository accountRepository;


        private readonly IAesEncryption encryptionService;

        private readonly IEmail emailService;

        private readonly IEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountViewsModelFactory">The account views model factory.</param>
        /// <param name="emailFactory">The email factory.</param>
        /// <param name="session">The session.</param>
        /// <param name="formsAuthentication">The forms authentication.</param>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="encryptionService">The encryption service.</param>
        /// <param name="emailService">The email service.</param>
        /// <param name="environment">The environment.</param>
        public AccountService(IAccountViewsModelFactory accountViewsModelFactory, IAgentOfDeductionRepository agentOfDeductionRepository, IGeneralRepository generalRepository, IEmailFactory emailFactory,
            ISessionStateService session, IFormsAuthenticationService formsAuthentication,
            IAccountRepository accountRepository, IAesEncryption encryptionService,
            IEmail emailService, IEnvironment environment)
        {
            this.accountViewsModelFactory = accountViewsModelFactory;

            this.accountRepository = accountRepository;
            this.generalRepository = generalRepository;
            this.emailFactory = emailFactory;
            this.session = session;
            this.formsAuthentication = formsAuthentication;
            this.agentOfDeductionRepository = agentOfDeductionRepository;
            this.encryptionService = encryptionService;
            this.emailService = emailService;
            this.environment = environment;
        }

        /// <summary>
        /// Gets the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        public ILogOnView GetLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl)
        {

            return this.accountViewsModelFactory.CreateLogOnView(infoMessage, errorMessage, userName, returnUrl);
        }

        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <returns></returns>
        public IUserAgentofDeductionView GetRegistrationView()
        {
            // about us source records from database
            var industry = this.generalRepository.GetIndustry().Where(x=>x.IsActive==true).ToList();

            // send it to accounts view factory to create the view factory
            var viewModel = this.accountViewsModelFactory.CreateRegistrationView(industry);

            // return the view to controller
            return viewModel;
        }

        /// <summary>
        /// Gets the tax authority regstration view.
        /// </summary>
        /// <returns></returns>
        public ITaxAuthorityView GetTaxAuthorityRegstrationView()
        {
            var jurisdiction = this.generalRepository.GetJurisdiction();
            jurisdiction = jurisdiction.Where(x => x.IsActive).ToList();

            var inlandRevenueName = this.generalRepository.GetInlandRevenue();
            inlandRevenueName = inlandRevenueName.Where(x => x.IsActive).ToList();

            // send it to accounts view factory to create the view factory
            var viewModel = this.accountViewsModelFactory.CreateTaxAuthorityRegistrationView(inlandRevenueName,jurisdiction);

            // return the view to controller
            return viewModel;
        }



        /// <summary>
        /// Creates the system admin register view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public IUserView CreateSystemAdminRegisterView(string infoMessage)
        {
            // about us source records from database


            // send it to accounts view factory to create the view factory
            var viewModel = this.accountViewsModelFactory.CreateSystemAdminRegisterView(infoMessage);

            // return the view to controller
            return viewModel;
        }
        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        public IUserListView GetUserRegistration(string Email, string FirstName)
        {
            var userRegistrationList = this.accountRepository.GetUserRegistration();
            // send it to accounts view factory to create the view factory
            var viewModel =
                this.accountViewsModelFactory.CreateUserRegistrationView(userRegistrationList, Email, FirstName);

            // return the view to controller
            return viewModel;
        }

        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public string DeactivateUser(int userId)
        {
            return this.accountRepository.DeactivateUser(userId);
        }



        /// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public string ActivateUser(int userId)
        {
            return this.accountRepository.ActivateUser(userId);
        }

        /// <summary>
        /// Processes the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">registrationInfo</exception>
        public IUserAgentofDeductionView ProcessAgentofDeductionRegistrationInfo(IUserAgentofDeductionView userAgentofDeductionView)
        {
            if (userAgentofDeductionView == null)
            {
                throw new System.ArgumentNullException(nameof(userAgentofDeductionView));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //checks if similar email does exist in the database 
            var registrationData = this.accountRepository.GetRegistrationByEmail(userAgentofDeductionView.Email);
            var IsRecordExist = (registrationData != null);

            if (IsRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.IsEmailExist;
            }
            else
            {
                var companyData = this.accountRepository.GetAgentOfDeductionByCacNumber(userAgentofDeductionView.CACRegNo);

                if(companyData!=null)
                {
                    isDataOkay = false;
                    processingMessage = Messages.CompanyExist;
                }
            }


            var industry = this.generalRepository.GetIndustry().Where(x => x.IsActive == true).ToList();
            var returnViewModel =
                this.accountViewsModelFactory.CreateUpdatedRegistraionView(userAgentofDeductionView, processingMessage,industry);

            
            if (!isDataOkay)
            {
                return returnViewModel;
            }

            //save data to database
            var registrationId = 0;

            userAgentofDeductionView.Password = this.encryptionService.Encrypt(userAgentofDeductionView.Password);

            userAgentofDeductionView.FirstName = userAgentofDeductionView.FirstName == null ? userAgentofDeductionView.CompanyName : userAgentofDeductionView.FirstName;
            userAgentofDeductionView.IsActive = false;
            var savedData = this.accountRepository.SaveRegistrationInfo(userAgentofDeductionView, out registrationId);


            var saveInfo = this.accountRepository.saveAgentofDeductionInfo(userAgentofDeductionView, registrationId);

            var getRole = this.accountRepository.GetAdminRoleUserRoles(EnvironmentValues.AgentOfDeduction);
            //
            this.accountRepository.CreateUserRole(userAgentofDeductionView.Email, getRole.AdminRoleId);

            if (savedData == string.Empty)
            {
                //Send activation Link to the User,
                //Genenrate Activation Code
                var activationCode = CodeGenerators.GenerateActivationCode();

                //Get The registered User Information
                var user = this.accountRepository.GetRegistrationByEmail(userAgentofDeductionView.Email);

                //Pass the Code and the user ID to store to Database
                var result = this.accountRepository.SaveUserActivationCode(user.UserRegistrationId, activationCode);


                // email send implementation here
                var emailDetail =
                    this.emailFactory.CreateRegistrationRequestEmail(userAgentofDeductionView.Email, userAgentofDeductionView.FirstName,
                        activationCode); //999 is the registrationId from database

                var emailKey = this.environment[EnvironmentValues.EmailKey];

                this.emailService.Send(emailKey, "team@aditng.com", "Pitalytics Team", emailDetail.Subject,
                   emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);



            }


            return returnViewModel;
        }


        /// <summary>
        /// Processes the tax authority registration information.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">taxAuthorityView</exception>
        public ITaxAuthorityView ProcessTaxAuthorityRegistrationInfo(ITaxAuthorityView taxAuthorityView)
        {
            if (taxAuthorityView == null)
            {
                throw new System.ArgumentNullException(nameof(taxAuthorityView));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //checks if similar email does exist in the database 
            var registrationData = this.accountRepository.GetRegistrationByEmail(taxAuthorityView.Email);
            var IsRecordExist = (registrationData != null);
           
            if (IsRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.IsEmailExist;
            }
            else
            {
                var checkTaxAuthority = this.accountRepository.GetTaxAuthority(taxAuthorityView.InlandRevenueId, taxAuthorityView.JurisdictionId);

                if (checkTaxAuthority.Count>0)
                {
                    isDataOkay = false;
                    processingMessage = Messages.TaxAuthorityExist;
                }

            }


            var jurisdictionList = this.generalRepository.GetJurisdiction();
            jurisdictionList = jurisdictionList.Where(x => x.IsActive == true).ToList();
            var inlandRevenueNameList = this.generalRepository.GetInlandRevenue();
            inlandRevenueNameList = inlandRevenueNameList.Where(x => x.IsActive == true).ToList();
           
            var returnViewModel =
                this.accountViewsModelFactory.CreateUpdatedRegistraionView(taxAuthorityView,jurisdictionList,inlandRevenueNameList, processingMessage);

            if (!isDataOkay)
            {
                return returnViewModel;
            }

            //save data to database
            var registrationId = 0;

            taxAuthorityView.Password = this.encryptionService.Encrypt(taxAuthorityView.Password);

                 taxAuthorityView.IsActive = false;
            var savedData = this.accountRepository.SaveRegistrationInfo(taxAuthorityView, out registrationId);


            var saveInfo = this.accountRepository.saveTaxAuthorityInfo(taxAuthorityView, registrationId);

            var getRole = this.accountRepository.GetAdminRoleUserRoles(EnvironmentValues.TaxAuthority);
            //
            this.accountRepository.CreateUserRole(taxAuthorityView.Email, getRole.AdminRoleId);

            if (savedData == string.Empty)
            {
                //Send activation Link to the User,
                //Genenrate Activation Code
                var activationCode = CodeGenerators.GenerateActivationCode();

                //Get The registered User Information
                var user = this.accountRepository.GetRegistrationByEmail(taxAuthorityView.Email);

                //Pass the Code and the user ID to store to Database
                var result = this.accountRepository.SaveUserActivationCode(user.UserRegistrationId, activationCode);


                // email send implementation here
                var emailDetail =
                    this.emailFactory.CreateRegistrationRequestEmail(taxAuthorityView.Email, taxAuthorityView.FirstName,
                        activationCode); //999 is the registrationId from database

                var emailKey = this.environment[EnvironmentValues.EmailKey];

                this.emailService.Send(emailKey, "team@aditng.com", "Pitalytics Team", emailDetail.Subject,
                   emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);



            }


            return returnViewModel;
        }




        #region
        /// Gets the users by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IUserListView GetUsersById(int userId, string message)
        {
            var usersCollection = this.accountRepository.GetUserRegistrationsById(userId).ToList();


            return this.accountViewsModelFactory.CreateUsersListView(usersCollection, message);



        }
        #endregion

        /// <summary>



        /// <summary>
        /// Processes the system admin users registration information.
        /// </summary>
        /// <param name="userAgentofDeductionView">The user agentof deduction view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">userAgentofDeductionView</exception>
        public IUserView ProcessSystemAdminUsersRegistrationInfo(IUserView userView)
        {
            if (userView == null)
            {
                throw new System.ArgumentNullException(nameof(userView));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //checks if similar email does exist in the database 
            var registrationData = this.accountRepository.GetRegistrationByEmail(userView.Email);
            var IsRecordExist = (registrationData != null);

            if (IsRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.IsEmailExist;
            }

            var returnViewModel =
                this.accountViewsModelFactory.CreateUpdatedRegistraionView(userView, processingMessage);

            if (!isDataOkay)
            {
                return returnViewModel;
            }

            //save data to database
            var registrationId = 0;

            userView.Password = this.encryptionService.Encrypt(userView.Password);
            userView.IsActive = true;
            var savedData = this.accountRepository.SaveRegistrationInfo(userView, out registrationId);
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var role = (string[])session.GetSessionValue(SessionKey.UserRoles);

            if (string.IsNullOrEmpty(savedData))
            {

                savedData = this.accountRepository.SaveSystemAdminUser(userId, registrationId);
            }

            var roleInfo = this.accountRepository.GetAdminRoleUserRoles(role[0]);
            this.accountRepository.CreateUserRole(userView.Email, roleInfo.UserRoleId);

            if (savedData == string.Empty)
            {
                //Send activation Link to the User,
                //Genenrate Activation Code
                var activationCode = CodeGenerators.GenerateActivationCode();

                //Get The registered User Information
                var user = this.accountRepository.GetRegistrationByEmail(userView.Email);

                //Pass the Code and the user ID to store to Database
                var result = this.accountRepository.SaveUserActivationCode(user.UserRegistrationId, activationCode);


                // email send implementation here
                var emailDetail =
                    this.emailFactory.CreateRegistrationRequestEmail(userView.Email, userView.FirstName,
                        activationCode); //999 is the registrationId from database

                var emailKey = this.environment[EnvironmentValues.EmailKey];

                this.emailService.Send(emailKey, "team@aditng.com", "Pitalytics Team", emailDetail.Subject,
                   emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);



            }


            return returnViewModel;
        }


        /// <summary>
        /// Gets the forget password view.
        /// </summary>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public IEmailVerificationView GetForgetPasswordView(string processingMessage)
        {
            // send it to accounts view factory to create the view factory
            var viewModel = this.accountViewsModelFactory.CreateForgetPasswordView(processingMessage);

            // return the view to controller
            return viewModel;
        }

        /// <summary>
        /// Processes the forget password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public string ProcessForgetPassword(string email)
        {
            string processingMessage = "";

            var user = this.accountRepository.GetRegistrationByEmail(email);

            if (user == null)
            {
                processingMessage = "This Account does not exist. Please check your email";
            }
            else
            {
                //Genenrate Activation Code
                var activationCode = CodeGenerators.GenerateActivationCode();

                //Pass the Code and the user ID to store to Database
                var result = this.accountRepository.SaveUserActivationCode(user.UserRegistrationId, activationCode);


                //Generate Forgot Password Email From the factory
                var emailDetail = this.emailFactory.CreateForgetPasswordEmail(activationCode, email);

                var emailKey = this.environment[EnvironmentValues.EmailKey];
                this.emailService.Send(emailKey, "admin@automataAssociates.com", "Pitalytics Team", emailDetail.Subject,
                    emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);

                processingMessage = "A link has been sent to your mail for activation";
            }


            return processingMessage;
        }
        /// <summary>
        /// Gets the updated registration view.
        /// </summary>
        /// <param name="userAgentofDeductionView">The user agentof deduction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">userAgentofDeductionView</exception>
        public IUserAgentofDeductionView GetUpdatedRegistrationView(IUserAgentofDeductionView userAgentofDeductionView, string processingMessage)
        {
            if (userAgentofDeductionView == null)
            {
                throw new ArgumentNullException(nameof(userAgentofDeductionView));
            }
            var industry = this.generalRepository.GetIndustry().Where(x => x.IsActive = true).ToList();
            return this.accountViewsModelFactory.CreateUpdatedRegistraionView(userAgentofDeductionView, processingMessage,industry);
        }
        /// <summary>
        /// Gets the updated registration view.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">taxAuthorityView</exception>
        public ITaxAuthorityView GetUpdatedRegistrationView(ITaxAuthorityView taxAuthorityView, string processingMessage)
        {
            if (taxAuthorityView == null)
            {
                throw new ArgumentNullException(nameof(taxAuthorityView));
            }
            var jurisidctionList = this.generalRepository.GetJurisdiction();
            jurisidctionList = jurisidctionList.Where(x => x.IsActive == true).ToList();
            var inlandRevenueNameList = this.generalRepository.GetInlandRevenue();
            inlandRevenueNameList = inlandRevenueNameList.Where(x => x.IsActive == true).ToList();

            return this.accountViewsModelFactory.CreateUpdatedRegistraionView(taxAuthorityView,jurisidctionList,inlandRevenueNameList, processingMessage);
        }


        /// Gets the updated registration view.
        /// </summary>
        /// <param name="userAgentofDeductionView">The user agentof deduction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">userAgentofDeductionView</exception>
        public IUserView GetUpdatedRegistrationView(IUserView userView, string processingMessage)
        {
            if (userView == null)
            {
                throw new ArgumentNullException(nameof(userView));
            }

            return this.accountViewsModelFactory.CreateUpdatedRegistraionView(userView, processingMessage);
        }
        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="passwordInfo">The password information.</param>
        /// <returns></returns>
        public string SavePassword(IPasswordView passwordInfo)
        {
            passwordInfo.Password = this.encryptionService.Encrypt(passwordInfo.Password);


            return this.accountRepository.SavePassword(passwordInfo);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <returns></returns>
        
        /// <summary>
        /// Checks the code validity.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IPasswordView CheckCodeValidity(string code)
        {
            string processingMessage = "";
            var getUser = this.accountRepository.CheckActivationCode(code);

            if (getUser == null)
            {
                processingMessage = "Your activation code is either invalid or expired. Please request another link";
            }

            return this.accountViewsModelFactory.ProcessPasswordView(processingMessage, getUser.UserRegistrationId,
                getUser.ActivationCode);
        }


        /// <summary>
        /// Processes the confirm activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        public string ProcessConfirmActivationCode(string code)
        {
            return this.accountRepository.UpdateActivationCode(code);
        }
        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        public IUserRegistration GetUserByEmail(ILogOnView logOnView)
        {
            return this.accountRepository.GetUserByEmail(logOnView.Email);
        }

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="logonModel">The logon model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">logonModel</exception>
        public bool SignIn(ILogOnView logonModel)
        {
            if (logonModel == null)
            {
                throw new ArgumentNullException(nameof(logonModel));
            }

            var userInfo = this.accountRepository.GetUserByEmail(logonModel.Email);
            if (userInfo == null)
            {
                return false;
            }

            var decryptedValue = this.encryptionService.Decrypt(userInfo.Password);
            if (!logonModel.Password.Equals(decryptedValue))
            {
                return false;
            }
            

            var userActionList = this.accountRepository.GetUserRoleActions(logonModel.Email).ToList();
            

            if (!userActionList.Any())
            {
                userActionList = new List<IUserRolesModel>();
            }

            var actionList = userActionList.Select(x => x.UserRolesDescription).ToArray();
            session.AddValueToSession(SessionKey.UserRoles, actionList[0]);
            this.SetUp(actionList[0], userInfo.UserRegistrationId);

            bool check = true;


            session.AddValueToSession(SessionKey.UserRoles, actionList);
            session.AddValueToSession(SessionKey.UserId, userInfo.UserRegistrationId);
            session.AddValueToSession(SessionKey.UserName, logonModel.Email);
            session.AddValueToSession(SessionKey.FullName, userInfo.FirstName);
            session.AddValueToSession(SessionKey.Email, userInfo.Email);
            session.AddValueToSession(SessionKey.UserIsAuthenticated, true);
           

            this.formsAuthentication.SignIn(logonModel.Email, logonModel.RememberMe);
            return true;
        }

         


        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesView</exception>
        public string DeleteUserRoles(string email, int userRolesId)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (userRolesId < 0)
            {
                throw new ArgumentNullException("userRolesId");
            }

            var result = this.accountRepository.DeleteUserRoles(email, userRolesId);
            return result;
        }

        /// <summary>
        /// Saves the user roles.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRolesView</exception>
        public string SaveUserRoles(IUserRolesView userRolesView)
        {
            var processingMessage = string.Empty;
            if (userRolesView == null)
            {
                throw new ArgumentNullException(nameof(userRolesView));
            }

            var result = this.accountRepository.SaveUserRolesInfo(userRolesView);

            //check for current roles

            var currentRoles = this.accountRepository.CheckCurrentRoles(userRolesView.Email, userRolesView.UserRolesId);
            if (currentRoles)
            {
                processingMessage = Messages.IsRolesExist;
                return this.accountViewsModelFactory.CreateUserRolesView(processingMessage);
            }
            var userInfo = this.accountRepository.SaveUserRolesInfo(userRolesView);
            return this.accountViewsModelFactory.CreateUserRolesView(userInfo);
        }

        /// <summary>
        /// Gets the activation status.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        public bool GetActivationStatus(ILogOnView logOnView)
        {
            var userInfo = this.accountRepository.GetUserByEmail(logOnView.Email);
            if ((userInfo == null) || (userInfo.IsUserVerified == false) || (userInfo.IsUserVerified == null))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Gets the user status.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>

        public bool GetUserStatus(ILogOnView logOnView)
        {
            var userInfo = this.accountRepository.GetUserByEmail(logOnView.Email);
            if ((userInfo == null) || (userInfo.IsActive == false))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Signs the off.
        /// </summary>
        public void SignOff()
        {
            session.RemoveSessionValue(SessionKey.Email);
            session.RemoveSessionValue(SessionKey.UserIsAuthenticated);

            var userName = (session.GetSessionValue(SessionKey.Email) ?? "").ToString();
            this.formsAuthentication.SignOut(userName);
        }

        /// <summary>
        /// Logs the activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        public void LogActivity(string userId, string theActivity, string orderIdentifier)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (theActivity == null)
            {
                throw new ArgumentNullException(nameof(theActivity));
            }

            this.accountRepository.LogUserActivity(userId, theActivity, orderIdentifier);
        }
        /// <summary>
        /// Sets up.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <param name="userId">The user identifier.</param>
        public void SetUp(string roles, int userId)
        {

            if (roles == (EnvironmentValues.AgentOfDeduction))
            {
                var agentId = this.accountRepository.GetAgentOfDeductionId(userId);
                var branches = this.agentOfDeductionRepository.GetAgentOfdeductionBranch(agentId.AgentOfDeductionId).Where(x => x.IsActive == true).Count();
                session.AddValueToSession(SessionKey.AgentOfDeductionId, agentId.AgentOfDeductionId);


                var registeredUsers = this.accountRepository.GetRegisteredUsers(userId).Count();
                var users = this.accountRepository.GetUnRegisteredUsers(userId).Count();

                session.AddValueToSession(SessionKey.Branches, branches);
                session.AddValueToSession(SessionKey.UnRegisteredUsers, users);
                session.AddValueToSession(SessionKey.RegisteredUsers, registeredUsers);


            }
            else if (roles == (EnvironmentValues.TaxAgentUsers))
            {
                var branches = this.agentOfDeductionRepository.GetBranchByUserId(userId).Where(x=>x.IsActive==true).Count();
                var agentInfo = this.accountRepository.GetAdminByUserId(userId);
                var agentId = this.accountRepository.GetAgentOfDeductionId(agentInfo.UserRegistrationId);
                session.AddValueToSession(SessionKey.AgentOfDeductionId, agentId.AgentOfDeductionId);

                session.AddValueToSession(SessionKey.Branches, branches);


            }
            else if (roles == (EnvironmentValues.SystemAdmin))
            {

                var registeredtaxAgent = this.generalRepository.GetAgentOFDeduction().Where(x => x.IsActive == true).Count();
                session.AddValueToSession(SessionKey.ApprovedTaxAgent, registeredtaxAgent);
                var unregisteredTaxAgent = this.generalRepository.GetAgentOFDeduction().Where(x => x.IsActive == false).Count();
                session.AddValueToSession(SessionKey.UnApprovedTaxAgent, unregisteredTaxAgent);

                var taxAuthority = this.generalRepository.GetTaxAuthority().Count();
                session.AddValueToSession(SessionKey.TaxAuthority, taxAuthority);
                var registeredUsers = this.accountRepository.GetRegisteredUsers(userId).Count();
                var users = this.accountRepository.GetUnRegisteredUsers(userId).Count();
                var incomeTypes = this.generalRepository.GetIncomeType().Where(x => x.IsActive == true).Count();

                session.AddValueToSession(SessionKey.UnRegisteredUsers, users);
                session.AddValueToSession(SessionKey.IncomeTypes, incomeTypes);

                session.AddValueToSession(SessionKey.RegisteredUsers, registeredUsers);


            }

            else if (roles == (EnvironmentValues.SystemAdminUsers))
            {
                var registeredtaxAgent = this.generalRepository.GetAgentOFDeduction().Where(x => x.IsActive == true).Count();
                session.AddValueToSession(SessionKey.ApprovedTaxAgent, registeredtaxAgent);
                var unregisteredTaxAgent = this.generalRepository.GetAgentOFDeduction().Where(x => x.IsActive == false).Count();
                session.AddValueToSession(SessionKey.UnApprovedTaxAgent, unregisteredTaxAgent);
              

                var taxAuthority = this.generalRepository.GetTaxAuthority().Count();
                session.AddValueToSession(SessionKey.TaxAuthority, taxAuthority);

                var incomeTypes = this.generalRepository.GetIncomeType().Where(x => x.IsActive == true).Count();


                session.AddValueToSession(SessionKey.IncomeTypes, incomeTypes);




            }


            else if (roles == (EnvironmentValues.TaxAuthority))
            {
                var taxAuthorityId = this.accountRepository.GetTaxAuthorityById(userId);

                var branches = this.agentOfDeductionRepository.GetBranchByJurisdiction(taxAuthorityId.JurisdictionId).Count();
                var users = this.accountRepository.GetUnRegisteredUsers(userId).Count();
                var registeredUsers = this.accountRepository.GetRegisteredUsers(userId).Count();
                session.AddValueToSession(SessionKey.JurisdictionId, taxAuthorityId.JurisdictionId);
                session.AddValueToSession(SessionKey.Branches, branches);
                session.AddValueToSession(SessionKey.UnRegisteredUsers, users);
                session.AddValueToSession(SessionKey.RegisteredUsers, registeredUsers);


            }
            else if (roles == (EnvironmentValues.TaxAuthorityUsers))
            {
                var agentId = this.accountRepository.GetAdminByUserId(userId);

                var taxAuthorityId = this.accountRepository.GetTaxAuthorityById(agentId.UserRegistrationId);
                session.AddValueToSession(SessionKey.AgentOfDeductionId, taxAuthorityId.JurisdictionId);
                var branches = this.agentOfDeductionRepository.GetBranchByJurisdiction(taxAuthorityId.JurisdictionId).Count();

                session.AddValueToSession(SessionKey.Branches, branches);
            }
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <returns></returns>
        public IChangePasswordView ChangePassword(IChangePasswordView changePassword)
        {
            var processingMessage = string.Empty;
            var email = (string)session.GetSessionValue(SessionKey.Email);
            var userInfo = this.accountRepository.GetUserByEmail(email);
            var decryptedPassword = this.encryptionService.Decrypt(userInfo.Password);
            if (!changePassword.OldPassword.Equals(decryptedPassword))
            {
                processingMessage = Messages.PasswordNotEqual;
              }
            else
            {
                var encrypptedPassword = this.encryptionService.Encrypt(changePassword.NewPassword);
                changePassword.NewPassword = encrypptedPassword;
                 var returnInfo = this.accountRepository.ChangePassword(changePassword, email);
                returnInfo = processingMessage;
            }

            return this.accountViewsModelFactory.ChangePassword(changePassword, processingMessage);

        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns></returns>
        public IChangePasswordView ChangePassword()
        {

            return this.accountViewsModelFactory.ChangePassword();

        }

    }
}
