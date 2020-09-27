using System;
using Utils.MenuSystem.Helpers;

namespace Utils.MenuSystem.Core
{
    public class LabelMenuItem : MenuItemBase
    {
        private readonly Func<string> _labelFunc;
        
        protected string Label => _labelFunc();

        public LabelMenuItem(Func<string> labelFunc, int top = 0, int left = 0) : base(top, left)
        {
            _labelFunc = labelFunc;
            Validate();
        }

        public LabelMenuItem(string label, int top = 0, int left = 0) : this(() => label, top, left) { }

        private void Validate()
        {
            ValidateExceptionHelper.ThrowIfLengthIsOutOfBound(Label, 1, 40);
        }

        public override void Draw()
        {
            ConsoleHelper.OutputLine(Label, Top, Left);
        }
    }
}
