using Abp.Application.Services;
using ST.Products.Dtos;
using System.Threading.Tasks;

namespace ST.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<GetProductOutput> GetProductAsync(GetProductInput input);
        Task<DeleteProductOutput> DeleteProductAsync(DeleteProductInput input);
        Task<UpsertProductOutput> UpsertProductAsync(UpsertProductInput input);  
        Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input);
    }
}
