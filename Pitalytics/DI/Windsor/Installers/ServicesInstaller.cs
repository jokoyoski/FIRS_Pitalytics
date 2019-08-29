using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Providers;
using AA.Infrastructure.Services;
using AA.Infrastructure.Utility;
using Pitalytics.Interfaces;
using Pitalytics.Domain.Services;

//using Pitalytic.Domain.Services;

namespace Pitalytics.DI.Windsor.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
               Component.For(typeof(ISessionStateProvider))
                   .ImplementedBy(typeof(SessionStateProvider))
                   .Named("SessionStateProvider")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
                Component.For(typeof(IEnvironment))
                    .ImplementedBy(typeof(Environment))
                    .Named("Environment")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISessionStateService))
                    .ImplementedBy(typeof(SessionStateService))
                    .Named("SessionStateService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
                Component.For(typeof(IAesEncryption))
                    .ImplementedBy(typeof(AesEncryption))
                    .Named("AesEncryption")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
                Component.For(typeof(IFormsAuthenticationService))
                    .ImplementedBy(typeof(FormsAuthenticationService))
                    .Named("FormsAuthenticationService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmail))
                    .ImplementedBy(typeof(Email))
                    .Named("Email")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            container.Register(
               Component.For(typeof(ILookupService))
                   .ImplementedBy(typeof(LookupServices))
                   .Named("LookupServices")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
               Component.For(typeof(IGeneralService))
                   .ImplementedBy(typeof(GeneralService))
                   .Named("GeneralServices")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
               Component.For(typeof(IAccountService))
                   .ImplementedBy(typeof(AccountService))
                   .Named("AccountServices")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
               Component.For(typeof(IAgentOfDeductionService))
                   .ImplementedBy(typeof(AgentOfDeductionService))
                   .Named("AgentOfDeductionService")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
             Component.For(typeof(IGenerateDocumentService))
                 .ImplementedBy(typeof(GenerateDocumentService))
                 .Named("GenerateDocumentService")
                 .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
            Component.For(typeof(IDigitalFileServices))
                .ImplementedBy(typeof(DigitalServices))
                .Named("DigitalServices")
                .LifeStyle.Is(LifestyleType.PerWebRequest));


        }
    }
}