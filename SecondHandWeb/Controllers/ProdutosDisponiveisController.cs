using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using PL.Context;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SecondHandWeb.Controllers
{
    public class ProdutosDisponiveisController : Controller
    {
        private readonly SecondHandContext _context;
        private readonly BusinesFacade _businesFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;

        public ProdutosDisponiveisController(SecondHandContext context, BusinesFacade businesFacade,
                                   UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: Produtoes
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_businesFacade.ItensDisponiveis());
        }

        // GET: Produtoes/Details/5
        [AllowAnonymous]
        public IActionResult Details(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var produto = _businesFacade.ItemPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }
       
        private bool ProdutoExists(long id)
        {
            return _businesFacade.existe(id);
        }

        //dados do usuario
        public async Task<IActionResult> DadosUsuario()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            ViewBag.Id = usuario.Id;
            ViewBag.UserName = usuario.UserName;

            return View();

        }

        public ActionResult GetImage(int id)
        {
            Imagem im = _businesFacade.GetImagem(id);
            if (im != null)
            {
                return File(im.ImageFile, im.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
