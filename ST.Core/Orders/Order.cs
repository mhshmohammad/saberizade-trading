using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ST.Authorization.Users;
using ST.Orders;
using ST.ProductCategories;
using ST.Products;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Orders
{
    /// <summary>
    /// ذخیر ه اطلاعات خرید
    /// </summary>
    [Table("Order", Schema ="bse")]
    public class Order : Entity, IAudited
    {
        /// <summary>
        ///شماره خریدار
        /// </summary>
        [Description("شماره خریدار")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer{ get; set; }
        /// <summary>
        ///شماره کالا
        /// </summary>
        [Description("شماره کالا")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product{ get; set; }
        /// <summary>
        /// تعداد 
        /// </summary>
        [Description("تعداد ")]
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

        public DateTime CreationTime { get; set; }


        public long? CreatorUserId { get; set; }

        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
