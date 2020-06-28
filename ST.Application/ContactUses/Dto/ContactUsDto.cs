using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.ContactUses.Dto
{
    [AutoMapTo(typeof(ContactUs)), AutoMapFrom(typeof(ContactUs))]
    public class ContactUsDto : EntityDto<int>
    {
        /// <summary>
        /// نام
        /// </summary>
        [Display(Name ="نام"), MaxLength(100), Required]
        public string Name { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [Display(Name ="نام خانوادگی"), MaxLength(100), Required]
        public string Family { get; set; }


        /// <summary>
        /// ایمیل
        /// </summary>
        [Display(Name ="ایمیل"), MaxLength(100), Required]
        public string Email { get; set; }


        /// <summary>
        /// موضوع
        /// </summary>
        [Display(Name ="موضوع"), MaxLength(200), Required]
        public string Subject { get; set; }

        /// <summary>
        /// متن پیام
        /// </summary>
        [Display(Name ="متن پیام"), MaxLength(1000), Required]
        public string Description { get; set; }

        /// <summary>
        /// دسته بندی ارتباط با ما
        /// </summary>
        [Display(Name ="دسته بندی ارتباط با ما"), Required]
        public CUType Type { get; set; }

        /// <summary>
        /// وضعیت مشاهده
        /// </summary>
        [Display(Name ="وضعیت مشاهده")]
        public bool IsSeen { get; set; }
    }
}
