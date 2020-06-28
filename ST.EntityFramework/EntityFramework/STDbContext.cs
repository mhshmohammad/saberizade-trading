using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityParameters;
using Abp.Zero.EntityFramework;
using ST.Authorization.Roles;
using ST.Authorization.Users;
using ST.Blogs;
using ST.Certificates;
using ST.ContactUses;
using ST.MultiTenancy;
using ST.ProductCategories;
using ST.Products;

namespace ST.EntityFramework
{
    public class STDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual IDbSet<ContactUs> ContactUses { get; set; }

        public virtual IDbSet<Blog> Blogs { get; set; }

        public virtual IDbSet<Certificate> Certificates { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<ProductCategory> ProductCategories { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public STDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in STDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of STDbContext since ABP automatically handles it.
         */
        public STDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public STDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public STDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicParameter>().Property(p => p.ParameterName).HasMaxLength(250);
            modelBuilder.Entity<EntityDynamicParameter>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
