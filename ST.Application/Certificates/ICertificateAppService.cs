using Abp.Application.Services;
using ST.Certificates.Dtos;
using System.Threading.Tasks;

namespace ST.Certificates
{
    public interface ICertificateAppService : IApplicationService
    {
        Task<GetCertificateOutput> GetCertificateAsync(GetCertificateInput input);
        Task<DeleteCertificateOutput> DeleteCertificateAsync(DeleteCertificateInput input);
        Task<UpsertCertificateOutput> UpsertCertificateAsync(UpsertCertificateInput input);  
        Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input);
    }
}
