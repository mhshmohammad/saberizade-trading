using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ST.Authorization.Users;
using ST.Blogs;
using ST.ProductCategories;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Blogs
{
    /// <summary>
    /// ذخیر ه اطلاعات مقالات و اطلاعیه ها
    /// </summary>
    [Table("Blog", Schema ="bse")]
    public class Blog : Entity, IAudited
    {
        /// <summary>
        /// عنوان
        /// </summary>
        [Description("عنوان"),MaxLength(200), Required]
        public string Title { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [Description("عنوان"), MaxLength(200), Required]
        public string EnTitle { get; set; }



        /// <summary>
        /// توضیحات
        /// </summary>
        [Description("توضیحات"),MaxLength(2000),Required]
        public string Description{ get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [Description("عنوان"), MaxLength(20000), Required]
        public string EnDescription { get; set; }  

        /// <summary>
        /// برچسب ها
        /// </summary>
        [Description("برچسب ها")]
        public string Labels { get; set; }


        public long? CreatorUserId { get; set; }

        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }  

        public DateTime CreationTime { get; set; }


        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
