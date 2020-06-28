using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.DomainServices
{
    public interface IFileDomainService:IDomainService
    {
        void Upload(string Path,string FileName,string Based64BinaryString);
        void Delete(string Path, string FileName);
    }
}
