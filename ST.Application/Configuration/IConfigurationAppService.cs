using System.Threading.Tasks;
using Abp.Application.Services;
using ST.Configuration.Dto;

namespace ST.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}