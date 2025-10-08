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
            var contactsData = await _dataRepository.GetContactsDataAsync();
            return View(contactsData);
        }

        public async Task<IActionResult> Catalog()
        {
            return View();
        }

        public async Task<IActionResult> Servicing()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            return View();
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
