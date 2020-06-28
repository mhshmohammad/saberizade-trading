using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ST.Authorization.Users;
using ST.ProductCategories;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Products
{
    /// <summary>
    /// ذخیر ه اطلاعات محصولات
    /// </summary>
    [Table("Product", Schema ="bse")]
    public class Product : Entity,ISoftDelete,IAudited
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("نام"),MaxLength(100), Required]
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Description("Name"), MaxLength(100)]
        public string EnName { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [Description("توضیحات"),MaxLength(1000),Required]
        public string Description{ get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Description("Description"), MaxLength(1000)]
        public string EnDescription { get; set; }


        /// <summary>
        /// هزینه ارسال در محدوه
        /// </summary>
        [Description("هزینه ارسال در محدوه") ]
        public decimal SendPriceInRange{ get; set; }
        /// <summary>
        /// هزینه ارسال در خارج محدوه
        /// </summary>
        [Description("هزینه ارسال در خارج محدوه") ]
        public decimal SendPriceOutRange{ get; set; }
        /// <summary>
        /// دسته بندی 
        /// </summary>
        [Description("دسته بندی"),Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory{ get; set; }
        /// <summary>
        /// تعداد موجودی
        /// </summary>
        [Description("تعداد موجودی")]
        public int Count { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        [Description("قیمت")]
        public decimal Price { get; set; }

        /// <summary>
        /// وزن
        /// </summary>
        [Description("وزن")]
        public decimal Weight { get; set; }

        /// <summary>
        /// واحد وزن
        /// </summary>
        [Description("واحد وزن")]
        public WeightUnit Unit { get; set; }

        /// <summary>
        /// برچسب ها
        /// </summary>
        [Description("برچسب ها")]
        public string Labels { get; set; }

        public bool IsDeleted { get; set; }
        public long? CreatorUserId { get; set; }

        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }  

        public DateTime CreationTime { get; set; }

        public  DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
