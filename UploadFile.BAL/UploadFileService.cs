using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadFile.BAL.Models;

namespace UploadFile.BAL
{
    public class UploadFileService
    {
        public static bool CLientUploadFile(ModelFile model)
        {
            var client = new FileUploadService.UploadFileServiceClient();
            return client.UploadFile(model.FileName, model.stream);
        }
    }
}
