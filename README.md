# CMDHelper
Wrapper for CMD.EXE

# Usage

static void Main(string[] args)
{

    var process = new CMDHelper.Instance();

    foreach (var item in process.Run("dir"))
    {

        Console.WriteLine(item);
    }

    Console.ReadLine();
}
