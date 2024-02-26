using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using DomainModel;
using WebMvc.Service;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ITaskService taskService;

    public HomeController(ILogger<HomeController> logger, ITaskService taskService)
    {
        _logger = logger;
        this.taskService = taskService;
    }

    public IActionResult Index()
    {
        return View(taskService.GetAllTasks().Select(t => TaskViewModel.FromTask(t)));
    }

    // GET: /HelloWorld/Edit/{id}
    public IActionResult Edit([FromRoute] int id)
    {
        var theTask = taskService.FindTaskByID(id);
        var taskEditModel = TaskEditModel.FromTask(theTask);
        return View(taskEditModel);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Title,Content,DueDate")] TaskEditModel task)
    {
        if (ModelState.IsValid)
        {
            taskService.UpdateTaskByID(id, task.Title, task.Content, task.DueDate);
            return RedirectToAction("ViewTask", new { id = id });
        }
        else
        {
            return View(task);
        }
    }

    public IActionResult ViewTask([FromRoute] int id)
    {
        var theTask = taskService.FindTaskByID(id);
        return View(TaskViewModel.FromTask(theTask));
    }

    public IActionResult CreateTask()
    {
        return View(new TaskCreateModel());
    }
    // POST: /Home/Create
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create([Bind("Title,Content,DueDate")] TaskCreateModel task)
    {
        if (ModelState.IsValid)
        {
            taskService.CreateTask(task.Title, task.Content, task.DueDate);

            return RedirectToAction("Index");
        }
        else
        {
            return View(task);
        }
    }

}