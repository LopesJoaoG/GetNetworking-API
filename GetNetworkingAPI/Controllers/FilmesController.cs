using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GetNetworkingAPI.Data;
using GetNetworkingAPI.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace GetNetworkingAPI.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filme.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.IdFilme == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdFilme,NomeFilme,DataLancamento,Duracao,VezesAssistidos,IsCurta")] Filme filme)
        {
            if (ModelState.IsValid)
            {

                //FileInfo arquivoPosterInfo = new FileInfo(filme.ArquivoPoster.FileName);
                //string nomePosterArquivo = filme.NomeFilme + arquivoPosterInfo.Extension;

                //string arquivoPosterCaminho = Path.Combine(caminho, nomePosterArquivo);

                //using (var stream = new FileStream(arquivoPosterCaminho, FileMode.Create))
                //{
                //    filme.ArquivoPoster.CopyTo(stream);
                //}


                //filme.CaminhoPoster = arquivoPosterCaminho;

                string caminho = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Arquivos/{filme.NomeFilme}");
                Directory.CreateDirectory(caminho);

                FileInfo fileFilme = new FileInfo(filme.ArquivoFilme.Name);
                string fileNome = filme.NomeFilme + fileFilme.Extension;

                string fileNomeCaminho = Path.Combine(caminho, fileNome);

                using (var stream = new FileStream(fileNomeCaminho, FileMode.Create))
                {
                    filme.ArquivoFilme.CopyTo(stream);
                }

                _context.Add(filme);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IdFilme,NomeFilme,DataLancamento,Duracao,VezesAssistidos,IsCurta,CaminhoFilme,CaminhoPoster")] Filme filme)
        {
            if (id != filme.IdFilme)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.IdFilme))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FirstOrDefaultAsync(m => m.IdFilme == id);

            

            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var filme = await _context.Filme.FindAsync(id);

            //FileInfo arquivoFilme = new FileInfo(filme.CaminhoFilme);
            //FileInfo arquivoPoster = new FileInfo(filme.CaminhoPoster);

            //arquivoFilme.Delete();
            //arquivoPoster.Delete();

            string caminho = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Arquivos/{filme.NomeFilme}");

            if (Directory.Exists(caminho)) {
                Directory.Delete(caminho);
            }
            

            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(long? id)
        {
            return _context.Filme.Any(e => e.IdFilme == id);
        }
    }
}
