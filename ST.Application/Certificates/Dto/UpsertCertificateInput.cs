using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Certificates.Dtos
{
    public class UpsertCertificateInput
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string EnName { get; set; }


        [MaxLength(2000)]
        public string Description { get; set; }

        [MaxLength(2000)]
        public string EnDescription { get; set; }


        public string Labels { get; set; }

        public string CreationTime { get; set; }
        public string Based64BinaryString { get; set; }
    }
}
