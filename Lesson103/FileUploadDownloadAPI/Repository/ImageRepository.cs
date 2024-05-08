using FileUploadDownloadAPI.Database;
using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Repository.Interface;

namespace FileUploadDownloadAPI.Repository
{
    public class ImageRepository(ImageDbContext context) : IImageRepository
    {
        public CustomImage GetImage(Guid guid) =>
            context.Images.First(img => img.ID.Equals(guid));

        public CustomImageThumbnail GetImageThumbnail(Guid guid)
        {
            var thumbnailGUID = context.ImageThumbnails.First(img => img.CutomsImageID.Equals(guid)).ID;
            return context.ImageThumbnails.First(img => img.ID.Equals(thumbnailGUID));
        }

        public void UploadImage(CustomImage image)
        {
            context.Images.Add(image);
            context.SaveChanges();
        }

        public void UploadThumbnail(CustomImageThumbnail thumbnail)
        {
            context.ImageThumbnails.Add(thumbnail);
            context.SaveChanges();
        }
    }
}
