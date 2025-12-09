using Lifty_WebApp.Authorization;
using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.DataAccess.Interfaces;
using Lifty_WebApp.DataAccess.Repositories;
using Lifty_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lifty_WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class AdminController : Controller
    {
        public string WebRootPath { private get; set; }
        public string emptyImgPath {  get; set; } = "/img/design/NotFound.jpg";
        private readonly IItemRepository _itemRepository;
        private readonly IStoredDataRepository _dataRepository;
        private readonly IImageRepository _imageRepository;

        public AdminController(IWebHostEnvironment appEnvironment, IItemRepository itemRepository, 
            IStoredDataRepository dataRepository, IImageRepository imageRepository)
        {
            WebRootPath = appEnvironment.WebRootPath;
            _itemRepository = itemRepository;
            _dataRepository = dataRepository;
            _imageRepository = imageRepository;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Catalog(int pageNumber, int itemsOnPageCount)
        {
            if (pageNumber <= 0 && itemsOnPageCount <= 0)
            {
                pageNumber = 1;
                itemsOnPageCount = 10;
            }
            int startIndex = pageNumber * itemsOnPageCount - itemsOnPageCount;
            List<ItemModel> items = await _itemRepository.GetAllAsync();

            if (startIndex > items.Count)
            {
                pageNumber = 1;
                itemsOnPageCount = 10;
            }
            startIndex = pageNumber * itemsOnPageCount - itemsOnPageCount;

            ViewBag.PageNumber = pageNumber;
            ViewBag.ItemsOnPageCount = itemsOnPageCount;

            if (itemsOnPageCount == 1) ViewBag.PageCount = items.Count / itemsOnPageCount;
            else ViewBag.PageCount = items.Count / itemsOnPageCount + 1;

            items = items.Slice(startIndex, items.Count - startIndex);

            if (items.Count <= itemsOnPageCount)
            {
                return View(items);
            }
            return View(items.GetRange(startIndex, itemsOnPageCount));
        }

        public async Task<IActionResult> About()
        {
            var aboutData = await _dataRepository.GetAboutDataAsync();
            return View(aboutData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> About(AboutDataModel aboutData)
        {
            await _dataRepository.UpdateAboutDataAsync(aboutData);
            return RedirectToAction(nameof(About));
        }

        public async Task<IActionResult> Contacts()
        {
            var contactsData = await _dataRepository.GetContactsDataAsync();
            return View(contactsData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contacts(ContactsModel contacts)
        {
            await _dataRepository.UpdateContactsDataAsync(contacts);
            return RedirectToAction(nameof(Contacts));
        }

        public async Task<IActionResult> CreateItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(ItemModel itemModel, List<IFormFile> loadedImg)
        {
            itemModel.ImgPath = new List<string>();
            foreach (var image in loadedImg)
            {
                try
                {
                    string imgPath = "";
                    if (image != null || !String.IsNullOrWhiteSpace(image.FileName))
                    {
                        imgPath = "/img/content/" + Guid.NewGuid().ToString() + image.FileName;
                        string fullPath = WebRootPath + imgPath;
                        await _imageRepository.SaveImageAsync(image, fullPath);

                        itemModel.ImgPath.Add(imgPath);
                    }
                }
                catch { }
            }
            
            var item = await _itemRepository.CreateAsync(itemModel);
            return RedirectToAction(nameof(ItemDetails), new { id = item.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItem(ItemModel itemModel)
        {
            if (itemModel.ImgPath == null)
            {
                var itemOld = await _itemRepository.GetByIdAsync(itemModel.Id);
                if (itemOld.ImgPath != null) itemModel.ImgPath = itemOld.ImgPath;
                else itemModel.ImgPath = new List<string> { emptyImgPath };
            }
            else
            {
                itemModel.ImgPath.RemoveAll(x => String.IsNullOrEmpty(x) == true);
                if (itemModel.ImgPath.Count == 0)
                {
                    itemModel.ImgPath = new List<string> { emptyImgPath };
                }
            }
            
            await _itemRepository.UpdateAsync(itemModel);
            return RedirectToAction(nameof(ItemDetails), new { id = itemModel.Id }); ;
        }

        [HttpPost]
        public async Task<IActionResult> CopyItem(string selectedItemId)
        {
            var newItem = await _itemRepository.CopyByIdAsync(selectedItemId);
            return RedirectToAction(nameof(ItemDetails), new { id = newItem.Id });

        }

        public async Task<IActionResult> DeleteItem(string id)
        {
            if (String.IsNullOrEmpty(id)) return NotFound();

            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItemByIdConfirmed(string id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            foreach(var imgPath in item.ImgPath)
            {
                _imageRepository.DeleteImage(WebRootPath + imgPath);
            }

            await _itemRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Catalog));
        }

        public async Task<IActionResult> ItemDetails(string id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            return View(item);
        }
    }
}
