using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoginUser(string user, string password)
        {
            try
            {
                var response = _context.Usuarios.Where(x => x.user == user && x.password == password).ToList();

                if (response.Count() > 0 )
                {
                    return Json(new {Succes = true});
                }
                else
                {
                    return Json(new {Succes = false});
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error"+ex.Message);
            }
        }
    }
}
