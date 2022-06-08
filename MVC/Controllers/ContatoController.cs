using Microsoft.AspNetCore.Mvc;
using MVC.Repositories.Models;
using MVC.Repositories.Repository;

namespace MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            this.contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            var contatosList = contatoRepository.GetAll();
            return View(contatosList);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = contatoRepository.GetById(id);
            return View(contato);
        }
        public IActionResult ApagarConfirm(int id)
        {
            ContatoModel contato = contatoRepository.GetById(id);
            return View(contato);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool deleted = contatoRepository.DeleteById(id);
                if (deleted)
                    TempData["SuccessMessage"] = "Contato deletado!";
                else
                    TempData["SuccessMessage"] = "Contato não foi deletado!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Contato não foi deletado! ({ex.Message})";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(contato);

                contatoRepository.Add(contato);
                TempData["SuccessMessage"] = "Contato cadastrado!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ops, o contato não foi cadastrado! Detalhes({ex.Message})";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Editar", contato);

                contatoRepository.Update(contato);
                TempData["SuccessMessage"] = "Contato alterado!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Contato não alterado! ({ex.Message})";
                return RedirectToAction("Index");
            }
        }
    }
}
