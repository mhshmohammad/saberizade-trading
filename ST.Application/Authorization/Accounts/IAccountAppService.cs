using System.Threading.Tasks;
using Abp.Application.Services;
using ST.Authorization.Accounts.Dto;

namespace ST.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
