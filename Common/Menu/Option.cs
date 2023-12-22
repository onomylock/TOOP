namespace TOOP.Common.Menu
{
    public class Option
    {
        public string Name {get;}
        //public Action Selected {get;}
        public Predicate<int> Selected { get;}
        public ConsoleColor Color { get; set; } = ConsoleColor.White;

        public Option(string name, Predicate<int> selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}