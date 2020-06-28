using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ST.Authorization;
using ST.Blogs.Dtos;
using ST.DomainServices;
using ST.PublicDtos;
using System.Linq;


using System.Threading.Tasks;

namespace ST.Blogs
{
    [AbpAuthorize(PermissionNames.Pages_Blog)]
    public class BlogAppService : IBlogAppService
    {
        private readonly IRepository<Blog> _blogRepo;
        private readonly IFileDomainService _fileDomainService;

        public BlogAppService(IRepository<Blog> blogRepo
            , IFileDomainService fileDomainService)
        {
            _fileDomainService = fileDomainService;
            _blogRepo = blogRepo;
        }


        [AbpAuthorize]
        public async Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input)
        {
            var res = new GetAllDataOutput();


            var v = _blogRepo.GetAll().Select(p => p);

            int count = v.Count();

            if (input.SearchTerm.IsNullOrEmpty() == false)
            {
                v = v.Where(p => p.Title.Contains(input.SearchTerm));
            }

            int resultCount = v.Count();

            v = v.Skip(input.PI.PageNumber * 10).Take(10);

            var d = v.ToList();


            res.Data = d.Select(p => new BlogDto()
            {
                Title = p.Title,
                Id = p.Id,
                CreationTime = p.CreationTime.ToString(),
                Description = p.Description,
                EnDescription = p.EnDescription,
                EnTitle = p.EnTitle,
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
        public async Task<UpsertBlogOutput> UpsertBlogAsync(UpsertBlogInput input)
        {

            #region Validation

            if (input.Title.IsNullOrEmpty())
            {
                throw new UserFriendlyException("لطفا نام دسته بندی را وارد نمائید !!!");
            }

            #endregion

            var pc = new Blog();

            int? blogId = null;

            if (input.Id == 0)
            {
                if (_blogRepo.GetAll().Any(p => p.Title == input.Title || p.EnTitle == input.EnTitle))
                {
                    throw new UserFriendlyException("این دسته بندی در سیستم موجود می باشد !!!!");
                }

                pc.Title = input.Title;
                pc.Description = input.Description;


                blogId = _blogRepo.InsertAndGetId(pc);
            }
            else
            {
                pc = _blogRepo.GetAll()
                    .SingleOrDefault(p => p.Id == input.Id);

                if (pc == null)
                {
                    throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
                }

                blogId = pc.Id;

                _fileDomainService.Delete(SystemConsts.DefaultPathBlog, blogId + ".jpg");


                pc.Title = input.Title;
                pc.Description = input.Description;
            }
            _fileDomainService.Upload(SystemConsts.DefaultPathBlog, blogId + ".jpg", input.Based64BinaryString);

            pc.Labels = input.Labels;
            pc.EnDescription = input.EnDescription;
            pc.EnTitle = input.EnTitle;


            return new UpsertBlogOutput();

        }

        /// <summary>
        /// برای حذف
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<DeleteBlogOutput> DeleteBlogAsync(DeleteBlogInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _blogRepo.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }


            _blogRepo.Delete(pc);

            return new DeleteBlogOutput();
        }



        /// <summary>
        /// برای ویرایش
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<GetBlogOutput> GetBlogAsync(GetBlogInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _blogRepo.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }

            return new GetBlogOutput()
            {
                PC = new BlogDto()
                {
                    Title = pc.Title,
                    Id = pc.Id,
                    CreationTime = pc.CreationTime.ToString(),
                    Description = pc.Description,
                    EnDescription = pc.EnDescription,
                    EnTitle = pc.EnTitle,
                    Labels = pc.Labels
                }
            };

        }

    }
}