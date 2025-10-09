
namespace Lifty_WebApp.DataAccess.Interfaces
{
    public interface IImageRepository
    {
        Task SaveImageAsync(IFormFile uploadedImage, string path);
        Task EditImageAsync(IFormFile uploadedImage, string path, string oldPath);
        void DeleteImage(string path);
    }
}
