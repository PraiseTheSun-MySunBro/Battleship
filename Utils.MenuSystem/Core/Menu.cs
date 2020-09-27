using System;
using System.Collections.Generic;

namespace Utils.MenuSystem.Core
{
    public class Menu : IDrawableElement
    {
        public List<MenuItemBase> Items { get; } = new List<MenuItemBase>();
        public int Depth { get; private set; }

        public Menu() { }

        public Menu(params MenuItemBase[] items) : this()
        {
            AddItems(items);
        }

        public virtual void AddItems(params MenuItemBase[] items)
        {
            Items.AddRange(items);
        }

        public virtual void Draw()
        {
            Console.Clear();

            MenuNavBar.GetInstance().Draw(Depth);
            Console.WriteLine();

            MenuControlBar.GetInstance().Draw(Depth);
            Console.WriteLine();

            foreach (var item in Items)
            {
                item.Draw();
            }
        }

        public virtual MenuResult Run(int depth)
        {
            Depth = depth;

            while (true)
            {
                Draw();

                var userChoice = WaitUserInput();

                var defaultControlChoiceResponse = DefaultControlHandler(userChoice);
                if (defaultControlChoiceResponse != null)
                {
                    return defaultControlChoiceResponse;
                }

                foreach (var item in Items)
                {
                    MenuResult result = null;
                    switch (item)
                    {
                        case ChoiceMenuItem menuItem when CompareChoices(userChoice, menuItem.Choice):
                            result = new MenuResult(MenuResultType.Ok, menuItem.Next);
                            break;

                        case ChoiceMenuItem<Action> menuItem when CompareChoices(userChoice, menuItem.Choice):
                            menuItem.Next();
                            break;

                        case InputMenuItem menuItem:
                            menuItem.Next(userChoice);
                            result = new MenuResult(MenuResultType.Back);
                            break;
                    }

                    if (result != null)
                    {
                        return result;
                    }
                }
            }
        }

        protected virtual string WaitUserInput()
        {
            return Console.ReadLine();
        }

        protected virtual bool CompareChoices(string input1, string input2)
        {
            return string.Equals(input1, input2, StringComparison.OrdinalIgnoreCase);
        }

        protected virtual MenuResult DefaultControlHandler(string userChoice)
        {
            if (CompareChoices(userChoice, MenuControl.Exit))
            {
                return new MenuResult(MenuResultType.Exit);
            }
            if (Depth > 1 && CompareChoices(userChoice, MenuControl.Back))
            {
                return new MenuResult(MenuResultType.Back);
            }
            if (Depth > 2 && CompareChoices(userChoice, MenuControl.Main))
            {
                return new MenuResult(MenuResultType.Main);
            }

            return null;
        }
    }
}
