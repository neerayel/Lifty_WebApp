using System.Diagnostics;
using Lifty_WebApp.Models;
using Lifty_WebApp.DataAccess.Interfaces;
using Lifty_WebApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lifty_WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IItemRepository _itemRepository;
        private readonly IStoredDataRepository _dataRepository;

        public HomeController(ILogger<HomeController> logger, IItemRepository itemService, IStoredDataRepository dataRepository)
        {
            _logger = logger;
            _itemRepository = itemService;
            _dataRepository = dataRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ContactsData = await _dataRepository.GetContactsDataAsync();
            ViewBag.CatalogDemo = await _itemRepository.GetRangeAsync(3);
            var data = await _dataRepository.GetAboutDataAsync();
            return View(data);
        }

        public async Task<IActionResult> Catalog()
        {
            ViewBag.ContactsData = await _dataRepository.GetContactsDataAsync();
            var catalogData = await _itemRepository.GetAllAsync();
            return View(catalogData);
        }

        public async Task<IActionResult> ItemDetails(string id)
        {
            ViewBag.ContactsData = await _dataRepository.GetContactsDataAsync();
            var item = await _itemRepository.GetByIdAsync(id);
            return View(item);
        }

        public async Task<IActionResult> Servicing()
        {
            ViewBag.ContactsData = await _dataRepository.GetContactsDataAsync();
            var data = await _dataRepository.GetAboutDataAsync();
            return View(data);
        }

        public async Task<IActionResult> About()
        {
            ViewBag.ContactsData = await _dataRepository.GetContactsDataAsync();
            var dataModel = await _dataRepository.GetAboutDataAsync();
            return View(dataModel);
        }

        public async Task<IActionResult> Contacts()
        {
            var contactsData = await _dataRepository.GetContactsDataAsync();
            return View(contactsData);
        }

        public async Task<IActionResult> Privacy()
        {
            var contactsData = await _dataRepository.GetContactsDataAsync();
            return View(contactsData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
