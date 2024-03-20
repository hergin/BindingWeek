using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using DomainModel;
using WebMvc.Service;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ITaskService _taskService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ITaskService taskService)
    {
        _logger = logger;
        _taskService = taskService;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        var taskViewModels = tasks.Select(t => TaskViewModel.FromTask(t)).ToList();
        return View(taskViewModels);
    }

    // GET: /HelloWorld/Edit/{id}
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var theTask = await _taskService.FindTaskByIDAsync(id);
        if (theTask == null)
        {
            return NotFound();
        }
        var taskEditModel = TaskEditModel.FromTask(theTask);
        return View(taskEditModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Title,Content,DueDate")] TaskEditModel task)
    {
        if (ModelState.IsValid)
        {
            await _taskService.UpdateTaskByIDAsync(id, task.Title, task.Content, task.DueDate);
            return RedirectToAction("ViewTask", new { id = id });
        }
        else
        {
            return View(task);
        }
    }

    public async Task<IActionResult> ViewTask([FromRoute] int id)
    {
        var theTask = await _taskService.FindTaskByIDAsync(id);
        if (theTask == null)
        {
            return NotFound();
        }
        return View(TaskViewModel.FromTask(theTask));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Content,DueDate")] TaskEditModel taskEditModel)
    {
        if (ModelState.IsValid)
        {
            await _taskService.CreateTaskAsync(taskEditModel);
            return RedirectToAction(nameof(Index));
        }
        return View(taskEditModel);
    }
}
