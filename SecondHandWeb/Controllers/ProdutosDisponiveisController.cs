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
using SecondHandWeb.Models;

namespace SecondHandWeb.Controllers
{
    public class ProdutosDisponiveisController : Controller
    {
        private readonly BusinesFacade _businesFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;
        private readonly SecondHandContext cntc;

        public ProdutosDisponiveisController(BusinesFacade businesFacade, SecondHandContext cn,
                                   UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
            cntc = cn;
        }

        // GET: ProdutosDisponiveis
        [AllowAnonymous]
        public async Task<IActionResult> Index(string ProdutoCategoria, string searchString)
        {
            //var categoriaQuery = _businesFacade.categoriasNomes();

            
            var categoriaQuery = (from m in cntc.Produtos
                              orderby m.Categoria.Name
                              select m.Categoria.Name);
            

            //var produtos = _businesFacade.IQuerDeProdutosDisponiveis();

            
            var produtos = from m in cntc.Produtos
                         select m;
            


            if (!string.IsNullOrEmpty(searchString))
            {
                produtos = produtos.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(ProdutoCategoria))
            {
                produtos = produtos.Where(x => x.Categoria.Name == ProdutoCategoria);
            }

            var produtoCategoriaVM = new ProdutoCategoriaViewModel
            {
                Categorias = new SelectList( categoriaQuery.Distinct().ToList()),
                Produtos = produtos.ToList()
            };

            return View(produtoCategoriaVM);
        }

        // GET: ProdutosDisponiveis/Details/
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

        // GET: ProdutosDisponiveis/Compra/
        [AllowAnonymous]
        public IActionResult Compra(long id)
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
