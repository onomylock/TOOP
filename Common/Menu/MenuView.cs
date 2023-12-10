namespace TOOP.Common.Menu
{
    public static class MenuView
    {
        public static List<Option> MainOptions = new List<Option>()
        {
            new Option("Set Function", () => SetFunctionCommand()),
            new Option("Set Functional", () => SetFunctionalCommand()),
            new Option("Set Optimaze scheme", () => SetOptimizeShemeCommand()),
            new Option("Exit", () => Environment.Exit(0)),            
        };

        public static List<Option> FunctionOptions = new List<Option>()
        {
            new Option("Select function type", () => SelectFunctionTypeCommand()),
            new Option("Set function from file", () => SelectFunctionFromFileCommand()),
            new Option("Insert function", () => InsertFunctionCommand()),
            new Option("Get function value in point", () => InsertFunctionValueCommand()),
            new Option("Get function gradient in point", () => GetFunctionGradientCommand()),
            new Option("Exit", () => ExitToMainMenuCommand())
        };

        public static List<Option> FunctionalOptions = new List<Option>()
        {
            new Option("Select functional type", () => SelectFunctionalTypeCommand()),
            //new Option("Set function from file", () => SelectFunctionFromFileCommand()),
            //new Option("Insert function", () => InsertFunctionCommand()),
            //new Option("Get functional value in point", () => InsertFunctionValueCommand()),
            //new Option("Get function gradient in point", () => GetFunctionGradientCommand()),
            new Option("Exit", () => ExitToMainMenuCommand())
        };

        public static void StartMenu()
        {
            int index = 0;

            WriteMenu(MainOptions, MainOptions[index]);

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < MainOptions.Count)
                    {
                        index++;
                        WriteMenu(MainOptions, MainOptions[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(MainOptions, MainOptions[index]);
                    }
                }                
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    MainOptions[index].Selected.Invoke();
                    index = 0;
                }

            } while (keyInfo.Key != ConsoleKey.X);
        }
        
        private static void WriteMenu(List<Option> options, Option selectedOption)        
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

                Console.WriteLine(option.Name);
            }
        }

        #region Main menu
        private static void SetFunctionCommand()
        {

        }

        private static void SetFunctionalCommand()
        {

        }

        private static void SetOptimizeShemeCommand()
        {

        }

        private static void ExitToMainMenuCommand()
        {

        }

        #endregion

        #region Function menu

        private static void SelectFunctionTypeCommand()
        {

        }

        private static void SelectFunctionFromFileCommand()
        {
            
        }

        private static void InsertFunctionCommand()
        {
            
        }

        private static void InsertFunctionValueCommand()
        {
            
        }

        private static void GetFunctionGradientCommand()
        {
            
        }

        #endregion

        #region Functional menu
        
        private static void SelectFunctionalTypeCommand()
        {

        }

        #endregion

        #region Optimaizer menu

        #endregion
    }
}