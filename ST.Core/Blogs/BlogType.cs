using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Blogs
{
    public enum BlogType
    {
        [Display(Name = "اطلاعیه")]
        etlaei =1,
        [Display(Name = "مقاله")]
        maghale =2
    }
}
