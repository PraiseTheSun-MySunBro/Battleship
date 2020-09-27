using System;
using Utils.MenuSystem;
using Utils.MenuSystem.Configuration;
using Utils.MenuSystem.Core;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = SessionConfiguration.GetInstance();

            var justALabel = new LabelMenuItem("Just a Label :)");

            var newGameMenu = new Menu(justALabel);

            var setNickname = new InputMenuItem("Insert your nickname: ", (name) => config.Nickname = name);
            var nicknameMenu = new Menu(setNickname);

            var nicknameLabel = new LabelMenuItem(() => $"Your nickname: {config.Nickname}");
            var setNicknameChoice = new ChoiceMenuItem("Set your nickname", "sn", nicknameMenu);
            var characterMenu = new Menu(nicknameLabel, setNicknameChoice);

            // Settings Set Color Menu
            var redColor = new ChoiceMenuActionItem("Red", "r", () => Console.BackgroundColor = ConsoleColor.Red);
            var greenColor = new ChoiceMenuActionItem("Green", "g", () => Console.BackgroundColor = ConsoleColor.Green);
            var setColorMenu = new Menu(redColor, greenColor);
            //

            // Settings Menu
            var setColorOption = new ChoiceMenuItem("Set Color", "sc", setColorMenu);
            var settingsMenu = new Menu(setColorOption, justALabel);
            //

            // Main Menu
            var newGameItem = new ChoiceMenuItem("New Game", "1", newGameMenu);
            var characterItem = new ChoiceMenuItem("Character", "2", characterMenu);
            var settingsItem = new ChoiceMenuItem("Settings", "3", settingsMenu);

            var mainMenu = new Menu(newGameItem, characterItem, settingsItem);
            //

            MenuManager.Run(mainMenu);
        }
    }
}
