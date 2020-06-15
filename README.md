# CMDHelper
Simple wrapper for CMD.EXE.

I wanted to run cmd commands and aplications more friendly in C#.

Just make instance of a "CMDHelper.Instance" class and run commands like "process.Run("dir")"
it return List<string>, where every line is an list entry.

You can pass arguments with command.

You can set EnvironmentVariable @ constructor.


# Usage
```
static void Main(string[] args)
{
    var process = new CMDHelper.Instance();

    foreach (var item in process.Run("dir"))
    {

        Console.WriteLine(item);
    }
    Console.ReadLine();
}

static void Main(string[] args)
{
    var process = new CMDHelper.Instance(new[] { ("PATH", @"C:\Program Files\dotnet") });

    foreach (var item in process.Run("dotnet --version"))
    {
        Console.WriteLine(item);
    }
    Console.ReadLine();
}

```
