using Abp.Localization;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using NSubstitute;

namespace ST.Tests
{
    [DependsOn(
        typeof(STApplicationModule),
        typeof(STDataModule),
        typeof(AbpTestBaseModule))]
    public class STTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Registering fake services

            IocManager.IocContainer.Register(
                Component.For<IAbpZeroDbMigrator>()
                    .UsingFactoryMethod(() => Substitute.For<IAbpZeroDbMigrator>())
                    .LifestyleSingleton()
                );

            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags gb"));
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "Persian", "famfamfam-flags fa", true));
        }
    }
}
