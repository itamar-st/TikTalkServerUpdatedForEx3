using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
namespace ChatServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private static Services.UserService _userService;
        // GET: ChatController
        //public ActionResult Index()
        //{
        //    return _userService.Get;
        //}

  //      // GET: ChatController/Details/5
  //      public ActionResult Details(int id)
  //      {
  //          return View();
  //      }

  //      // GET: ChatController/Create
  //      public ActionResult Create()
  //      {
  //          return View();
  //      }

  //      // POST: ChatController/Create
  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public ActionResult Create(IFormCollection collection)
  //      {
  //q

        // POST: ChatController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
