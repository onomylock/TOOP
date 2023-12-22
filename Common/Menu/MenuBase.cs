namespace TOOP.Common.Menu
{
    public abstract class MenuBase
    {
        protected List<Option> options { get; set; }
     
        public void StartMenu(params Option[] options)
        {
            if (options is null  || options.Length == 0)
            {
                options = this.options.ToArray();
            }

            int index = 0;

            WriteMenu(options, options[index]);

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count())
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    bool flag = options[index].Selected.Invoke(0);
                    options[index].Color = ConsoleColor.Green;
                    if (!flag)
                        break;                    
                    index = 0;
                }

            } while (keyInfo.Key != ConsoleKey.X);           
        }

        private void WriteMenu(Option[] options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.ForegroundColor = option.Color;
                Console.WriteLine(option.Name);
                Console.ResetColor();
            }
        }

    }
}
