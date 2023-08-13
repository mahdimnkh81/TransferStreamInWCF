using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UploadFile.DAL.UploadFileEntity
{

    public partial class UploadFileDb : DbContext
    {
        public UploadFileDb() : base("name=UploadFileDb")
        {
        }

        public virtual DbSet<UploadFileWithoutFormTable> UploadFileWithoutFormTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
