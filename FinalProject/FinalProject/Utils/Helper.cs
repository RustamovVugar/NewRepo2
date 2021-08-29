using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Utils
{
    public static class Helper
    {
        public static void Print(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
