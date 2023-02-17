using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoSearch.Data.Services;
using TutoSearch.Data.Static;
using TutoSearch.Models;

namespace TutoSearch.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TopicController : Controller
    {
        private readonly ITopicService _service;

        public TopicController(ITopicService service)
        {
            _service = service;
        }

        //Get: Topic/All
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Topic/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Description", "TopicSubject")] Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return View(topic);
            }
            await _service.AddAsync(topic);
            return RedirectToAction(nameof(Index));
        }
        //Get: Topic/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var topicDetails = await _service.GetByIdAsync(id);
            if (topicDetails == null) return View("NotFound");
            return View(topicDetails);
        }
        //Get: Topic/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var topicDetails = await _service.GetByIdAsync(id);
            if (topicDetails == null) return View("NotFound");
            return View(topicDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, TopicSubject")] Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return View(topic);
            }
            await _service.UpdateAsync(id, topic);
            return RedirectToAction(nameof(Index));
        }

        //Get: Topic/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var topicDetails = await _service.GetByIdAsync(id);
            if (topicDetails == null) return View("NotFound");
            return View(topicDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topicDetails = await _service.GetByIdAsync(id);
            if (topicDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
