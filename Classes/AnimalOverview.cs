namespace ZooManager.Classes
{
    internal class AnimalOverview
    {
        public static int rowIndex = 0;

        public void DoLogic()
        {
            Draw();
            KeyboardInput();
        }

        private void Draw()
        {
            Console.Clear();
            var animalList = Zoo.animalList;

            Utilities.ShowHeader(ZooManager.appName);

            Console.WriteLine("{0,-3} {1,-15} {2,-15} {3,-15} {4,-15} {5}", "", "Name", "Species", "Gender", "Weight", "Age");

            for (int i = 0; i < animalList.Count(); i++)
            {
                if (i == rowIndex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("{0,-3} {1,-15} {2,-15} {3,-15} {4,-15} {5}", $"{i + 1}", $"{animalList[i].name}", $"{animalList[i].species}", $"{animalList[i].gender}", $"{animalList[i].weight}", $"{animalList[i].age}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("{0,-3} {1,-15} {2,-15} {3,-15} {4,-15} {5}", $"{i + 1}", $"{animalList[i].name}", $"{animalList[i].species}", $"{animalList[i].gender}", $"{animalList[i].weight}", $"{animalList[i].age}");
                }
            }

           Utilities.ShowFooter("[↑] Move up [↓] Move down [a] Add animal [e] Edit animal [r] Remove animal [s] Save database [Esc] Exit");
        }

        private void IndexOperator()
        {
            if (rowIndex < 0)
            {
                rowIndex = Zoo.animalList.Count() - 1;
            }
            else if (rowIndex > Zoo.animalList.Count() - 1)
            {
                rowIndex = 0;
            }
        }
        private void KeyboardInput()
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    rowIndex--;
                    IndexOperator();
                    break;
                case ConsoleKey.DownArrow:
                    rowIndex++;
                    IndexOperator();
                    break;
                case ConsoleKey.S:
                    Zoo.SaveZoo();
                    break;
                case ConsoleKey.E:
                    ZooManager.menuLocation = 1;
                    AnimalManipulation.manipulationIndex = 1;
                    break;
                case ConsoleKey.A:
                    ZooManager.menuLocation = 1;
                    AnimalManipulation.manipulationIndex = 0;
                    break;
                case ConsoleKey.R:
                    Zoo.RemoveAnimal(rowIndex);
                    break;
                case ConsoleKey.Escape:
                    Zoo.SaveZoo();
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}