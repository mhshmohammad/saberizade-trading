using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ST.Authorization.Users;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.ProductCategories
{
    /// <summary>
    /// ذخیر ه اطلاعات دسته بندی محصولات
    /// </summary>
    [Table("ProductCategory", Schema ="bse")]
    public class ProductCategory : Entity , IAudited
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



        public long? CreatorUserId { get; set; }

        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }  

        public DateTime CreationTime { get; set; }


        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
