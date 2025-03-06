namespace ZooManager.Classes
{
    internal static class Zoo
    {
        private static string filePath = @"zoo.csv";
        public static List<Animal> animalList = new List<Animal>();

        // pokud soubor existuje, nacte z nej animal a vrati v poli. pokud neexistuje, vrati prazdne pole
        internal static void LoadZoo()
        {
            if(File.Exists(filePath))
            {
                using (StreamReader csv = new StreamReader(filePath))
                {
                    string data = "";
                    int i = 0;

                    // preskoci prvni radek a ulozi jednotlive zvirata jako objekty s properties do pole
                    while ((data = csv.ReadLine()) != null)
                    {
                        if (i != 0)
                        {
                            string[] animalProp = data.Split(';');
                            string animalName = animalProp[0];
                            string animalGender = animalProp[3];
                            string animalSpecies = animalProp[1];
                            int animalAge;
                            double animalWeight;

                            if (!int.TryParse(animalProp[4], out animalAge))
                            {
                                animalAge = 0;
                            }

                            if (!double.TryParse(animalProp[2], out animalWeight))
                            {
                                animalWeight = 0.0;
                            }

                            animalList.Add(new Animal(animalSpecies, animalGender, animalAge, animalWeight, animalName));
                        } else
                        {
                            i++;
                        }
                    }

                    // jen pro pripad
                    csv.Close();
                    csv.Dispose();
                }
            }
        }

        internal static void SaveZoo()
        {
            using (StreamWriter csv = new StreamWriter(filePath))
            {
                csv.WriteLine("Name;Species;Weight;Gender;Age");
                foreach (Animal animal in animalList)
                {
                    csv.WriteLine($"{animal.name};{animal.species};{animal.weight};{animal.gender};{animal.age}");
                }

                // jen pro pripad
                csv.Close();
                csv.Dispose();
            }
        }

        internal static void AddAnimal(Animal animal)
        {
            animalList.Add(animal);
            Zoo.SaveZoo();
        }

        internal static void RemoveAnimal(int index)
        {
            animalList.RemoveAt(index);
            Zoo.SaveZoo();
        }
    }
}