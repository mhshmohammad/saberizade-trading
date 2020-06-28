using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Blogs.Dtos
{
    public class UpsertBlogInput
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string EnTitle { get; set; }


        [MaxLength(2000)]
        public string Description { get; set; }

        [MaxLength(2000)]
        public string EnDescription { get; set; }


        public string Labels { get; set; }

        public string CreationTime { get; set; }

        public string Based64BinaryString { get; set; }
    }
}
