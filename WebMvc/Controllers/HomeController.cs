using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using DomainModel;
using WebMvc.Service;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static TaskService taskService = new TaskService();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(taskService.GetAllTasks().Select(t => TaskViewModel.FromTask(t)));
    }

    // GET: /HelloWorld/Edit/{id}
    public IActionResult Edit([FromRoute] int id)
    {
        var task = taskService.FindTaskByID(id);
#pragma warning disable CS8604 // Possible null reference argument.
        var taskEditModel = TaskEditModel.FromTask(task);
#pragma warning restore CS8604 // Possible null reference argument.
        return View(taskEditModel);
    }

    // GET /Home/Create
    public IActionResult Create()
    {
        var newTaskId = taskService.GetNumTasks();
        var taskCreateModel = CreateModel.NewTask(newTaskId);
        return View(taskCreateModel);
    }
    
    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public Task<IActionResult> Edit(int id, [Bind("Title,Content,DueDate")] TaskEditModel task)
    {
        if (ModelState.IsValid)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            taskService.UpdateTaskByID(id, task.Title, task.Content, task.DueDate);
#pragma warning restore CS8604 // Possible null reference argument.
            return Task.FromResult<IActionResult>(RedirectToAction("ViewTask", new { id = id }));
        }
        else
        {
            return Task.FromResult<IActionResult>(View(task));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public Task<IActionResult> Create(int id, [Bind("Title,Content,DueDate")] CreateModel task) {
        if (ModelState.IsValid) {
            taskService.CreateNewTask(id, task.Title, task.Content, task.DueDate);
            return Task.FromResult<IActionResult>(RedirectToAction("ViewTask", new { id = id }));
        } else {
            return Task.FromResult<IActionResult>(View(task));
        }
    }
    
    public IActionResult ViewTask([FromRoute] int id) {
        var theTask = taskService.FindTaskByID(id);
#pragma warning disable CS8604 // Possible null reference argument.
        return View(TaskViewModel.FromTask(theTask));
#pragma warning restore CS8604 // Possible null reference argument.
    }

}
