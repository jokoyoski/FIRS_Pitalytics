using System.Collections.Generic;

namespace Pitalytics.Interfaces
{
    public interface IAccountRepository
    {


        #region Users          
        /// <summary>
        /// Gets the registered users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<IUserRegistration> GetRegisteredUsers(int userId);
/// <summary>
/// 
/// </summary>
/// <param name="userId"></param>
/// <returns></returns>
        IList<IUserRegistration> GetUnRegisteredUsers(int userId);
        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string DeactivateUser(int registrationId);
        /// <summary>
        /// Gets the admin role user roles.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        IRoleStatus GetAdminRoleUserRoles(string role);
        /// <summary>
        /// Gets the user registrations by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<IUserRegistration> GetUserRegistrationsById(int userId);

        /// <summary>
        /// Saves the system admin user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="SystemAdminId">The system admin identifier.</param>
        /// <returns></returns>
        string SaveSystemAdminUser(int userId, int SystemAdminId);
        #endregion        
        /// <summary>
        /// Gets the agent of deduction by cac number.
        /// </summary>
        /// <param name="cacNumber">The cac number.</param>
        /// <returns></returns>
        IAgentOfDeduction GetAgentOfDeductionByCacNumber(string cacNumber);// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string ActivateUser(int registrationId);
        /// <summary>
        /// Gets the agent of deduction identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IAgentOfDeduction GetAgentOfDeductionId(int userId);

        /// <summary>
        /// Gets the tax authority.
        /// </summary>
        /// <param name="revenueId">The revenue identifier.</param>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        IList<ITaxAuthority> GetTaxAuthority(int revenueId, int jurisdictionId);
        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string SaveRegistrationInfo(IUserView registrationInfo, out int registrationId);



        /// <summary>
        /// Gets the tax authority by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ITaxAuthority GetTaxAuthorityById(int userId);
        /// <summary>
        /// Gets the admin by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUserRegistration GetAdminByUserId(int userId);

        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string SaveRegistrationInfo(ITaxAuthorityView registrationInfo, out int registrationId);
        /// <summary>
        /// Saves the tax authority information.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string saveTaxAuthorityInfo(ITaxAuthorityView taxAuthorityView, int registrationId);
        /// <summary>
        /// Saves the agentof deduction information.
        /// </summary>
        /// <param name="agentOfDeductionView">The agent of deduction view.</param>
        /// <returns></returns>
        string saveAgentofDeductionInfo(IUserAgentofDeductionView agentOfDeductionView, int registrationId);
        /// <summary>
        /// Checks the current roles.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <returns></returns>
        bool CheckCurrentRoles(string email, int userRolesId);
        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        string DeleteUserRoles(string email, int userRolesId);
        /// <summary>
        /// Saves the user roles information.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        string SaveUserRolesInfo(IUserRolesView userRolesView);
        /// <summary>
        /// Gets the user role collections.
        /// </summary>
        /// <returns></returns>
        IList<IUserRolesModel> GetUserRoleCollections();
        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        IList<IUserRegistration> GetUserRegistration();


        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IUserRegistration GetUserId(int Id);


        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string SavePassword(IPasswordView registrationInfo);


        /// <summary>
        /// Updates the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        string UpdateActivationCode(string code);


        /// <summary>
        /// Checks the activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IUserActivationCode CheckActivationCode(string code);


        /// <summary>
        /// Saves the user activation code.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        string SaveUserActivationCode(int userId, string activationCode);


        /// <summary>
        /// Gets the registration information by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        // IRegistration GetRegistrationByUserId(string userId);

        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IUserRegistration GetRegistrationByEmail(string email);

        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string SaveRegistrationInfo(IUserAgentofDeductionView registrationInfo, out int registrationId);

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        //string SendEmail(IEmailDetail registrationRequestEmail);

        IUserRegistration GetUserByEmail(string email);


        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        IList<IUserRolesModel> GetUserRoleActions(string email);

        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string CreateUserRole(string email, int role);


        /// <summary>
        /// Gets the user role actions by identifier.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        IList<int> GetUserRoleActionsById(string email);

        /// <summary>
        /// Logs the user action.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theAction">The action.</param>
        /// <param name="isGranted">if set to <c>true</c> [is granted].</param>
        void LogUserAction(string userId, string theAction, bool isGranted);

        /// <summary>
        /// Logs the user activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        void LogUserActivity(string userId, string theActivity, string orderIdentifier);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        string ChangePassword(IChangePasswordView changePassword, string email);

    }
}

