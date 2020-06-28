using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Microsoft.AspNet.Identity;
using ST.Authorization;
using ST.Authorization.Roles;
using ST.Authorization.Users;
using ST.ContactUses;
using ST.ContactUses.Dto;
using ST.PublicDtos;
using System.Linq;

using System.Threading.Tasks;

namespace ST.ContactUses
{
    [AbpAuthorize(PermissionNames.Pages_ContactUs)]
    public class ContactUsAppService : IContactUsAppService
    {
        private readonly IRepository<ContactUs> _contactUsRepo;

        public ContactUsAppService(IRepository<ContactUs> contactUsRepo)
        {
            _contactUsRepo = contactUsRepo;
        }


        [AbpAuthorize]
        public async Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input)
        {
            var res = new GetAllDataOutput();


            var v =  _contactUsRepo.GetAll().Select(p => p);

            int count = v.Count();

            if (input.SearchTerm.IsNullOrEmpty()==false)
            {
                v = v.Where(p => p.Name.Contains(input.SearchTerm));
            }

            int resultCount = v.Count();

            v = v.Skip(input.PI.PageNumber * 10).Take(10);

            var d = v.ToList();


            res.Data = d.Select(p => new ContactUsDto()
            {
                Description = p.Description,
                Email = p.Email,
                Family = p.Family,
                Id = p.Id,
                IsSeen = p.IsSeen,
                Name = p.Name,
                Subject = p.Subject,
                Type = p.Type,
            }).ToList();


            res.PO = new PagingOutput()
            {
                CurrentPage=input.PI.PageNumber,
                PageSize=10,
                ResultCount= resultCount,
                TotalCount= count
            };


            return res;
        }

    }
}