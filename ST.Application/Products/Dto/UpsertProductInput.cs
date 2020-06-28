using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Products.Dtos
{
    public class UpsertProductInput
    {   
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [ MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [ MaxLength(1000)]
        public string Description { get; set; }


        /// <summary>
        /// نام
        /// </summary>
        [MaxLength(100)]
        public string EnName { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(1000)]
        public string EnDescription { get; set; }


        /// <summary>
        /// هزینه ارسال در محدوه
        /// </summary>       
        public decimal SendPriceInRage { get; set; }
        /// <summary>
        /// هزینه ارسال در خارج محدوه
        /// </summary>
        public decimal SendPriceOutRage { get; set; }
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


        public string Based64BinaryString { get; set; }

    }
}
