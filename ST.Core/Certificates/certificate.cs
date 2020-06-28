using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ST.Authorization.Users;
using ST.ProductCategories;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Certificates
{
    /// <summary>
    /// ذخیر ه اطلاعات گواهینامه ها
    /// </summary>
    [Table("Certificate", Schema ="bse")]
    public class Certificate : Entity, IAudited
    {
        /// <summary>
        /// نام
        /// </summary>
        [Description("نام"),MaxLength(200), Required]
        public string Name { get; set; }    
        
        /// <summary>
        /// Name
        /// </summary>
        [Description("Name"), MaxLength(100)]
        public string EnName { get; set; }


        /// <summary>
        /// توضیحات
        /// </summary>
        [Description("توضیحات"),MaxLength(2000),Required]
        public string Description{ get; set; }

         /// <summary>
        /// Description
        /// </summary>
        [Description("Description"), MaxLength(2000)]
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
