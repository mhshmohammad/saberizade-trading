using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ST.Authorization;
using ST.ProductCategories.Dtos;
using ST.Products;
using ST.PublicDtos;
using System.Linq;


using System.Threading.Tasks;

namespace ST.ProductCategories
{
    [AbpAuthorize(PermissionNames.Pages_ProductCategory)]
    public class ProductCategoryAppService : IProductCategoryAppService
    {
        private readonly IRepository<ProductCategory> _productCategory;
        private readonly IRepository<Product> _productRepo;

        public ProductCategoryAppService(IRepository<ProductCategory> productCategory,
            IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
            _productCategory = productCategory;
        }


        [AbpAuthorize]
        public async Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input)
        {
            var res = new GetAllDataOutput();


            var v = _productCategory.GetAll().Select(p => p);

            int count = v.Count();

            if (input.SearchTerm.IsNullOrEmpty() == false)
            {
                v = v.Where(p => p.Name.Contains(input.SearchTerm));
            }

            int resultCount = v.Count();

            v = v.Skip(input.PI.PageNumber * 10).Take(10);

            var d = v.ToList();


            res.Data = d.Select(p => new ProductCategoryDto()
            {
                Id = p.Id,
                CreationTime = p.CreationTime.ToString(),
                Desc = p.Description,
                Name = p.Name,
                EnDesc = p.EnDescription,
                EnName = p.EnName
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
        public async Task<UpsertProductCategoryOutput> UpsertProductCategoryAsync(UpsertProductCategoryInput input)
        {

            #region Validation

            if (input.Name.IsNullOrEmpty())
            {
                throw new UserFriendlyException("لطفا نام دسته بندی را وارد نمائید !!!");
            }

            #endregion

            var pc = new ProductCategory();

            if (input.Id == 0)
            {
                if (_productCategory.GetAll().Any(p => p.Name == input.Name || p.EnName == input.EnName))
                {
                    throw new UserFriendlyException("این دسته بندی در سیستم موجود می باشد !!!!");
                }

                pc.Name = input.Name;
                pc.Description = input.Desc;
                _productCategory.Insert(pc);
            }
            else
            {
                pc = _productCategory.GetAll()
                    .SingleOrDefault(p => p.Id == input.Id);

                if (pc == null)
                {
                    throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
                }

                pc.Name = input.Name;
                pc.Description = input.Desc;
            }

            pc.EnName = input.EnName;
            pc.EnDescription = input.EnDesc;


            return new UpsertProductCategoryOutput();

        }

        /// <summary>
        /// برای حذف
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<DeleteProductCategoryOutput> DeleteProductCategoryAsync(DeleteProductCategoryInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _productCategory.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }

            if (_productRepo.GetAll().Any(p => p.ProductCategoryId == input.Id))
            {
                throw new UserFriendlyException("برای این دسته بندی محصولی درج گردیده است !!!");
            }


            _productCategory.Delete(pc);

            return new DeleteProductCategoryOutput();
        }



        /// <summary>
        /// برای ویرایش
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<GetProductCategoryOutput> GetProductCategoryAsync(GetProductCategoryInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _productCategory.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }

            return new GetProductCategoryOutput()
            {
                PC = new ProductCategoryDto()
                {
                    Id = pc.Id,
                    CreationTime = pc.CreationTime.ToString(),
                    Desc = pc.Description,
                    Name = pc.Name,
                    EnDesc=pc.EnDescription,
                    EnName=pc.EnName                    
                }
            };

        }

    }
}