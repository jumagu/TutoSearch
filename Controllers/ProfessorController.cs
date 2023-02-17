using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoSearch.Data.Services;
using TutoSearch.Data.Static;
using TutoSearch.Models;

namespace TutoSearch.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Professor/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Professor profesor)
        {
            if (!ModelState.IsValid)
            {
                return View(profesor);
            }
            await _service.AddAsync(profesor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Professor/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var professorDetails = await _service.GetByIdAsync(id);
            if (professorDetails == null) return View("NotFound");
            return View(professorDetails);
        }

        //Get: Professor/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var professorDetails = await _service.GetByIdAsync(id);
            if (professorDetails == null) return View("NotFound");
            return View(professorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return View(professor);
            }
            await _service.UpdateAsync(id, professor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Professor/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var professorDetails = await _service.GetByIdAsync(id);
            if (professorDetails == null) return View("NotFound");
            return View(professorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professorDetails = await _service.GetByIdAsync(id);
            if (professorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
