using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace UploadFile.DAL.UploadFileEntity
{
    [Table("UploadFileWithoutFormTable")]
    public partial class UploadFileWithoutFormTable
    {
        [Key]
        [StringLength(75)]
        public string FileName { get; set; }

        [Required]
        public byte[] File { get; set; }
    }
}
