using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ST.ContactUses.Dto;
using ST.Roles.Dto;
using System.Threading.Tasks;

namespace ST.ContactUses
{
    public interface IContactUsAppService : IApplicationService
    {
        Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input);
    }
}
