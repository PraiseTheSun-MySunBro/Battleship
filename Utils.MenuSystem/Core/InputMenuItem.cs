using System;

namespace Utils.MenuSystem.Core
{
    public class InputMenuItem : LabelMenuItem
    {
        private readonly Func<string, string> _func;

        public InputMenuItem(string label, Func<string, string> func, int top = 0, int left = 0) : base(label, top, left)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public void Next(string value)
        {
            _func(value);
        }
    }
}
