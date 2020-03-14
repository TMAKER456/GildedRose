# GildedRose
Gilded Rose Assessment

This repository consists of one solution with two projects, a console app project and a MSTest unit test project. 
Both projects target .NET Core 3.1. 
Latest C# 8 language features have been used, so Visual Studio 2019 is required, or installation of the Microsoft.Net.Compilers NuGet package into an earlier version of Visual Studio.


To build, clone/download the master branch. Open the .sln in Visual Studio, and it should build without any additional steps.
Ensure that the GuildedRose.App project is set as the startup project, and press F5 to run. Or after building the solution, navigate to the bin folder, and run the GildedRose.App.exe file.


The console application can be used in two ways:

1. With command line arguments:
Running "GildedRose.App.exe Aged Brie 1 1" will cause the application to process the single input, output the result and exit immediately.

2. Without command line arguments:
Without command line arguments, the application will prompt the user for an input with "Enter item:". Enter the item's details (e.g. "Aged Brie 1 1") and press the Enter key, the result will be outputted and will prompt for another input. 
It will keep asking for and processing items until "Exit" is entered, at which point the application will exit.


Error Handling
If an invalid input is entered, e.g "qwerty", then an error will be outputted. 
There is also error handling around the limits of what sellin and quality values can be entered.
