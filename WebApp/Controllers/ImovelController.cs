using Dominio.IRepositories;
using Historia.Imoveis;
using Infra.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ImovelController : Controller
    {
        private readonly CriarImovel _criarImovel;
        private readonly AlterarImovel _alterarImovel;
        private readonly ExcluirImovel _excluirImovel;
        private readonly ConsultarImovel _consultarImovel;

        private readonly Context _context;
        public ImovelController(IImovelRepository imovelRepository, Context context)
        {
            _criarImovel = new CriarImovel(imovelRepository);
            _alterarImovel = new AlterarImovel(imovelRepository);
            _excluirImovel = new ExcluirImovel(imovelRepository);
            _consultarImovel = new ConsultarImovel(imovelRepository);

            _context = context;
        }

        public async Task<IActionResult> PesquisaCidade(string pesquisa)
        {
            var imoveis = from cidade in _context.Imoveis select cidade;
            if (!string.IsNullOrEmpty(pesquisa))
            {
                imoveis = imoveis.Where(x => x.cidade.Contains(pesquisa));
            }
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(imoveis);
            return View(listaImoveisViewModel);
        }


        public async Task<IActionResult> PesquisaBairro(string pesquisa2)
        {
            var imoveis = from bairro in _context.Imoveis select bairro;
            if (!string.IsNullOrEmpty(pesquisa2))
            {
                imoveis = imoveis.Where(x => x.bairro.Contains(pesquisa2));
            }
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(imoveis);
            return View(listaImoveisViewModel);
        }

        public async Task<IActionResult> Index()
        {
            var listaImoveis = await _consultarImovel.ListarTodosImoveis();
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(listaImoveis);

            return View(listaImoveisViewModel);
        }

        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ImovelViewModel imovelViewModel)
        {
            if (ModelState.IsValid)
            {
                var imovel = ImovelFactory.MapearImovel(imovelViewModel);

                await _criarImovel.Executar(imovel);

                return RedirectToAction("Index");
            }

            return View(imovelViewModel);
        }

        public async Task<IActionResult> Alterar(int id)
        {
            var imovel = await _consultarImovel.BuscarPeloId(id);

            if (imovel == null)
            {
                return RedirectToAction("Index");
            }

            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);

            return View(imovelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelViewModel);
            }

            var imovel = ImovelFactory.MapearImovel(imovelViewModel);

            await _alterarImovel.Executar(id, imovel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhar(int id)
        {
            var imovel = await _consultarImovel.BuscarPeloId(id);

            if (imovel == null)
            {
                return RedirectToAction("Index");
            }

            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);

            return View(imovelViewModel);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var imovel = await _consultarImovel.BuscarPeloId(id);

            if (imovel == null)
            {
                return RedirectToAction("Index");
            }


            await _excluirImovel.Executar(imovel);

            return RedirectToAction("Index");
        }

    }

}
