﻿namespace Pitalytics.Interfaces.ValueTypes
{
    public struct AppAction
    {
        /// <summary>
        /// The job applicant
        /// </summary>
        public const string Applicant = "Applicant";

        /// <summary>
        /// The recruiter or vacancy admin
        /// </summary>
        public const string Recruiter = "Recruiter";

        /// <summary>
        /// The administration
        /// </summary>
        public const string Administration = "Administration";

        /// <summary>
        /// The user admin
        /// </summary>
        public const string CompanyAdmin = "CompanyAdmin";

        /// <summary>
        /// The customer setup feature
        /// </summary>
        public const string AppConfig = "AppConfig";
    }
}
