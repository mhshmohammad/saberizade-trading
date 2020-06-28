using ST.PublicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Blogs.Dtos
{
    public class GetAllDataInput
    {
        public PagingInfo PI { get; set; }

        public string SearchTerm { get; set; }  
    }
}
