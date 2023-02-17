using Microsoft.AspNetCore.Mvc;
using TutoSearch.Data.Services;

namespace TutoSearch.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(p => p.Professor);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(p => p.Professor);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    l => l.Title.Contains(searchString) ||
                    l.Description.Contains(searchString)
                ).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }
        //Get: Lesson/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetLessonByIdAsync(id);
            return View(data);
        }
    }
}
