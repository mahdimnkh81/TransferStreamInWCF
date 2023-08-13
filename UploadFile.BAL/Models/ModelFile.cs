using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadFile.BAL.Models
{
    public class ModelFile
    {
        public string FileName { get; set; }
        public Stream stream { get; set; }
    }
}
