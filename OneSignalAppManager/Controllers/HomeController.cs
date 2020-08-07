using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneSignalAppManager.Gateway;
using OneSignalAppManager.Models;

namespace OneSignalAppManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly OneSignalGateway _oneSignalGateway;

        public HomeController(OneSignalGateway oneSignalGateway)
        {
            _oneSignalGateway = oneSignalGateway;
        }

        public async Task<IActionResult> Index()
        {
            List<OneSignalModel> model = await _oneSignalGateway.getAllApps();

            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            OneSignalModel model = await _oneSignalGateway.getAppById(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(OneSignalCreateModel model)
        {

            await _oneSignalGateway.createApps(model);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id)
        {
            OneSignalModel model = await _oneSignalGateway.getAppById(id);
            return View(OneSignalCreateModel.parse(model));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(OneSignalCreateModel model)
        {
            await _oneSignalGateway.updateApp(model.id, model);

            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    await _oneSignalGateway.deleteById(id);
        //    return RedirectToAction("Index");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
