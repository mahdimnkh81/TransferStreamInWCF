using System;
using System.IO;
using UploadFile.WCF.UploadFileModels;

namespace UploadFile.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UploadFileService : IUploadFileService
    {
        public UploadResponse UploadFile(UploadFileModel model)
        {
            try
            {
                var uploadDirectory = @"C:\Users\m.mansouri\Desktop\AB";

                // Try to create the upload directory if it does not yet exist
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                // Check if a file with the same filename is already
                // present in the upload directory. If this is the case
                // then delete this file
                var path = Path.Combine(uploadDirectory, model.FileName);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Read the incoming stream and save it to file
                const int bufferSize = 4096;

                var buffer = new byte[bufferSize];
                using (var outputStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var bytesRead = model.stream.Read(buffer, 0, bufferSize);
                    while (bytesRead > 0)
                    {
                        outputStream.Write(buffer, 0, bytesRead);
                        bytesRead = model.stream.Read(buffer, 0, bufferSize);
                    }
                    outputStream.Close();
                }
                model.stream.Close();
                model.stream.Dispose();

                return new UploadResponse
                {
                    UploadSucceeded = true
                };
            }
            catch (Exception ex)
            {
                // Note down exception some where!

                model.stream.Close();
                model.stream.Dispose();
                return new UploadResponse
                {
                    UploadSucceeded = false
                };

            }
        }
    }
}

