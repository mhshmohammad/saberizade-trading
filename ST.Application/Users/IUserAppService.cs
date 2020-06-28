using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ST.Roles.Dto;
using ST.Users.Dto;

namespace ST.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}