var configuration = Argument<string>("configuration", "Release");
var target = Argument<string>("target", "Default");

#tool "xunit.runner.console"
#tool "GitVersion.CommandLine"

var solutions = GetFiles("./**/*.sln");
var solutionPaths = solutions.Select(solution => solution.GetDirectory());

Task("Clean")
    .Does(() =>
{
    foreach(var path in solutionPaths)
    {
        Information("Cleaning {0}", path);
        CleanDirectories(path + "/**/bin/" + configuration);
        CleanDirectories(path + "/**/obj/" + configuration);
    }
});

Task("RestoreNugetPackages")
    .Does(() =>
{
    foreach(var solution in solutions)
    {
        Information("Restoring NuGet Packages for {0}", solution);
        NuGetRestore(solution);
    }
});

Task("UpdateAssemblyInfo")
    .Does(() =>
{
    GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = true
    });
});

Task("BuildSolutions")
    .IsDependentOn("Clean")
    .IsDependentOn("RestoreNugetPackages")
    .IsDependentOn("UpdateAssemblyInfo")
    .Does(() =>
{
    foreach(var solution in solutions)
    {
        Information("Building {0}", solution);

        MSBuild(solution, settings =>
            settings
                .SetConfiguration(configuration)
                .WithProperty("TreatWarningsAsErrors", "true")
                .UseToolVersion(MSBuildToolVersion.NET46)
                .SetVerbosity(Verbosity.Minimal)
                .SetNodeReuse(false));
    }
});

Task("RunTests")
    .IsDependentOn("BuildSolutions")
    .Does(() =>
{
    XUnit2("./src/**/bin/" + configuration + "/*.Test.dll", new XUnit2Settings {
        OutputDirectory = Directory("./")
    });
});

Task("Default")
    .IsDependentOn("RunTests");

RunTarget(target);
