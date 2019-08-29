using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pitalytics.Interfaces;
using Pitalytics.Repositories.Services;

namespace Pitalytics.DI.Windsor.Installers
{
    /// <summary>
    /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
    /// </summary>
    /// <param name="container">The container.</param>
    /// <param name="store">The configuration store.</param>
    public class RepositoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IGeneralRepository))
                    .ImplementedBy(typeof(GeneralRepository))
                    .Named("GeneralRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ILookupRepository))
                    .ImplementedBy(typeof(LookupRepository))
                    .Named("LookupRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAccountRepository))
                    .ImplementedBy(typeof(AccountRepository))
                    .Named("AccountRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAgentOfDeductionRepository))
                    .ImplementedBy(typeof(AgentOfDeductionRepository))
                    .Named("AgentOfDeductionRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IDigitalFileRepository))
                    .ImplementedBy(typeof(DigitalFileRepository))
                    .Named("DigitalFileRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

        }
    }
}