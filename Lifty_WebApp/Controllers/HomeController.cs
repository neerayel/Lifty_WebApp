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
        private readonly IItemRepository _itemService;
        private readonly IContactsRepository _contactsRepository;

        public HomeController(ILogger<HomeController> logger, IItemRepository itemService, IContactsRepository contactsRepository)
        {
            _logger = logger;
            _itemService = itemService;
            _contactsRepository = contactsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var contactsData = await _contactsRepository.GetDataAsync();
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
            var contactsData = await _contactsRepository.GetDataAsync();
            return View(contactsData);
        }

        public async Task<IActionResult> Privacy()
        {
            var contactsData = await _contactsRepository.GetDataAsync();
            return View(contactsData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
