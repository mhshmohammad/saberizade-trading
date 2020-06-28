using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using ST.EntityFramework;

namespace ST.Migrator
{
    [DependsOn(typeof(STDataModule))]
    public class STMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<STDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}