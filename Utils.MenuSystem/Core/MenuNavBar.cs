using System;

namespace Utils.MenuSystem.Core
{
    public class MenuNavBar
    {
        private static MenuNavBar _menuNavBar;

        public static MenuNavBar GetInstance()
        {
            _menuNavBar ??= new MenuNavBar();
            return _menuNavBar;
        }

        public void Draw(int depth)
        {
            if (depth < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(depth), $"cannot be lower than 1");
            }

            Console.Write("|");
            for (var i = 1; i <= depth; ++i)
            {
                Console.Write($"_<{i}_|");
            }
            Console.WriteLine();
        }
    }
}
