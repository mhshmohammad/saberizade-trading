using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.DomainServices
{
    public class FileDomainService : DomainService, IFileDomainService
    {
        private void UploadPR(string Path, byte[] f, string fileName)
        {
            try
            {
                string pa = Path + fileName.Replace(fileName.Split('/').Last(), "");
                if (!Directory.Exists(pa))
                    Directory.CreateDirectory(pa);
            }
            catch { }


            // instance a memory stream and pass the
            // byte array to its constructor
            MemoryStream ms = new MemoryStream(f);

            // instance a filestream pointing to the
            // storage folder, use the original file name
            // to name the resulting file

            // FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/") + fileName, FileMode.Create);
            FileStream fs = new FileStream(Path + fileName, FileMode.Create);

            // write the memory stream containing the original
            // file as a byte array to the filestream

            ms.WriteTo(fs);

            // clean up

            ms.Close();
            fs.Close();
            fs.Dispose();
        }
        /// <summary>
        /// آپلود فایل 
        /// </summary>
        /// <param name="Path">مسیر</param>
        /// <param name="FileName">نام فایل با پسوند</param>
        /// <param name="Based64BinaryString"></param>
        public void Upload(string Path, string FileName, string Based64BinaryString)
        {
            if (Based64BinaryString != "")
            {
                try
                {
                    string path2 = "~/" + Path + "/";



                    string str = Based64BinaryString.Replace("data:image/jpeg;base64,", " ");//jpg check
                    str = str.Replace("data:image/png;base64,", " ");//png check


                    byte[] data = Convert.FromBase64String(str);

                    //MemoryStream ms = new MemoryStream(data, 0, data.Length);
                    //ms.Write(data, 0, data.Length);
                    //System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);

                    UploadPR(path2, data, FileName);
                }
                catch (Exception)
                {
                }






            }
        }

        /// <summary>
        /// حذف فایل
        /// </summary>
        /// <param name="Path">مسیر فایل </param>
        /// <param name="FileName">نام فایل با پسوند</param>
        public void Delete(string Path, string FileName)
        {
            try
            {

                string path = "~/" + Path + "/" + FileName;


                if (System.IO.File.Exists(path))
                {
                    // Use a try block to catch IOExceptions, to
                    // handle the case of the file already being
                    // opened by another process.

                    System.IO.File.Delete(path);

                }

            }
            catch (Exception)
            {


                throw new Exception("در حذف فایل مشکلی وجود دارد !!!");

            }

        }
    }
}
