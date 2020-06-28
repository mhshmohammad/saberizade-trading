using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.ContactUses
{
    public enum CUType
    {
        [Display(Name ="انتقادات")]
        Enteghad=1,

        [Display(Name = "پیشنهادات")]
        Pishnahad = 2,

        [Display(Name = "شکایات")]
        Shekayat = 3,

    }
}
