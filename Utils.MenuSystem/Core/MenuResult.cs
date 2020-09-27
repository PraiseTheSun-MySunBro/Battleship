namespace Utils.MenuSystem.Core
{
    public class MenuResult
    {
        public MenuResultType Type { get; set; }
        public Menu Next { get; set; }

        public MenuResult(MenuResultType type)
        {
            Type = type;
        }

        public MenuResult(MenuResultType type, Menu next) : this(type)
        {
            Next = next;
        }

        public void Deconstruct(out MenuResultType type, out Menu next)
        {
            type = Type;
            next = Next;
        }
    }

    public enum MenuResultType
    {
        Back,
        Main,
        Exit,
        Ok
    }
}
