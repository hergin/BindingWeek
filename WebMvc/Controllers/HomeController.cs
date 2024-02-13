using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var someTask = new TaskViewModel
        {
            Id = 1,
            Title = "Same old",
            Content = "Demo .NET",
            DueDate = DateTime.Now.AddDays(3)
        };
        var someOtherTask = new TaskViewModel
        {
            Id = 2,
            Title = "Grading",
            Content = "Grade some project",
            DueDate = DateTime.Now.AddDays(5)
        };
        return View(new List<TaskViewModel> { someTask, someOtherTask });

    }

    // GET: /HelloWorld/Edit/{id}
    public IActionResult Edit([FromRoute] int id)
    {
        var someTask = new TaskEditModel
        {
            Id = 1,
            Title = "Same old",
            Content = "Demo .NET",
            DueDate = DateTime.Now.AddDays(3)
        };
        var someOtherTask = new TaskEditModel
        {
            Id = 2,
            Title = "Grading",
            Content = "Grade some project",
            DueDate = DateTime.Now.AddDays(5)
        };
        return View(id == 1 ? someTask : someOtherTask);
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
        var someTask = new TaskViewModel
        {
            Id = 1,
            Title = "Same old",
            Content = "Demo .NET",
            DueDate = DateTime.Now.AddDays(3)
        };
        var someOtherTask = new TaskViewModel
        {
            Id = 2,
            Title = "Grading",
            Content = "Grade some project",
            DueDate = DateTime.Now.AddDays(5)
        };
        return View(id == 1 ? someTask : someOtherTask);

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
