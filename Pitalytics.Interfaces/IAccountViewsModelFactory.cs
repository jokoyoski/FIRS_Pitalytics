using System.Collections.Generic;

namespace Pitalytics.Interfaces
{
    public interface IAccountViewsModelFactory 
    {

        #region Users
        IUserListView CreateUsersListView(IList<IUserRegistration> userListView,string message);
        #endregion
        ITaxAuthorityView CreateTaxAuthorityRegistrationView(IList<IInlandRevenue> inlandRevenues, IList<IJurisdiction> jurisdictions);
        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITaxAuthorityView CreateUpdatedRegistraionView(ITaxAuthorityView taxAuthorityView,IList<IJurisdiction>jurisdictions,IList<IInlandRevenue>taxAuthorities, string processingMessage);
        /// <summary>
        /// Creates the system admin register view.
        /// </summary>
        /// <returns></returns>
        IUserView CreateSystemAdminRegisterView(string infoMessage);
        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="userAgentofDeductionView">The user agentof deduction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserView CreateUpdatedRegistraionView(IUserView userAgentofDeductionView, string processingMessage);
        /// <summary>
        /// Creates the user roles view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        string CreateUserRolesView(string processingMessage);
      
        /// Creates the user registration view.
        /// </summary>
        /// <param name="userList">The user list.</param>
        /// <returns></returns>
        IUserListView CreateUserRegistrationView(IList<IUserRegistration> userList,string Email,string FirstName);
        /// <summary>
        /// Processes the email verification view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmailVerificationView ProcessEmailVerificationView(string processingMessage);

        /// <summary>
        /// Creates the forget password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmailVerificationView CreateForgetPasswordView(string processingMessage);

        /// <summary>
        /// Processes the password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IPasswordView ProcessPasswordView(string processingMessage,int userId,string code);



        /// <summary>
        /// Processes the registration view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserView ProcessRegistrationView(string processingMessage);

        /// <summary>
        /// Creates the registration view.
        /// </summary>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns>Returns Registration view model</returns>
        IUserAgentofDeductionView CreateRegistrationView(IList<IIndustry>industries);

        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        IUserAgentofDeductionView CreateUpdatedRegistraionView(IUserAgentofDeductionView userAgentofDeductionView, string processingMessage,IList<IIndustry>industries);

        /// <summary>
        /// Creates the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        ILogOnView CreateLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IChangePasswordView ChangePassword(IChangePasswordView changePassword, string processingMessage);

        IChangePasswordView ChangePassword();



    }
}
