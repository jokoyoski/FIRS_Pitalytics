using System;
using System.Collections.Generic;
using Pitalytics.Domain.Models;

using Pitalytics.Interfaces;
using System.Linq;
using Pitalytics.Domain.Utilities;

namespace Pitalytics.Domain.Factories
{
    /// <summary>
    /// Accounts views model factory, creates different view models for account controller
    /// </summary>
    /// <seealso cref="IAccountViewsModelFactory" />
    public class AccountViewsModelFactory : IAccountViewsModelFactory
    {
       
        /// <summary>
        /// Creates the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ILogOnView CreateLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl)
        {
            var model = new LogOnView
            {

                InfoMessage = infoMessage ?? "",
                ErrorMessage = errorMessage ?? "",
                Email = userName ?? "",
                ReturnUrl = returnUrl ?? ""


            };
            return model;

        }

        /// <summary>
        /// Creates the registration view.
        /// </summary>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns>Registration view model</returns>
        /// <exception cref="ArgumentNullException">aboutUsSourceCollection</exception>
        public IUserAgentofDeductionView CreateRegistrationView(IList<IIndustry>industries)
        {

            var industriesDDL = GetIndustryDropDownList.GetIndustry(industries, -1);
            var view = new UserAgentOfDeductionView
            {
              IndustryList=industriesDDL,
            };

            return view;
        }



        public IUserView CreateSystemAdminRegisterView(string infoMessage)
        {


            var view = new UserView
            {
                ProcessingMessage = infoMessage
            };

            return view;
        }


        /// <summary>
        /// Creates the user registration view.
        /// </summary>
        /// <returns></returns>
        public IUserListView CreateUserRegistrationView(IList<IUserRegistration>userList,string Email,string FirstName)
        {
            
           
            //filter with desciprtion
         var  filteredList = userList.Where(x => x.FirstName.Contains(string.IsNullOrEmpty(FirstName) ? x.FirstName : FirstName)).ToList();
            filteredList = userList.Where(x => x.Email.Contains(string.IsNullOrEmpty(Email) ? x.Email :Email)).ToList();


            var view = new UserListView
            {


                UserRegistrationList=filteredList
            };

            return view;
        }

        public IEmailVerificationView CreateForgetPasswordView(string processingMessage)
        {


            var view = new EmailVerificationView
            {


                ProcessingMessage = processingMessage
            };

            return view;
        }


        /// <summary>
        /// Creates the user roles view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public string CreateUserRolesView(string processingMessage)
        {


            return processingMessage;


        }


        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        public IUserAgentofDeductionView CreateUpdatedRegistraionView(IUserAgentofDeductionView userAgentofDeductionView, string processingMessage,IList<IIndustry>industries)
        {
            if (userAgentofDeductionView == null)
            {
                throw new ArgumentNullException(nameof(userAgentofDeductionView));
            }
            var industryDDl = GetIndustryDropDownList.GetIndustry(industries, userAgentofDeductionView.IndustryId);
            userAgentofDeductionView.ProcessingMessage = processingMessage;
            userAgentofDeductionView.IndustryList = industryDDl;
            return userAgentofDeductionView;

        }




        /// <summary>
        /// Creates the tax authority registration view.
        /// </summary>
        /// <returns></returns>
        public ITaxAuthorityView CreateTaxAuthorityRegistrationView(IList<IInlandRevenue>inlandRevenues,IList<IJurisdiction>jurisdictions)
        {
            var inlandRevenueNameDDL = GetInlandRevenueDropdown.GetInlandRevnue(inlandRevenues, -1);
            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);

            var view = new TaxAuthorityView
            {
                InlandRevenueNames=inlandRevenueNameDDL,
                JurisdictionNames=jurisdictionDDL
            };

            return view;
        }
        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">taxAuthorityView</exception>
        public ITaxAuthorityView CreateUpdatedRegistraionView(ITaxAuthorityView taxAuthorityView,IList<IJurisdiction>jurisdictions,IList<IInlandRevenue>inlandRevenues, string processingMessage)
        {
            if (taxAuthorityView == null)
            {
                throw new ArgumentNullException(nameof(taxAuthorityView));
            }
            var inlandRevenueNameDDL = GetInlandRevenueDropdown.GetInlandRevnue(inlandRevenues, -1);
            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);

            taxAuthorityView.ProcessingMessage = processingMessage;
            taxAuthorityView.InlandRevenueNames = inlandRevenueNameDDL;
            taxAuthorityView.JurisdictionNames = jurisdictionDDL;

            return taxAuthorityView;

        }

        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="userAgentofDeductionView">The user agentof deduction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userAgentofDeductionView</exception>
        public IUserView CreateUpdatedRegistraionView(IUserView userView, string processingMessage)
        {
            if (userView == null)
            {
                throw new ArgumentNullException(nameof(userView));
            }

            userView.ProcessingMessage = processingMessage;

            return userView;

        }


        /// <summary>
        /// Processes the registration view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IUserView ProcessRegistrationView(string processingMessage)
        {
            var view = new UserView
            {
               
                ProcessingMessage=processingMessage
            };
            return view;
        }


        /// <summary>
        /// Processes the email verification view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmailVerificationView ProcessEmailVerificationView(string processingMessage)
        {
            var view = new EmailVerificationView
            {

                ProcessingMessage = processingMessage
            };
            return view;
        }





        /// <summary>
        /// Processes the password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IPasswordView ProcessPasswordView(string processingMessage, int Id,string code)
        {
            var view = new PasswordView
            {
                userId = Id,
                ProcessingMessage = processingMessage,
                code=code

            };
            return view;
        }
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">changePassword</exception>
        public IChangePasswordView ChangePassword(IChangePasswordView changePassword, string processingMessage)
        {
            if (changePassword == null)
            {
                throw new ArgumentNullException(nameof(changePassword));
            }

            var view = new ChangePasswordView
            {
                ProcessingMessage = processingMessage,
               NewPassword=changePassword.NewPassword,
               OldPassword= changePassword.OldPassword,

            };
            return view;
        }
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns></returns>
        public IChangePasswordView ChangePassword()
        {


            var view = new ChangePasswordView
            {

            };
           
            return view;
        }

        #region

        public IUserListView CreateUsersListView(IList<IUserRegistration> userListView,string message)
        {




            var returnView = new UserListView
            {
                UserRegistrationList = userListView,
                ProcessingMessage = message

            };
            return returnView;
        }

        #endregion

    }
}
