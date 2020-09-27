using System;
using Utils.MenuSystem.Helpers;

namespace Utils.MenuSystem.Core
{
    public class ChoiceMenuItem<T> : ChoiceMenuItemBase
        where T : class
    {
        public T Next { get; }

        public ChoiceMenuItem(string label, string choice, T next, int top = 0, int left = 0) : base(label, choice, top, left)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public override void Draw()
        {
            ConsoleHelper.OutputLine($"{Choice}) {Label}", Top, Left);
        }
    }

    public class ChoiceMenuItem : ChoiceMenuItem<Menu>
    {
        public ChoiceMenuItem(string label, string choice, Menu next, int top = 0, int left = 0) : base(label, choice, next, top, left) { }
    }

    public class ChoiceMenuActionItem : ChoiceMenuItem<Action>
    {
        public ChoiceMenuActionItem(string label, string choice, Action next, int top = 0, int left = 0) : base(label, choice, next, top, left) { }
    }
}
