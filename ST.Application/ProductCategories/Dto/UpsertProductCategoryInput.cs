using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.ProductCategories.Dtos
{
    public class UpsertProductCategoryInput
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }

        [MaxLength(100)]
        public string EnName { get; set; }

        [MaxLength(1000)]
        public string EnDesc { get; set; }
    }
}
