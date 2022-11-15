using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;        
        }

        public async Task <IActionResult> Index()
        {
            var response = await _context.Usuarios.Include(z=> z.Roles).ToListAsync();
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear_user(Usuario response)
        {
            try
            {
                if (response != null)
                {
                    Usuario user = new Usuario();
                    user.Nom = response.Nom;
                    user.user = response.user;
                    user.password = response.password;
                    user.FkRol = 1;
                    _context.Usuarios.Add(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message.ToString());
            }

        }

        [HttpGet]
        public IActionResult editar(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar_user(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    Usuario user = new Usuario();
                    user.PkUser = request.PkUser;
                    user.Nom = request.Nom;
                    user.user = request.user;
                    user.password = request.password;
                    user.FkRol = 1;
                    _context.Usuarios.Update(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message.ToString());
            }

        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var usuario = _context.Usuarios.Find(id);
                if (usuario != null)
                {
                    _context.Remove(usuario);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message.ToString());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
