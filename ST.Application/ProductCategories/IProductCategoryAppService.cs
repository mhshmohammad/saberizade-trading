using Abp.Application.Services;
using ST.ProductCategories.Dtos;
using System.Threading.Tasks;

namespace ST.ProductCategories
{
    public interface IProductCategoryAppService : IApplicationService
    {
        Task<GetProductCategoryOutput> GetProductCategoryAsync(GetProductCategoryInput input);
        Task<DeleteProductCategoryOutput> DeleteProductCategoryAsync(DeleteProductCategoryInput input);
        Task<UpsertProductCategoryOutput> UpsertProductCategoryAsync(UpsertProductCategoryInput input);  
        Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input);
    }
}
