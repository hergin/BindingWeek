using System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var mainDirectory = Path.GetFullPath("..");
Console.WriteLine(@$"{mainDirectory}\Database\tasks.db");
