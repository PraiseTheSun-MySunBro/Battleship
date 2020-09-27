using System;
using System.Collections.Generic;
using Utils.MenuSystem.Core;

namespace Utils.MenuSystem
{
    public static class MenuManager
    {    
        public static void Run(Menu mainMenu)
        {
            Validate(mainMenu);

            var menuStack = new Stack<Menu>();
            menuStack.Push(mainMenu);
            
            while (true)
            {
                var menu = menuStack.Peek();
                var menuDepth = menuStack.Count;

                var response = menu.Run(menuDepth);

                switch (response)
                {
                    case (MenuResultType.Back, _):
                        menuStack.Pop();
                        break;
                    case (MenuResultType.Main, _):
                        while (menuStack.Count > 1)
                        {
                            menuStack.Pop();
                        }
                        break;
                    case (MenuResultType.Exit, _):
                        return;
                    case (MenuResultType.Ok, var next):
                        menuStack.Push(next);
                        break;
                    default:
                        throw new NotImplementedException($"There is no handler set for this current menu response type: {response.Type}");
                }
            }
        }

        private static void Validate(Menu mainMenu)
        {
            static void ValidateMenu(Menu menu, HashSet<string> keyMapping)
            {
                if (menu == null) return;

                if (menu.Items.Count == 0)
                {
                    throw new Exception($"Menu should have at least one menu item");
                }

                foreach (var item in menu.Items)
                {
                    if (typeof(ChoiceMenuItemBase).IsAssignableFrom(item.GetType()))
                    {
                        var menuItem = item as ChoiceMenuItemBase;
                        var choice = menuItem.Choice;

                        if (keyMapping.Contains(choice))
                        {
                            throw new Exception($"There are several items mapped to choice {choice}");
                        }

                        keyMapping.Add(choice);
                    }

                    if (typeof(ChoiceMenuItem).IsAssignableFrom(item.GetType()))
                    {
                        var menuItem = item as ChoiceMenuItem;
                        ValidateMenu(menuItem.Next, keyMapping);
                    }
                }
            }

            var keyMapping = new HashSet<string>();
            ValidateMenu(mainMenu, keyMapping);
        }
    }
}
