using System;

namespace Utils.MenuSystem.Core
{
    public abstract class MenuItemBase : IDrawableElement
    {
        protected int Top { get; }
        protected int Left { get; }

        public MenuItemBase(int top, int left)
        {
            Top = top;
            Left = left;
            Validate();
        }

        private void Validate()
        {
            if (Top < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Top), "cannot be less than 0");
            }

            if (Left < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Left), "cannot be less than 0");
            }
        }

        public abstract void Draw();
    }
}
