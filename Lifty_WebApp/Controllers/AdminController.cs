using Lifty_WebApp.Business.Interfaces;
using Lifty_WebApp.Business.Models;
using Lifty_WebApp.Authorization;
using Lifty_WebApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Lifty_WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.Schema, Roles = AuthenticationSchemes.Role)]
    public class AdminController : Controller
    {
        private readonly IItemService _itemService;
        public AdminController(IItemService itemService)
        {
            _itemService = itemService;
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

        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(ItemModel itemModel)
        {
            var item = await _itemService.CreateAsync(itemModel);
            return RedirectToAction(nameof(ItemDetails), new { id = item.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItem(ItemModel itemModel)
        {
            await _itemService.UpdateAsync(itemModel);
            return RedirectToAction(nameof(ItemDetails), new { id = itemModel.Id }); ;
        }

        [HttpPost]
        public async Task<IActionResult> CopyItem(int selectedItemId)
        {
            var newItem = await _itemService.CopyByIdAsync(selectedItemId);

            int minIdValue = 0;
            if (newItem.Id <= minIdValue) return RedirectToAction(nameof(Error));

            return RedirectToAction(nameof(ItemDetails), new { id = newItem.Id });

        }

        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null) return NotFound();

            var item = await _itemService.GetByIdAsync((int)id);
            if (item == null) return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItemByIdConfirmed(int id)
        {
            await _itemService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ItemDetails(int id)
        {
            var test = await _itemService.GetByIdAsync(id);
            var isValid = await _itemService.CheckPublishAsync(test);
            ViewBag.isValid = isValid;
            return View(test);
        }
    }
}
