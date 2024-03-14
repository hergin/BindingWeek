using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using DomainModel;
using WebMvc.Service;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    ITaskService taskService;

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
        var taskEditModel = new TaskEditModel();  
        var theTask = taskService.FindTaskByID(id);
        if(theTask != null)
        {
            taskEditModel = TaskEditModel.FromTask(theTask);
        }
       return View(taskEditModel);
    }

    // GET /Home/Create
    public IActionResult Create()
    {
        var newTaskId = taskService.GetAmountOfTasks();
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
            taskService.UpdateTaskByID(id, task.Title, task.Content, task.DueDate);
            return Task.FromResult<IActionResult>(RedirectToAction("ViewTask", new { id = id }));
        }
        else
        {
            return Task.FromResult<IActionResult>(View(task));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public Task<IActionResult> Create(int id, [Bind("Title,Content,DueDate")] CreateModel task)
    {
        if (ModelState.IsValid)
        {
            taskService.CreateNewTask(task.Id, task.Title, task.Content, task.DueDate);
            return Task.FromResult<IActionResult>(RedirectToAction("ViewTask", new { id = id }));
        }
        else
        {
            return Task.FromResult<IActionResult>(View(task));
        }
    }

    public IActionResult ViewTask([FromRoute] int id)
    {
        var theTask = taskService.FindTaskByID(id);
        if(theTask != null)
        {
            return View(TaskViewModel.FromTask(theTask));
        }

        return View(); 
    }
}
