using ST.PublicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.ContactUses.Dto
{
    public class GetAllDataOutput
    {
        public PagingOutput PO { get; set; }  
        public List<ContactUsDto> Data{ get; set; }  
    }
}
