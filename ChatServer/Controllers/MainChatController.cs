using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers
{
    public class MainChatController : Controller
    {
        // GET: MainChatController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MainChatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainChatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainChatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainChatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainChatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainChatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
