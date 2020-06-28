using ST.PublicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Blogs.Dtos
{
    public class GetAllDataOutput
    {
        public PagingOutput PO { get; set; }  
        public List<BlogDto> Data{ get; set; }  
    }


    public class BlogDto
    {

        public int Id { get; set; }  
        public string Title { get; set; }

        
        public string EnTitle { get; set; }



        public string Description { get; set; }

       
        public string EnDescription { get; set; }

     
        public string Labels { get; set; }

        public string CreationTime { get; set; }   

    }
}
