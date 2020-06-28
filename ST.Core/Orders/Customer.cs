using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST.ProductCategories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace ST.Orders
{

    /// <summary>
    /// ذخیر ه اطلاعات خریدار
    /// </summary>
    [Table("Customer", Schema = "bse")]
    public class Customer:Entity
    {

        /// <summary>
        /// نام
        /// </summary>
        [Description("نام"), MaxLength(100), Required]
        public string Name { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [Description("نام خانوادگی"), MaxLength(200), Required]
        public string Family { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        [Description("کد ملی"), MaxLength(10)]
        public string CodeMeli { get; set; }

        /// <summary>
        /// کد پستی
        /// </summary>
        [Description("کد پستی"), MaxLength(10)]
        public string PostalCode { get; set; }
        /// <summary>
        /// کد پیگیری
        /// </summary>
        [Description("کد پیگیری"), MaxLength(50)]
        public string CodePeygiri { get; set; }
        /// <summary>
        /// موبایل
        /// </summary>
        [Description("موبایل"), MaxLength(12), Required]
        public string Mobile { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        [Description("آدرس"), MaxLength(50), Required]
        public string Address { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        [Description("وضعیت")]
        public OrderStatus Status { get; set; }
    }
}
