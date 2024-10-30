using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppSaresp_2024.Controllers
{
    public class ProfessorAplicadorController : Controller
    {
        private IProfessorAplicadorRepository _professorAplicadorRepository;
        public ProfessorAplicadorController(IProfessorAplicadorRepository professorAplicadorRepository)
        {
            _professorAplicadorRepository = professorAplicadorRepository;
        }
        public IActionResult Index()
        {
            return View(_professorAplicadorRepository.ObterTodosProfessores());
        }
        [HttpGet]
        public IActionResult CadastrarProfessorAplicador()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarProfessorAplicador(ProfessorAplicador professorAplicador)
        {
            if (ModelState.IsValid)
            {
                _professorAplicadorRepository.Cadastrar(professorAplicador);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AtualizarProfessorAplicador(int id)
        {
            return View(_professorAplicadorRepository.ObterProfessor(id));
        }
        [HttpPost]
        public IActionResult AtualizarProfessorAplicador(ProfessorAplicador professorAplicador)
        {
            _professorAplicadorRepository.Atualizar(professorAplicador);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesProfessorAplicador(int id)
        {
            return View(_professorAplicadorRepository.ObterProfessor(id));
        }
        [HttpPost]
        public IActionResult DetalhesProfessorAplicador(ProfessorAplicador professorAplicador)
        {
            _professorAplicadorRepository.Atualizar(professorAplicador);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ExcluirProfessorAplicador(int id)
        {
            _professorAplicadorRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
