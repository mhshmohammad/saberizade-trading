using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ST.Authorization;
using ST.Products;
using ST.Products.Dtos;
using ST.PublicDtos;
using System.Linq;
using ST.Orders;


using System.Threading.Tasks;
using ST.DomainServices;

namespace ST.Products
{
    [AbpAuthorize(PermissionNames.Pages_ProductCategory)]
    public class ProductAppService : IProductAppService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Order> _ordersRepo;
        private readonly IFileDomainService _fileDomainService;

        public ProductAppService(IRepository<Product> productRepo,
            IFileDomainService fileDomainService)
        {
            _fileDomainService = fileDomainService;
            _productRepo = productRepo;
        }


        [AbpAuthorize]
        public async Task<GetAllDataOutput> GetAllDataAsync(GetAllDataInput input)
        {
            var res = new GetAllDataOutput();


            var v = _productRepo.GetAll().Select(p => p);

            int count = v.Count();

            if (input.SearchTerm.IsNullOrEmpty() == false)
            {
                v = v.Where(p => p.Name.Contains(input.SearchTerm));
            }

            int resultCount = v.Count();

            v = v.Skip(input.PI.PageNumber * 10).Take(10);

            var d = v.ToList();


            res.Data = d.Select(p => new ProductDto()
            {
                Id = p.Id,
                CreationTime = p.CreationTime.ToString(),
                Description = p.Description,
                Name = p.Name,
                EnDescription = p.EnDescription,
                EnName = p.EnName,
                SendPriceInRange = p.SendPriceInRange,
                SendPriceOutRange = p.SendPriceOutRange,
                Count = p.Count,
                Labels = p.Labels,
                Price = p.Price,
                ProductCategoryId = p.ProductCategoryId,
                Unit = p.Unit,
                Weight = p.Weight
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
        public async Task<UpsertProductOutput> UpsertProductAsync(UpsertProductInput input)
        {

            #region Validation

            if (input.Name.IsNullOrEmpty())
            {
                throw new UserFriendlyException("لطفا نام کالا را وارد نمائید !!!");
            }
            if (input.ProductCategoryId == 0)
            {
                throw new UserFriendlyException("لطفا دسته بندی را وارد نمائید !!!");
            }

            if (input.Price == 0)
            {
                throw new UserFriendlyException("لطفا قیمت را وارد نمائید !!!");
            }
            if (input.Count == 0)
            {
                throw new UserFriendlyException("لطفا تعداد را وارد نمائید !!!");
            }
            #endregion

            var pc = new Product();

            int? productId = null;

            if (input.Id == 0)
            {
                if (_productRepo.GetAll().Any(p => p.Name == input.Name & p.ProductCategoryId == input.ProductCategoryId))
                {
                    throw new UserFriendlyException("این محصول در سیستم موجود می باشد !!!!");
                }

                pc.Name = input.Name;
                pc.Description = input.Description;
                pc.Count = input.Count;
                pc.Labels = input.Labels;
                pc.Price = input.Price;
                pc.ProductCategoryId = input.ProductCategoryId;
                pc.SendPriceInRange = input.SendPriceInRage;
                pc.SendPriceOutRange = input.SendPriceOutRage;
                pc.Weight = input.Weight;
                pc.Unit = input.Unit;

                productId=_productRepo.InsertAndGetId(pc);
            }
            else
            {
                pc = _productRepo.GetAll()
                    .SingleOrDefault(p => p.Id == input.Id);

                if (pc == null)
                {
                    throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
                }

                productId = pc.Id;
                _fileDomainService.Delete(SystemConsts.DefaultPathProduct, productId + ".jpg");

                pc.Name = input.Name;
                pc.Description = input.Description;
                pc.Count = input.Count;
                pc.Labels = input.Labels;
                pc.Price = input.Price;
                pc.ProductCategoryId = input.ProductCategoryId;
                pc.SendPriceInRange = input.SendPriceInRage;
                pc.SendPriceOutRange = input.SendPriceOutRage;
                pc.Weight = input.Weight;
                pc.Unit = input.Unit;
            }

            _fileDomainService.Upload(SystemConsts.DefaultPathProduct, productId+".jpg", input.Based64BinaryString);

            pc.EnName = input.EnName;
            pc.EnDescription = input.EnDescription;


            return new UpsertProductOutput();

        }

        /// <summary>
        /// برای حذف
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<DeleteProductOutput> DeleteProductAsync(DeleteProductInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _productRepo.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }

            //if (_productRepo.GetAll().Any(p => p.ProductCategoryId == input.Id))
            //{
            //    throw new UserFriendlyException("برای این  محصول درج گردیده است !!!");
            //}


            _productRepo.Delete(pc);

            return new DeleteProductOutput();
        }



        /// <summary>
        /// برای ویرایش
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize]
        public async Task<GetProductOutput> GetProductAsync(GetProductInput input)
        {
            if (input.Id == 0)
            {
                throw new UserFriendlyException("خطا در دریافت اطلاعات");
            }

            var pc = _productRepo.GetAll()
                               .SingleOrDefault(p => p.Id == input.Id);

            if (pc == null)
            {
                throw new UserFriendlyException("آیتم مورد نظر وجود ندارد ویا حذف شده است !!!");
            }

            return new GetProductOutput()
            {
                P = new ProductDto()
                {
                    Id = pc.Id,
                    CreationTime = pc.CreationTime.ToString(),
                    Description = pc.Description,
                    Name = pc.Name,
                    EnDescription = pc.EnDescription,
                    EnName = pc.EnName,
                }
            };

        }

    }
}