using Utils.MenuSystem.Helpers;

namespace Utils.MenuSystem.Core
{
    public abstract class ChoiceMenuItemBase : LabelMenuItem
    {
        public string Choice { get; }

        public ChoiceMenuItemBase(string label, string choice, int top = 0, int left = 0) : base(label, top, left)
        {
            Choice = choice.ToUpper();
            Validate();
        }

        private void Validate()
        {
            ValidateExceptionHelper.ThrowIfLengthIsOutOfBound(Choice, 1, 20);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
