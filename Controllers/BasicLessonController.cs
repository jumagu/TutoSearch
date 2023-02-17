using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutoSearch.Data.Services;
using TutoSearch.Data.Static;
using TutoSearch.Models;

namespace TutoSearch.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BasicLessonController : Controller
    {
        private readonly IBasicLessonService _service;

        public BasicLessonController(IBasicLessonService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(p => p.Professor);
            return View(data);
        }
        //Get BasicLesson/Create
        public async Task<IActionResult> Create()
        {
            var basicLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
            ViewBag.Professors = new SelectList(basicLessonDropdownsData.Professors, "Id", "FullName");
            ViewBag.Topics = new SelectList(basicLessonDropdownsData.Topics, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBasicLessonVM basicLesson)
        {
            if (!ModelState.IsValid)
            {
                var basicLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
                ViewBag.Professors = new SelectList(basicLessonDropdownsData.Professors, "Id", "FullName");
                ViewBag.Topics = new SelectList(basicLessonDropdownsData.Topics, "Id", "Name");
                return View(basicLesson);
            }
            await _service.AddNewBasicLessonAsync(basicLesson);
            return RedirectToAction(nameof(Index));
        }
        //Get: BasicLesson/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetBasicLessonByIdAsync(id);
            return View(data);
        }

        //Get: BasicLesson/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var basicLessonDetails = await _service.GetBasicLessonByIdAsync(id);
            if (basicLessonDetails == null) return View("NotFound");

            var response = new NewBasicLessonVM()
            {
                Id = basicLessonDetails.Id,
                Title = basicLessonDetails.Title,
                Description = basicLessonDetails.Description,
                VideoURL = basicLessonDetails.VideoURL,
                ProfessorId = basicLessonDetails.ProfessorId,
                TopicsIds = basicLessonDetails.Topics_Lessons.Select(t => t.TopicId).ToList(),
            };

            var basicLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
            ViewBag.Professors = new SelectList(basicLessonDropdownsData.Professors, "Id", "FullName");
            ViewBag.Topics = new SelectList(basicLessonDropdownsData.Topics, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBasicLessonVM basicLesson)
        {
            if (id != basicLesson.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var basicLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
                ViewBag.Professors = new SelectList(basicLessonDropdownsData.Professors, "Id", "FullName");
                ViewBag.Topics = new SelectList(basicLessonDropdownsData.Topics, "Id", "Name");
                return View(basicLesson);
            }
            await _service.UpdateBasicLessonAsync(basicLesson);
            return RedirectToAction(nameof(Index));
        }
        //Get: BasicLesson/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var basicLessonDetails = await _service.GetByIdAsync(id);
            if (basicLessonDetails == null) return View("NotFound");
            return View(basicLessonDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicLessonDetails = await _service.GetByIdAsync(id);
            if (basicLessonDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
