using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ST.Authorization
{
    public class STAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Blog, L("Blog"));
            context.CreatePermission(PermissionNames.Pages_ContactUs, L("ContactUs"));
            context.CreatePermission(PermissionNames.Pages_ProductCategory, L("ProductCategory"));
            context.CreatePermission(PermissionNames.Pages_Product, L("Product"));
            context.CreatePermission(PermissionNames.Pages_Certificate, L("Certificate"));

            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, STConsts.LocalizationSourceName);
        }
    }
}
