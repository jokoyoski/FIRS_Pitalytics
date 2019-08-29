namespace Pitalytics.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountService
    {
        #region Users



        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        string DeactivateUser(int userId);
        /// <summary>
        /// Gets the users by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IUserListView GetUsersById(int userId, string message);

        #endregion


        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        IUserRegistration GetUserByEmail(ILogOnView logOnView);
        
            /// <summary>
            /// Sets up.
            /// </summary>
            /// <param name="roles">The roles.</param>
            /// <param name="userId">The user identifier.</param>
            void SetUp(string roles, int userId);
        /// <summary>
        /// Gets the updated registration view.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITaxAuthorityView GetUpdatedRegistrationView(ITaxAuthorityView taxAuthorityView, string processingMessage);


        /// <summary>
        /// Gets the tax authority regstration view.
        /// </summary>
        /// <returns></returns>
        ITaxAuthorityView GetTaxAuthorityRegstrationView();
        /// <summary>
        /// Processes the tax authority registration information.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <returns></returns>
        ITaxAuthorityView ProcessTaxAuthorityRegistrationInfo(ITaxAuthorityView taxAuthorityView);
        /// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        string ActivateUser(int userId);

        bool GetUserStatus(ILogOnView logOnView);
        /// <summary>
        /// Processes the system admin users registration information.
        /// </summary>
        /// <param name="userView">The user view.</param>
        /// <returns></returns>
        IUserView ProcessSystemAdminUsersRegistrationInfo(IUserView userView);
        /// <summary>
        /// Gets the updated registration view.
        /// </summary>
        /// <param name="userView">The user view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserView GetUpdatedRegistrationView(IUserView userView, string processingMessage);
        /// <summary>
        /// Creates the system admin register view.
        /// </summary>
        /// <returns></returns>
        IUserView CreateSystemAdminRegisterView(string infoMessage);
        /// <summary>
        /// Gets the updated registration view.
        /// </summary>
        /// <param name="userAgentofDeductionView">The user agentof deduction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserAgentofDeductionView GetUpdatedRegistrationView(IUserAgentofDeductionView userAgentofDeductionView, string processingMessage);

        /// <summary>
        /// Deletes the user roles.
        /// </summary> 
        /// <param name="email">The email.</param>
        /// <param name="userRolesId">The user roles identifier.</param>
        /// <returns></returns>
        string DeleteUserRoles(string email, int userRolesId);
        /// <summary>
        /// Deletes the user roles.
        /// </summary>
        /// <param name="userRolesView">The user roles view.</param>
        /// <returns></returns>
        string SaveUserRoles(IUserRolesView userRolesView);

        /// <summary>
        /// Gets the user registration.
        /// </summary>
        /// <returns></returns>
        IUserListView GetUserRegistration(string Email, string FirstName);
        /// <summary>
        /// Gets the activation status.
        /// </summary>
        /// <param name="logOnView">The log on view.</param>
        /// <returns></returns>
        bool GetActivationStatus(ILogOnView logOnView);

        /// <summary>
        /// Gets the forget password view.
        /// </summary>
        /// <returns></returns>
        IEmailVerificationView GetForgetPasswordView(string processingMessage);

        /// <summary>
        /// Processes the confirm activation code.
        /// </summary>
        /// <param name="code">The code.</param>
        string ProcessConfirmActivationCode(string code);

        /// <summary>
        /// Saves the password.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string SavePassword(IPasswordView registrationInfo);

        /// <summary>
        /// Checks the code validity.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IPasswordView CheckCodeValidity(string code);

        /// <summary>
        /// Processes the forget password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        string ProcessForgetPassword(string email);


        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <returns></returns>
        IUserAgentofDeductionView GetRegistrationView();

        /// <summary>
        /// Processes the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        IUserAgentofDeductionView ProcessAgentofDeductionRegistrationInfo(IUserAgentofDeductionView userAgentofDeductionView);

        /// <summary>
        /// Gets the log on view. a
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        ILogOnView GetLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl);

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="logonModel">The logon model.</param>
        /// <returns></returns>
        bool SignIn(ILogOnView logonModel);

        /// <summary>
        /// Signs the off.
        /// </summary>
        void SignOff();

        /// <summary>
        /// Logs the activity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="theActivity">The activity.</param>
        /// <param name="orderIdentifier">The order identifier.</param>
        void LogActivity(string userId, string theActivity, string orderIdentifier);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <returns></returns>
        IChangePasswordView ChangePassword(IChangePasswordView changePassword);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns></returns>
        IChangePasswordView ChangePassword();
    }
}

