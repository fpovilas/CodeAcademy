using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadDownloadAPI.Model
{
    public class CustomImageThumbnail
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required byte[] ImageData { get; set; }
        [ForeignKey(nameof(CustomImage))]
        public Guid CutomsImageID { get; set; }
        public virtual CustomImage? CustomImage { get; set; }
        // public required string PictureUrl { get; set; } // for saving in PC/Server !use Absolute path to file!
    }
}
