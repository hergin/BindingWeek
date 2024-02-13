using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using DomainModel;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    List<MyTask> tasks;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        tasks = new List<MyTask>();
        tasks.Add(new MyTask(1, "Same old", "Demo .NET", DateTime.Now.AddDays(3)));
        tasks.Add(new MyTask(2, "Grading", "Grade some projects", DateTime.Now.AddDays(5)));
    }

    public IActionResult Index()
    {
        return View(tasks.Select(t => TaskViewModel.FromTask(t)));
    }



    // GET: /HelloWorld/Edit/{id}
    public IActionResult Edit([FromRoute] int id)
    {
        var theTask = tasks.Find(t => t.Id == id);
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
            var updatedTask = new TaskEditModel
            {
                Id = id,
                Title = task.Title,
                Content = task.Content,
                DueDate = task.DueDate
            };
            return RedirectToAction("ViewTask", new { id = id });
        }
        else
        {
            return View(task);
        }
    }

    public IActionResult ViewTask([FromRoute] int id)
    {
        return View(TaskViewModel.FromTask(tasks.Find(t => t.Id == id)));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
