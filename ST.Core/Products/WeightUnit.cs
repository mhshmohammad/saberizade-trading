using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Products
{
    public enum WeightUnit
    {
        [Display(Name ="گرم")]
        gram=1,
        [Display(Name = "کیلو گرم")]
        Kilo =2,
        [Display(Name = "مثقال")]
        Mesghal =3,
        [Display(Name = "لیتر")]  
        litr =4
    }
}
