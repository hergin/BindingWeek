using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using DomainModel;
using WebMvc.Service;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITaskService _taskService;

    public HomeController(ILogger<HomeController> logger, ITaskService taskService)
    {
        _logger = logger;
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        return View(_taskService.GetAllTasks().Select(t => TaskViewModel.FromTask(t)));
    }

    public IActionResult Edit([FromRoute] int id)
    {
        var theTask = _taskService.FindTaskByID(id);
        if (theTask == null)
        {
            return NotFound();
        }
        var taskEditModel = TaskEditModel.FromTask(theTask);
        return View(taskEditModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Title,Content,DueDate")] TaskEditModel task)
    {
        if (ModelState.IsValid)
        {
            if (task.Title == null || task.Content == null)
            {
                return BadRequest("Title or Content cannot be null");
            }
            _taskService.UpdateTaskByID(id, task.Title, task.Content, task.DueDate);
            return RedirectToAction("ViewTask", new { id = id });
        }
        else
        {
            return View(task);
        }
    }

    public IActionResult ViewTask([FromRoute] int id)
    {
        var theTask = _taskService.FindTaskByID(id);
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
    public IActionResult Create([Bind("Title,Content,DueDate")] TaskCreateModel createModel)
    {
        if (ModelState.IsValid)
        {
            if (createModel.Title == null || createModel.Content == null)
            {
                return BadRequest("Title or Content cannot be null");
            }

            MyTask newTask = new MyTask(0, createModel.Title, createModel.Content, createModel.DueDate);
            _taskService.AddTask(newTask);

            return RedirectToAction("Index");
        }
        return View(createModel);
    }
}