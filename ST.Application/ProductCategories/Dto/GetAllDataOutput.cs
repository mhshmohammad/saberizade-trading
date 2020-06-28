using ST.PublicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.ProductCategories.Dtos
{
    public class GetAllDataOutput
    {
        public PagingOutput PO { get; set; }  
        public List<ProductCategoryDto> Data{ get; set; }  
    }


    public class ProductCategoryDto
    {
        public int Id { get; set; }  
        public string Name { get; set; }

        public string Desc { get; set; }

        public string EnName { get; set; }

        public string EnDesc { get; set; }

        public string   CreationTime{ get; set; }  



    }
}
