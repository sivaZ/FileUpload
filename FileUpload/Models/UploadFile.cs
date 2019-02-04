namespace FileUpload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UploadFile")]
    public partial class UploadFile
    {
        public int Id { get; set; }

        public int UploadId { get; set; }

        [Required]
        [StringLength(100)]
        public string FileName { get; set; }

        public int FileSize { get; set; }

        [Required]
        [StringLength(20)]
        public string FileType { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        public virtual Upload Upload { get; set; }
    }
}
