using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ST.Authorization;
using ST.Certificates.Dtos;
using ST.DomainServices;
using ST.PublicDtos;
using System;
using System.IO;
using System.Linq;


using System.Threading.Tasks;

namespace ST.Certificates
{
    [AbpAuthorize(PermissionNames.Pages_Certificate)]
    public class CertificateAppService : ICertificateAppService
    {
        private readonly IRepository<Certificate> _CertificateRepo;
        private readonly IFileDomainService _fileDomainService;

        public CertificateAppService(IRepository<Certificate> CertificateRepo
            , IFileDomainService fileDomainService)
        {
            _fileDomainService = fileDomainService;
            _CertificateRepo = CertificateRepo;
        }


        [AbpAuthorize]
        public async Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input)
        {
            var res = new GetAllDataOutput();


            var v = _CertificateRepo.GetAll().Select(p => p);

            int count = v.Count();

            if (input.SearchTerm.IsNullOrEmpty() == false)
            {
                v = v.Where(p => p.Name.Contains(input.SearchTerm) || p.EnName.Contains(input.SearchTerm));
            }

            int resultCount = v.Count();

            v = v.Skip(input.PI.PageNumber * 10).Take(10);

            var d = v.ToList();


            res.Data = d.Select(p => new CertificateDto()
            {
                Name = p.Name,
                Id = p.Id,
                CreationTime = p.CreationTime.ToString(),
                Description = p.Description,
                EnDescription = p.EnDescription,
                EnName = p.EnName,
                Labels = p.Labels
            }).ToList();


            res.PO = new PagingOutput()
            {
                CurrentPage = input.PI.PageNumber,
                PageSize = 10,
                ResultCount = resultCount,
                TotalCount = count
            };


            return res;
        }

        [AbpAuthorize]
        public async Task<UpsertCertificateOutput> UpsertCertificateAsync(UpsertCertificateInput input)
        {

            #region Validation

            if (input.Name.IsNullOrEmpty())
            {
                throw new UserFriendlyException("لطفا نام  را وارد نمائید !!!");
            }

            #endregion

            var pc = new Certificate();

            int cerId = 0;

            if (input.Id == 0)
            {
                if (_CertificateRepo.GetAll().Any(p => p.Name == input.Name || p.EnName == input.EnName))
                {
                    throw new UserFriendlyException("این موضوع در سیستم موجود می باشد !!!!");
                }

                pc.Name = input.Name;
                pc.Description = input.Description;


                cerId = _CertificateRepo.InsertAndGetId(pc);


            }
            else
            {
                pc = _CertificateRepo.GetAll()
                    .SingleOrDefault(p => p.Id == input.Id);

                if (pc == null)
                {
                    throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
                }

                cerId = pc.Id;
                _fileDomainService.Delete(SystemConsts.DefaultPathCertificate, cerId + ".jpg");

                pc.Name = input.Name;
                pc.Description = input.Description;
            }

            _fileDomainService.Upload(SystemConsts.DefaultPathCertificate, cerId + ".jpg", input.Based64BinaryString);
            pc.Labels = input.Labels;
            pc.EnDescription = input.EnDescription;
            pc.EnName = input.EnName;


            return new UpsertCertificateOutput();

        }

        /// <summary>
        /// برای حذف
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<DeleteCertificateOutput> DeleteCertificateAsync(DeleteCertificateInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _CertificateRepo.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }


            _CertificateRepo.Delete(pc);

            return new DeleteCertificateOutput();
        }



        /// <summary>
        /// برای ویرایش
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<GetCertificateOutput> GetCertificateAsync(GetCertificateInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _CertificateRepo.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }

            return new GetCertificateOutput()
            {
                PC = new CertificateDto()
                {
                    Name = pc.Name,
                    EnName = pc.EnName,
                    Id = pc.Id,
                    CreationTime = pc.CreationTime.ToString(),
                    Description = pc.Description,
                    EnDescription = pc.EnDescription,
                    Labels = pc.Labels
                }
            };

        }

    }
}