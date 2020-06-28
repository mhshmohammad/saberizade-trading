using ST.PublicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Certificates.Dtos
{
    public class GetAllDataOutput
    {
        public PagingOutput PO { get; set; }  
        public List<CertificateDto> Data{ get; set; }  
    }


    public class CertificateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Description { get; set; }
        public string EnDescription { get; set; }
        public string Labels { get; set; }
        public string CreationTime { get; set; }




    }
}
