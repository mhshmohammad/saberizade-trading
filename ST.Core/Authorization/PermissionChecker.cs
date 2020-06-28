using Abp.Authorization;
using ST.Authorization.Roles;
using ST.Authorization.Users;

namespace ST.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
