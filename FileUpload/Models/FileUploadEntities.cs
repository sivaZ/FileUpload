namespace FileUpload.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FileUploadEntities : DbContext
    {
        public FileUploadEntities()
            : base("name=FileUploadEntities")
        {
        }

        public virtual DbSet<Upload> Uploads { get; set; }
        public virtual DbSet<UploadFile> UploadFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Upload>()
                .HasMany(e => e.UploadFiles)
                .WithRequired(e => e.Upload)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UploadFile>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<UploadFile>()
                .Property(e => e.FileType)
                .IsUnicode(false);
        }
    }
}
