using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ST.Authorization.Users;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.ContactUses
{
    /// <summary>
    /// ذخیر ه اطلاعات ارتباط با ما
    /// </summary>
    [Table("ContactUs",Schema ="bse")]
    public class ContactUs: Entity, IAudited
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("نام"),MaxLength(100), Required]
        public string Name { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [Description("نام خانوادگی"), MaxLength(100), Required]
        public string Family { get; set; }


        /// <summary>
        /// ایمیل
        /// </summary>
        [Description("ایمیل"), MaxLength(100),Required]
        public string Email { get; set; }


        /// <summary>
        /// موضوع
        /// </summary>
        [Description("موضوع"), MaxLength(200), Required]
        public string Subject { get; set; }

        /// <summary>
        /// متن پیام
        /// </summary>
        [Description("متن پیام"),MaxLength(1000),Required]
        public string Description{ get; set; }
        
        /// <summary>
        /// دسته بندی ارتباط با ما
        /// </summary>
        [Description("دسته بندی ارتباط با ما"),Required]
        public CUType Type { get; set; }

        /// <summary>
        /// وضعیت مشاهده
        /// </summary>
        [Description("وضعیت مشاهده")]
        public bool IsSeen { get; set; }

        public long? CreatorUserId { get; set; }

        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }  

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
