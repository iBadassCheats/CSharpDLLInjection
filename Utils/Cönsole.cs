namespace CSharpAOT.Utils
{
    public class Cönsole
    {
        public enum InitializeResult
        {
            Console_Successfully,
            Console_Failed
        }

        public static InitializeResult Initialize()
        {
            try
            {
                WinAPI.AllocConsole();
                IntPtr console = WinAPI.GetStdHandle(WinAPI.STD_OUTPUT_HANDLE);
                WinAPI.GetConsoleMode(console, out var mode);
                WinAPI.SetConsoleMode(console, mode | WinAPI.ENABLE_VIRTUAL_TERMINAL_PROCESSING);
                WinAPI.SetConsoleTitle("github.com/iBadassCheats - Console");
                WinAPI.SetConsoleTextAttribute(console, (ushort)ConsoleColor.White);

                return InitializeResult.Console_Successfully;
            }
            catch
            {
                return InitializeResult.Console_Failed;
            }
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"[{DateTime.Now.ToLongTimeString()}] [Info]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{DateTime.Now.ToLongTimeString()}] [Error]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        public static void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"[{DateTime.Now.ToLongTimeString()}] [Dbg]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
    }
}
