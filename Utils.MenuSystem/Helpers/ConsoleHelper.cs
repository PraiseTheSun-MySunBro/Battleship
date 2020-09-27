using System;

namespace Utils.MenuSystem.Helpers
{
    public static class ConsoleHelper
    {
        private static void OutputCore(Action<string> consoleAction, string message, int topPad = 0, int leftPad = 0)
        {
            Console.Write(new string('\n', topPad));
            Console.Write(new string(' ', leftPad));

            consoleAction(message);
        }

        public static void Output(string message, int topPad = 0, int leftPad = 0)
        {
            OutputCore(Console.Write, message, topPad, leftPad);
        }

        public static void OutputLine(string message, int topPad = 0, int leftPad = 0)
        {
            OutputCore(Console.WriteLine, message, topPad, leftPad);
        }
    }
}
