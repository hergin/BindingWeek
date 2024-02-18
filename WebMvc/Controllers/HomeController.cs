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

    public static TaskCreateModel createModel = new TaskCreateModel();

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
        var theTask = taskService.FindTaskByID(id);
        if (theTask == null)
        {
            return NotFound();
        }
        var taskEditModel = TaskEditModel.FromTask(theTask);
        return View(taskEditModel);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Title,Content,DueDate")] TaskEditModel task)
    {
        if (ModelState.IsValid)
        {
            // added null checks to stop IDE warnings
            if (task.Title == null || task.Content == null)
            {
                return BadRequest("Title or Content cannot be null");
            }
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
        if (theTask == null)
        {
            return NotFound();
        }
        return View(TaskViewModel.FromTask(theTask));
    }

    // GET: /Home/Create (enables viewing this page, otherwise error 405)
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Home/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Title,Content,DueDate")] TaskCreateModel createModel)
    {
        if (ModelState.IsValid)
        {   
            // task and its description must be provided
            if (createModel.Title == null || createModel.Content == null)
            {
                return BadRequest("Title or Content cannot be null");
            }

            MyTask newTask = new MyTask(0, createModel.Title, createModel.Content, createModel.DueDate);
            taskService.AddTask(newTask);

            return RedirectToAction("Index");
        }
        return View(createModel);
    }
}