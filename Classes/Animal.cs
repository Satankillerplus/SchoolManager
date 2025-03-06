using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Classes
{
    internal class Animal
    {
        public string name = "";
        public string species = "";
        public double weight;
        public string gender = "";
        public int age;

        internal Animal(string species, string gender, int age = 0, double weight = 0.0, string name = "")
        {
            this.age = age;
            this.weight = weight;
            this.gender = gender;
            this.species = species;
            this.name = name;
        }
    }
}