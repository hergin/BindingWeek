using Microsoft.Extensions.Logging;
using WebMvc.Models;
using DomainModel;
using WebMvc.Service;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Data;

namespace WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskService _taskService;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, TaskService taskService, AppDbContext context)
        {
            _logger = logger;
            _taskService = taskService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_taskService.GetAllTasks().Select(t => TaskViewModel.FromTask(t)));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var theTask = _taskService.FindTaskByID(id);
            var taskEditModel = TaskEditModel.FromTask(theTask);
            return View(taskEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Title,Content,DueDate")] TaskEditModel task)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTaskByID(id, task.Title, task.Content, task.DueDate);
                return RedirectToAction("ViewTask", new { id = id });
            }
            else
            {
                return View(task);
            }
        }

        public IActionResult ViewTask(int id)
        {
            var theTask = _taskService.FindTaskByID(id);
            return View(TaskViewModel.FromTask(theTask));
        }

        [HttpPost]
        public IActionResult Create(CreateTaskModel model)
        {
            if (ModelState.IsValid)
            {
                var newTask = new MyTask(model.Title, model.Content, model.DueDate);

                _taskService.AddsTask(newTask); 

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
