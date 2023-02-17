using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutoSearch.Data.Services;
using TutoSearch.Data.Static;
using TutoSearch.Models;

namespace TutoSearch.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ExpertLessonController : Controller
    {
        private readonly IExpertLessonService _service;

        public ExpertLessonController(IExpertLessonService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(p => p.Professor);
            return View(data);
        }
        //Get ExpertLesson/Create
        public async Task<IActionResult> Create()
        {
            var expertLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
            ViewBag.Professors = new SelectList(expertLessonDropdownsData.Professors, "Id", "FullName");
            ViewBag.Topics = new SelectList(expertLessonDropdownsData.Topics, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewExpertLessonVM expertLesson)
        {
            if (!ModelState.IsValid)
            {
                var expertLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
                ViewBag.Professors = new SelectList(expertLessonDropdownsData.Professors, "Id", "FullName");
                ViewBag.Topics = new SelectList(expertLessonDropdownsData.Topics, "Id", "Name");
                return View(expertLesson);
            }
            await _service.AddNewExpertLessonAsync(expertLesson);
            return RedirectToAction(nameof(Index));
        }
        //Get: ExpertLesson/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetExpertLessonByIdAsync(id);
            return View(data);
        }

        //Get: ExpertLesson/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var expertLessonDetails = await _service.GetExpertLessonByIdAsync(id);
            if (expertLessonDetails == null) return View("NotFound");

            var response = new NewExpertLessonVM()
            {
                Id = expertLessonDetails.Id,
                Title = expertLessonDetails.Title,
                Description = expertLessonDetails.Description,
                VideoURL = expertLessonDetails.VideoURL,
                Price = expertLessonDetails.Price,
                ProfessorId= expertLessonDetails.ProfessorId,
                TopicsIds = expertLessonDetails.Topics_Lessons.Select(t => t.TopicId).ToList(),
            };

            var expertLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
            ViewBag.Professors = new SelectList(expertLessonDropdownsData.Professors, "Id", "FullName");
            ViewBag.Topics = new SelectList(expertLessonDropdownsData.Topics, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewExpertLessonVM expertLesson)
        {
            if (id != expertLesson.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var expertLessonDropdownsData = await _service.GetNewLessonDropdownsVM();
                ViewBag.Professors = new SelectList(expertLessonDropdownsData.Professors, "Id", "FullName");
                ViewBag.Topics = new SelectList(expertLessonDropdownsData.Topics, "Id", "Name");

                return View(expertLesson);
            }
            await _service.UpdateExpertLessonAsync(expertLesson);
            return RedirectToAction(nameof(Index));
        }

        //Get: ExpertLesson/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var expertLessonDetails = await _service.GetByIdAsync(id);
            if (expertLessonDetails == null) return View("NotFound");
            return View(expertLessonDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expertLessonDetails = await _service.GetByIdAsync(id);
            if (expertLessonDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
