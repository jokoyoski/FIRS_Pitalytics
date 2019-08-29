using AA.Infrastructure.Interfaces;


using Pitalytics.Interfaces.ValueTypes;
using Pitalytics.Domain.Models;

using System;
using System.Web.Mvc;
using Pitalytics.Interfaces;

namespace Pitalytics.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService accountService;



        private readonly ISessionStateService session;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="transactionService">The transaction service.</param>
        /// <param name="session">The session.</param>
        /// <param name="orderServices">The order services.</param>

        public AccountController(IAccountService accountService,
            ISessionStateService session)
        {
            this.accountService = accountService;

            this.session = session;


        }
        ///
        #region Registration


        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult RegisterAgentofDeduction()
        {
            var viewModel = this.accountService.GetRegistrationView();

            return this.View("RegisterAgentofDeduction", viewModel);
        }


        /// <summary>
        /// Registrations the specified registration.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registration</exception>
        [AllowAnonymous, HttpPost]
        public ActionResult RegisterAgentofDeduction(UserAgentOfDeductionView userAgentOfDeductionView)
        {
            if (userAgentOfDeductionView == null)
            {
                throw new ArgumentNullException("userAgentOfDeductionView");
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                var returnView = this.accountService.GetUpdatedRegistrationView(userAgentOfDeductionView, "");
                return this.View("RegisterAgentofDeduction", returnView);
            }

            // call service in domain to process Registration information
            var returnModel = this.accountService.ProcessAgentofDeductionRegistrationInfo(userAgentOfDeductionView);

            // check if there is error message then redisplay view using model
            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                return this.View("RegisterAgentofDeduction", returnModel);
            }

            return this.RedirectToAction("Login", "Account",
                 new { infoMessage = "We have sent an email, Please Login to continue" });
        }



        [AllowAnonymous, HttpGet]
        public ActionResult RegisterTaxAuthority()
        {
            var viewModel = this.accountService.GetTaxAuthorityRegstrationView();

            return this.View("RegisterTaxAuthority", viewModel);
        }
        /// <summary>
        /// Registers the tax authority.
        /// </summary>
        /// <param name="taxAuthorityView">The tax authority view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userAgentOfDeductionView</exception>
        [AllowAnonymous, HttpPost]
        public ActionResult RegisterTaxAuthority(TaxAuthorityView taxAuthorityView)
        {
            if (taxAuthorityView == null)
            {
                throw new ArgumentNullException("taxAuthorityView");
            }


            if(taxAuthorityView.JurisdictionId==-1)
            {
                this.ModelState.AddModelError("", "Ensure to select the correct jurisdiction");

                var returnInfo = this.accountService.GetUpdatedRegistrationView(taxAuthorityView, "");
                return this.View("RegisterTaxAuthority", taxAuthorityView);
            }


            if (taxAuthorityView.InlandRevenueId == -1)
            {
                this.ModelState.AddModelError("", "Ensure to select the correct Inland Revenues");

                var returnInfo = this.accountService.GetUpdatedRegistrationView(taxAuthorityView, "");

                return this.View("RegisterTaxAuthority", taxAuthorityView);
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                var returnView = this.accountService.GetUpdatedRegistrationView(taxAuthorityView, "");
                return this.View("RegisterTaxAuthority", returnView);
            }

            // call service in domain to process Registration information
            var returnModel = this.accountService.ProcessTaxAuthorityRegistrationInfo(taxAuthorityView);

            // check if there is error message then redisplay view using model
            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                return this.View("RegisterTaxAuthority", returnModel);
            }

            return this.RedirectToAction("Login", "Account",
                 new { infoMessage = "We have sent an email, Please Login to continue" });
        }





        #endregion



        #region  Users

        /// <summary>
        /// Userses this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Users(string infoMessage)
        {

            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId); 

            var users = this.accountService.GetUsersById(userId, infoMessage);
            return View("Users", users);
        }



        /// <summary>
        /// Adds the system admin users.
        /// </summary>
        /// <param name="userView">The user view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userView</exception>
        [AllowAnonymous, HttpPost]
        public ActionResult AddSystemAdminUsers(UserView userView)
        {
            if (userView == null)
            {
                throw new ArgumentNullException("userView");
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                var returnView = this.accountService.GetUpdatedRegistrationView(userView, "");
                return this.PartialView("AddSystemAdminUsers", returnView);
            }

            // call service in domain to process Registration information
            var returnModel = this.accountService.ProcessSystemAdminUsersRegistrationInfo(userView);

            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                var returnView = this.accountService.GetUpdatedRegistrationView(userView, returnModel.ProcessingMessage);
                return this.PartialView("AddSystemAdminUsers", returnView);
            }

            var returnInfo = this.accountService.GetUpdatedRegistrationView(userView, "User account has been created, click on the activation link send to your email");
            return this.PartialView("AddSystemAdminUsers", returnInfo);
        }


        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public ActionResult DeactivateUser(int userId)
        {
            var users = this.accountService.DeactivateUser(userId);


            return this.RedirectToAction("Users", "Account",
                new { infoMessage = "User Deactivated" });
        }
        /// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public ActionResult ActivateUser(int userId)
        {
            var users = this.accountService.ActivateUser(userId);


            return this.RedirectToAction("Users", "Account",
                new { infoMessage = "User Activated" });
        }

        #endregion



        #region Login

        /// <summary>
        /// Logins the specified information message.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult Login(string infoMessage = "", string errorMessage = "", string userName = "",
            string returnUrl = "")
        {
            var viewModel = this.accountService.GetLogOnView(infoMessage, errorMessage, userName, returnUrl);

            return this.View("Login", viewModel);
        }



        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">model</exception>
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LogOnView model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!this.ModelState.IsValid)
            {
                return View("Login", model);
            }

           
         
          
            

            var isUserValid = this.accountService.SignIn(model);
            if (isUserValid)
            {


                //TODO : Account that are not validated should be able to request for anotherr activation code incase they loose the first 
                var userStatus = this.accountService.GetActivationStatus(model);


                if (userStatus == false)
                {
                    this.accountService.SignOff();

                    this.ModelState.AddModelError("", "Ensure to verify your email");


                    return this.View(model);
                }


                userStatus = this.accountService.GetUserStatus(model);


                if (userStatus == false)
                {
                    this.accountService.SignOff();

                    this.ModelState.AddModelError("", "Contact Your Admin");


                    return this.View(model);
                }
           



                return !string.IsNullOrEmpty(model.ReturnUrl)
                    ? (ActionResult)this.Redirect(model.ReturnUrl)
                    : this.RedirectToAction("Index", "Home");
            }

            //Check if the User Account is Validated
           
           

            //Get The Currently Logged User Id
            
            

            this.ModelState.AddModelError("", "Incorrect Email or Password");


            return this.View(model);
        }





        #endregion


        #region Logoff

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            this.accountService.SignOff();

            return this.RedirectToAction("Login", "Account");
        }

        #endregion


        #region Forget Password

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            var viewModel = this.accountService.GetForgetPasswordView(string.Empty);
            return View(viewModel);
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="emailVerification">The email verification.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        [HttpPost]
        public ActionResult ForgetPassword(EmailVerificationView emailVerification)
        {
            if (emailVerification == null)
            {
                throw new ArgumentNullException("emailVerification");
            }

            var processingMessage = string.Empty;

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                return this.View("ForgetPassword");
            }

            processingMessage = this.accountService.ProcessForgetPassword(emailVerification.Email);

            var viewModel = this.accountService.GetForgetPasswordView(processingMessage);


            // call service in domain to process Registration information
            return View("ForgetPassword", viewModel);
        }

        #endregion


        #region Confirm Password

        /// <summary>
        /// Confirms the password.
        /// </summary>
        /// <param name="activationCode">The code.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConfirmPassword(string activationCode)
        {
            var activation = this.accountService.CheckCodeValidity(activationCode);



            if (activation == null)
            {
                return RedirectToAction("Login", "Account",
                    new
                    {
                        infoMessage = "Your activation code is either invalid or expired. Please request another link"
                    });
            }


            return View("ConfirmPassword", activation);
        }

        /// <summary>
        /// Confirms the password.
        /// </summary>
        /// <param name="passwordInfo">The password information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">passwordInfo</exception>
        [HttpPost]
        public ActionResult ConfirmPassword(PasswordView passwordInfo)
        {
            if (passwordInfo == null)
            {
                throw new ArgumentNullException("passwordInfo");
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!ModelState.IsValid)
            {
                return View("ConfirmPassword", passwordInfo);
            }

            var returnModel = this.accountService.SavePassword(passwordInfo);
            if (!string.IsNullOrEmpty(returnModel))
            {
                return this.View("ConfirmPassword", returnModel);
            }

            return this.RedirectToAction("Login", "Account", new { infoMessage = "Password changed successfully" });
        }

        #endregion


        #region Activation Code

        /// <summary>
        /// Activations the code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public ActionResult ActivationCode(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }




            var processingMessage = this.accountService.ProcessConfirmActivationCode(code);

            if (string.IsNullOrEmpty(processingMessage))
            {
                processingMessage = "Your account has been verified, You can now login";
            }
            else
            {
                processingMessage = "Invalid Activation code, Please try again";
            }


            return RedirectToAction("Login", "Account", new { infoMessage = processingMessage });
        }

        #endregion

        #region Change Password
        [HttpGet]
        public ActionResult ChangePassword()
        {
            var viewModel = this.accountService.ChangePassword();
            return this.View("ChangePassword", viewModel);
        }

        [HttpPost]
        public ActionResult ChangePassword(IChangePasswordView changePassword)
        {
           if (changePassword == null)
            {
                throw new ArgumentNullException(nameof(changePassword));
            }
            var changePasswordInfo = this.accountService.ChangePassword(changePassword);

            if(string.IsNullOrEmpty(changePasswordInfo.ProcessingMessage))
            {
                changePasswordInfo.ProcessingMessage = "Your Password Saved Successfully";
            }

            return View("ChangePasssword", changePassword);
        }

        #endregion

        //var userId = (in)session.GetSessionValue(SessionKey.UserId);
    }
}

