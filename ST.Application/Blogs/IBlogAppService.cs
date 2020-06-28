using Abp.Application.Services;
using ST.Blogs.Dtos;
using System.Threading.Tasks;

namespace ST.Blogs
{
    public interface IBlogAppService : IApplicationService
    {
        Task<GetBlogOutput> GetBlogAsync(GetBlogInput input);
        Task<DeleteBlogOutput> DeleteBlogAsync(DeleteBlogInput input);
        Task<UpsertBlogOutput> UpsertBlogAsync(UpsertBlogInput input);  
        Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input);
    }
}
