using System;
using System.Collections.Generic;
using System.Linq;
using Storage;

namespace PetCages
{
    internal class Program
    {        
        private static void Main(string[] args)
        {
            Cage[] cages = new Cage[]
            {
                new Cage() {CageNumber = 1, NextToList = new int[] {2, 14}},
                new Cage() {CageNumber = 2, NextToList = new int[] {1, 3, 14}},
                new Cage() {CageNumber = 3, NextToList = new int[] {2, 4}},
                new Cage() {CageNumber = 4, NextToList = new int[] {3, 5, 6}},
                new Cage() {CageNumber = 5, NextToList = new int[] {4, 6}},
                new Cage() {CageNumber = 6, NextToList = new int[] {4, 5, 7}},
                new Cage() {CageNumber = 7, NextToList = new int[] {6, 8, 9}},
                new Cage() {CageNumber = 8, NextToList = new int[] {7, 9}},
                new Cage() {CageNumber = 9, NextToList = new int[] {7, 8, 10}},
                new Cage() {CageNumber = 10, NextToList = new int[] {9, 11}},
                new Cage() {CageNumber = 11, NextToList = new int[] {10, 12, 13}},
                new Cage() {CageNumber = 12, NextToList = new int[] {11, 13}},
                new Cage() {CageNumber = 13, NextToList = new int[] {11, 12, 14}},
                new Cage() {CageNumber = 14, NextToList = new int[] {1, 2, 13}},
            };
            /*
            Animal[] animalGroups = new Animal[]
            {
                new Animal() {TypeOfAnimal = AnimalType.Cats, Predator = true, Prey = false, CageLimit = 1, StockCount = 4},
                new Animal() {TypeOfAnimal = AnimalType.Tara, Predator = false, Prey = false, CageLimit = 10, StockCount = 5},
                new Animal() {TypeOfAnimal = AnimalType.Kang, Predator = false, Prey = true, CageLimit = 1, StockCount = 2},
                new Animal() {TypeOfAnimal = AnimalType.Squi, Predator = false, Prey = true, CageLimit = 3, StockCount = 5},
                new Animal() {TypeOfAnimal = AnimalType.Rats, Predator = false, Prey = true, CageLimit = 5, StockCount = 10},
                new Animal() {TypeOfAnimal = AnimalType.Rabb, Predator = false, Prey = true, CageLimit = 3, StockCount = 2}
            };
            */
            Animal[] animalGroups = new Animal[]
            {
                new Animal() {TypeOfAnimal = "Cats", Predator = true, Prey = false, CageLimit = 1, StockCount = 4},
                new Animal() {TypeOfAnimal = "Tara", Predator = false, Prey = false, CageLimit = 10, StockCount = 5},
                new Animal() {TypeOfAnimal = "Kang", Predator = false, Prey = true, CageLimit = 1, StockCount = 2},
                new Animal() {TypeOfAnimal = "Squi", Predator = false, Prey = true, CageLimit = 3, StockCount = 5},
                new Animal() {TypeOfAnimal = "Rats", Predator = false, Prey = true, CageLimit = 5, StockCount = 10},
                new Animal() {TypeOfAnimal = "Rabb", Predator = false, Prey = true, CageLimit = 3, StockCount = 2},
                new Animal() {TypeOfAnimal = "Foxs", Predator = true, Prey = false, CageLimit = 2, StockCount = 2}
            };

            List<Animal> animals = new List<Animal>();
            foreach (Animal animal in animalGroups)
            {
                for (int i = 0; i < animal.StockCount; i++)
                {
                    animals.Add(new Storage.Animal
                    {
                        TypeOfAnimal = animal.TypeOfAnimal,
                        Predator = animal.Predator,
                        Prey = animal.Prey,
                        CageLimit = animal.CageLimit
                    });
                }
            }

            Warehouse warehouse = new Warehouse(cages, animals.ToArray());            
            warehouse.CageAnimals();

            foreach (Cage cage in cages)
            {
                string output = cage.CageNumber + " - " + cage.Status.ToString() + " - " + cage.TypeOfAnimal.ToString() + " - " + "NextToPred:" + cage.NextToPredator.ToString()  + " - " + cage.AnimalCount;
                Console.WriteLine(output);
            }
            
            Console.WriteLine();
            SetConsoleColor(cages[0]);
            Console.Write("| " + cages[0].TypeOfAnimal.ToString() + "(" + cages[0].AnimalCount + ") ");
            SetConsoleColor(cages[1]);
            Console.Write("| " + cages[1].TypeOfAnimal.ToString() + "(" + cages[1].AnimalCount + ") ");
            SetConsoleColor(cages[2]);
            Console.Write("| " + cages[2].TypeOfAnimal.ToString() + "(" + cages[2].AnimalCount + ") ");
            SetConsoleColor(cages[3]);
            Console.Write("| " + cages[3].TypeOfAnimal.ToString() + "(" + cages[3].AnimalCount + ") ");
            SetConsoleColor(cages[4]);
            Console.Write("| " + cages[4].TypeOfAnimal.ToString() + "(" + cages[4].AnimalCount + ") |");
            Console.WriteLine();
            SetConsoleColor(cages[13]);
            Console.Write("| " + cages[13].TypeOfAnimal.ToString() + "(" + cages[13].AnimalCount + ") ");
            Console.Write("|         ");
            Console.Write("          ");
            Console.Write("          ");
            SetConsoleColor(cages[5]);
            Console.Write("| " + cages[5].TypeOfAnimal.ToString() + "(" + cages[5].AnimalCount + ") |");
            Console.WriteLine();
            SetConsoleColor(cages[12]);
            Console.Write("| " + cages[12].TypeOfAnimal.ToString() + "(" + cages[12].AnimalCount + ") ");
            Console.Write("|         ");
            Console.Write("          ");
            Console.Write("          ");
            SetConsoleColor(cages[6]);
            Console.Write("| " + cages[6].TypeOfAnimal.ToString() + "(" + cages[6].AnimalCount + ") |");
            Console.WriteLine();
            SetConsoleColor(cages[11]);
            Console.Write("| " + cages[11].TypeOfAnimal.ToString() + "(" + cages[11].AnimalCount + ") ");
            SetConsoleColor(cages[10]);
            Console.Write("| " + cages[10].TypeOfAnimal.ToString() + "(" + cages[10].AnimalCount + ") ");
            SetConsoleColor(cages[9]);
            Console.Write("| " + cages[9].TypeOfAnimal.ToString() + "(" + cages[9].AnimalCount + ") ");
            SetConsoleColor(cages[8]);
            Console.Write("| " + cages[8].TypeOfAnimal.ToString() + "(" + cages[8].AnimalCount + ") ");
            SetConsoleColor(cages[7]);
            Console.Write("| " + cages[7].TypeOfAnimal.ToString() + "(" + cages[7].AnimalCount + ") |");

            Console.WriteLine();
            Console.WriteLine();            
            Console.WriteLine("Not Caged:");            
            foreach (Animal animal in warehouse.Animals)
            {
                if (animal.Caged == false)
                {
                    string output = animal.TypeOfAnimal.ToString();
                    Console.WriteLine(output);
                }
            }

            Console.Read();
        }

        private static void SetConsoleColor(Cage cage)
        {
            if (cage.Predator == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (cage.NextToPredator == true)
            {
               Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (cage.TypeOfAnimal == "None")//AnimalType.None)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
