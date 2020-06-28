using System.Threading.Tasks;
using Abp.Application.Services;
using ST.Sessions.Dto;

namespace ST.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
