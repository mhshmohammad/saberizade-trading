using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ST.MultiTenancy.Dto;

namespace ST.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
