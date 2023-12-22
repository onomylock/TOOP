namespace TOOP.Common.Menu
{
    public class MainMenu : MenuBase
    {

        public MainMenu() : base()
        {
            options = new List<Option>()
            {
                new Option("Set Function", (i) => SetFunctionCommand()),
                new Option("Set Functional", (i) => SetFunctionalCommand()),
                new Option("Set Optimaze scheme", (i) => SetOptimizeShemeCommand()),
                new Option("Exit", (i) => false),            
            };
        }


        private bool SetFunctionCommand()
        {
            var funcMenu = new FunctionMenu();
            funcMenu.StartMenu();
            return true;

        }

        private bool SetFunctionalCommand()
        {
            var functionalMenu = new FunctionalMenu();
            functionalMenu.StartMenu();
            return true;
        }

        private bool SetOptimizeShemeCommand()
        {
            var optiMenu = new OptimizatorMenu();
            optiMenu.StartMenu();
            return true;
        }       
    }
}
