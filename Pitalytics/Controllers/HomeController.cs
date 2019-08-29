using AA.Infrastructure.Interfaces;
using Pitalytics.Domain.Models;
using Pitalytics.Interfaces;
using Pitalytics.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pitalytics.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// The account service
        /// </summary>
        private readonly IAccountService accountService;

        /// <summary>
        /// The session
        /// </summary>
        private readonly ISessionStateService session;


        /// <summary>
        /// Initializes a new instance of the <see cref="AgentOfDeductionController"/> class.
        /// </summary>
        /// <param name="agentOfDeductionService">The agent of deduction service.</param>
        public HomeController(IAccountService accountService,ISessionStateService session)
        {
            this.accountService = accountService;
            this.session = session;
        }
        // GET

        public ActionResult Index()
        {
            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var userRole = (String[])session.GetSessionValue(SessionKey.UserRoles);

            this.accountService.SetUp(userRole[0], userId);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Employee(EmployeeModel empmodel)
        {
            if (ModelState.IsValid)
            {
                // Business Logic
                ViewBag.Message = "Sucess or Failure Message";
         //       ModelState.Clear();
                return PartialView("_Employee");
            }
            return PartialView("_Employee", empmodel);
        }

    }
}