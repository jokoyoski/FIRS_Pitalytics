using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Core;
using Pitalytics.Repositories.Factories;
using Pitalytics.Interfaces;
using Pitalytics.Domain.Factories;
//using Pitalytic.Domain.Factories;

namespace Pitalytics.DI.Windsor.Installers
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                 Component.For(typeof(IDbContextFactory))
                     .ImplementedBy(typeof(DbContextFactory))
                     .Named("DbContextFactory")
                     .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
               Component.For(typeof(IGeneralFactory))
                   .ImplementedBy(typeof(GeneralFactory))
                   .Named("GeneralFactory")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
               Component.For(typeof(IAccountViewsModelFactory))
                   .ImplementedBy(typeof(AccountViewsModelFactory))
                   .Named("AccountViewsModelFactory")
                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IEmailFactory))
                  .ImplementedBy(typeof(EmailFactory))
                  .Named("EmailFactory")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IAgentOfDeductionFactory))
                  .ImplementedBy(typeof(AgentOfDeductionFactory))
                  .Named("AgentOfDeductionFactory")
                  .LifeStyle.Is(LifestyleType.PerWebRequest));
        }
    }
}
