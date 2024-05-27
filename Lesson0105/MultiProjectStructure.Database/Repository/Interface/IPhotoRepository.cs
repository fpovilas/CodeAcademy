using MultiProjectStructure.Database.Entities;

namespace MultiProjectStructure.Database.Repository.Interface
{
    public interface IPhotoRepository
    {
        CustomImage GetImage(Guid guid);
        CustomImageThumbnail GetImageThumbnail(Guid guid);
        void UploadImage(CustomImage image);
        void UploadThumbnail(CustomImageThumbnail thumbnail);
    }
}