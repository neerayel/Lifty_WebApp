using Lifty_WebApp.DataAccess.Interfaces;

namespace Lifty_WebApp.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public async Task SaveImageAsync(IFormFile uploadedImage, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedImage.CopyToAsync(fileStream);
            }
        }

        public async Task EditImageAsync(IFormFile uploadedImage, string path, string oldPath)
        {
            if(!string.IsNullOrWhiteSpace(oldPath)) DeleteImage(oldPath);
            await SaveImageAsync(uploadedImage, path);
        }

        public void DeleteImage(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            fileInf.Delete();
        }
    }
}
