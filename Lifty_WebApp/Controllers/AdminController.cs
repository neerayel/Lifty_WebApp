using Lifty_WebApp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Lifty_WebApp.DataAccess.Interfaces;

namespace Lifty_WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class AdminController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public AdminController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
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

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(Item itemModel)
        {
            var item = await _itemRepository.CreateAsync(itemModel);
            return RedirectToAction(nameof(ItemDetails), new { id = item.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItem(Item itemModel)
        {
            await _itemRepository.UpdateAsync(itemModel);
            return RedirectToAction(nameof(ItemDetails), new { id = itemModel.Id }); ;
        }

        [HttpPost]
        public async Task<IActionResult> CopyItem(int selectedItemId)
        {
            var newItem = await _itemRepository.CopyByIdAsync(selectedItemId);

            int minIdValue = 0;
            if (newItem.Id <= minIdValue) return RedirectToAction(nameof(Error));

            return RedirectToAction(nameof(ItemDetails), new { id = newItem.Id });

        }

        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null) return NotFound();

            var item = await _itemRepository.GetByIdAsync((int)id);
            if (item == null) return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItemByIdConfirmed(int id)
        {
            await _itemRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ItemDetails(int id)
        {
            var test = await _itemRepository.GetByIdAsync(id);
            return View(test);
        }
    }
}
