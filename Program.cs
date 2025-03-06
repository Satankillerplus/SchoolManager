using System.Text;
using ZooManager.Classes;

namespace ZooManager
{
    internal class ZooManager
    {
        /// <summary>
        /// 0 = main menu
        /// 1 = edit menu
        /// </summary>
        public static int menuLocation = 0;
        public static string appName = "Zoo Manager";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Zoo.LoadZoo();
            AnimalOverview animalOverview = new AnimalOverview();
            AnimalManipulation  animalManipulation = new AnimalManipulation();

            while (true)
            {
                switch(menuLocation)
                {
                    case 0:
                        animalOverview.DoLogic();
                        break;
                    case 1:
                        animalManipulation.DoLogic();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}