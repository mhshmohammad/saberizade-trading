using ST.PublicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Products.Dtos
{
    public class GetAllDataOutput
    {
        public PagingOutput PO { get; set; }  
        public List<ProductDto> Data{ get; set; }  
    }


    public class ProductDto
    {
        public int Id { get; set; }  
        public string Name { get; set; }

      
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description{ get; set; }

        public string EnName { get; set; }


        /// <summary>
        /// توضیحات
        /// </summary>
        public string EnDescription { get; set; }


        /// <summary>
        /// هزینه ارسال در محدوه
        /// </summary>
        public decimal SendPriceInRange{ get; set; }
        /// <summary>
        /// هزینه ارسال در خارج محدوه
        /// </summary>
        public decimal SendPriceOutRange{ get; set; }
        /// <summary>
        /// دسته بندی 
        /// </summary>
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// تعداد موجودی
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// وزن
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// واحد وزن
        /// </summary>
        public WeightUnit Unit { get; set; }

        /// <summary>
        /// برچسب ها
        /// </summary>
        public string Labels { get; set; }

        public string   CreationTime{ get; set; }  



    }
}
