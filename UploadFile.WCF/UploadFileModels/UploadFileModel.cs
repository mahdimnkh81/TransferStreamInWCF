using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace UploadFile.WCF.UploadFileModels
{
    [MessageContract]
    public class UploadFileModel : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream stream { get; set; }

        public void Dispose()
        {
            if (stream == null)
            {
                return;
            }

            stream.Close();
            stream = null;
        }
    }

    [MessageContract]
    public class UploadResponse
    {
        [MessageBodyMember(Order = 1)]
        public bool UploadSucceeded { get; set; }
    }
}