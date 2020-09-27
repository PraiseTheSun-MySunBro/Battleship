using System;

namespace Utils.MenuSystem.Core
{
    public static class MenuControl
    {
        public static readonly string Exit = "X";
        public static readonly string Back = "B";
        public static readonly string Main = "M";
    }

    public class MenuControlBar
    {
        private static MenuControlBar _menuControlBar;

        public static MenuControlBar GetInstance()
        {
            _menuControlBar ??= new MenuControlBar();
            return _menuControlBar;
        }

        public void Draw(int depth)
        {
            Console.WriteLine($"{MenuControl.Exit}) Exit");
            
            if (depth > 1)
            {
                Console.WriteLine($"{MenuControl.Back}) Back");
            }
            
            if (depth > 2)
            {
                Console.WriteLine($"{MenuControl.Main}) Main Menu");
            }
        }
    }
}
