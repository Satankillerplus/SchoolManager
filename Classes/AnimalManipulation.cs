namespace ZooManager.Classes
{
    internal class AnimalManipulation
    {
        /// <summary>
        /// 0 - Add animal
        /// 1 - Edit animal
        /// </summary>
        public static int manipulationIndex = 0;

        internal void DoLogic()
        {
            Draw();
            Manipulate();
        }

        private void Draw()
        {
            Console.Clear();
            Utilities.ShowHeader(ZooManager.appName);
        }

        private void Manipulate()
        {
            Console.SetCursorPosition(0, 3);

            string animalName = "";
            string animalSpecies = "";
            string animalGender = "";
            int animalAge = 0;
            double animalWeight = 0.0;

            if (manipulationIndex == 0)
            {
                Console.Write("Enter name: ");
                animalName = ReadInput();

                Console.Write("Enter species: ");
                animalSpecies = ReadInput();

                Console.Write("Enter gender: ");
                animalGender = ReadInput();

                Console.Write("Ender age: ");
                int? tmpint = ParseInt();
                if (tmpint.HasValue)
                {
                    animalAge = tmpint.Value;
                    animalAge = tmpint.Value;
                }

                Console.Write("Ender weight: ");
                double? tmpdob = ParseDouble(true);
                if (tmpdob.HasValue)
                {
                    animalWeight = tmpdob.Value;
                }

                Zoo.AddAnimal(new Animal(animalSpecies, animalGender, animalAge, animalWeight, animalName));
            } else
            {
                var animal = Zoo.animalList[AnimalOverview.rowIndex];

                Console.Write($"Enter name[{animal.name}]: ");
                string tmpstr = ReadInput(true);
                if (tmpstr != "")
                {
                    animal.name = tmpstr;
                }

                Console.Write($"Enter species[{animal.species}]: ");
                tmpstr = ReadInput(true);
                if (tmpstr != "")
                {
                    animal.species = tmpstr;
                }

                Console.Write($"Enter gender[{animal.gender}]: ");
                tmpstr = ReadInput(true);
                if (tmpstr != "")
                {
                    animal.gender = tmpstr;
                }

                Console.Write($"Ender age[{animal.age}]: ");
                int? tmpint = ParseInt(true);
                if (tmpint.HasValue)
                {
                    animal.age = tmpint.Value;
                }

                Console.Write($"Ender weight[{animal.weight}]: ");
                double? tmpdob = ParseDouble(true);
                if (tmpdob.HasValue)
                {
                    animal.weight = tmpdob.Value;
                }
            }
            ZooManager.menuLocation = 0;
            Zoo.SaveZoo();
        }

        private int? ParseInt(bool allowEmpty = false)
        {
            int animalAge;
            string xxx = ReadInput(allowEmpty);

            if(allowEmpty && xxx == "")
            {
                return null;
            }

            if (!int.TryParse(xxx, out animalAge))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid number, try again.");
                Console.ResetColor();
                return ParseInt(allowEmpty);
            }

            return animalAge;
        }

        private double? ParseDouble(bool allowEmpty = false)
        {
            double animalAge;
            string xxx = ReadInput(allowEmpty);

            if (allowEmpty && xxx == "")
            {
                return null;
            }

            if (!double.TryParse(xxx, out animalAge))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid number, try again.");
                Console.ResetColor();
                return ParseDouble(allowEmpty);
            }

            return animalAge;
        }

        private string ReadInput(bool allowEmpty = false)
        {
            string text = Console.ReadLine();

            if (!allowEmpty && text == String.Empty)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input, try again.");
                Console.ResetColor();
                return ReadInput();
            }

            return text;
        }
    }
}