using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.PublicDtos
{
    public class PagingOutput
    {
        public int TotalCount { get; set; }

        public int ResultCount { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }  
    }
}
