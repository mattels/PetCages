using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace Storage
{
    public class Warehouse
    {
        public Cage[] Cages;
        public Animal[] Animals;
        private int StartPosition { get; set; }

        public Warehouse()
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

            Animal[] animalGroups = new Animal[]
            {
                new Animal() {TypeOfAnimal = "Big Cats", Predator = true, Prey = false, CageLimit = 1, StockCount = 4},
                new Animal() {TypeOfAnimal = "Tarantulas", Predator = false, Prey = false, CageLimit = 10, StockCount = 5},
                new Animal() {TypeOfAnimal = "Kangaroos", Predator = false, Prey = true, CageLimit = 1, StockCount = 2},
                new Animal() {TypeOfAnimal = "Squirrels", Predator = false, Prey = true, CageLimit = 3, StockCount = 5},
                new Animal() {TypeOfAnimal = "Rats", Predator = false, Prey = true, CageLimit = 5, StockCount = 10},
                new Animal() {TypeOfAnimal = "Rabbits", Predator = false, Prey = true, CageLimit = 3, StockCount = 2},                                
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

            Cages = cages;
            Animals = animals.ToArray();
        }

        public Warehouse(Cage[] cages, Animal[] animals)
        {
            Cages = cages;
            Animals = animals;
        }

        public void CageAnimals()
        {
            StartPosition = 1;

            int bestStartPosition = StartPosition;
            int bestStartPositionCount = Cages.Count();

            for (int i = 0; i < Cages.Count(); i++)
            {
                PopulateCages();

                var nextToPredators = from cage in Cages where cage.Status == CageStatus.Empty && cage.NextToPredator == true select cage.CageNumber;
                if (nextToPredators.Any() == false)
                {
                    bestStartPosition = StartPosition;
                    break;
                }
                else
                {
                    if (nextToPredators.Count() < bestStartPositionCount)
                    {
                        bestStartPosition = StartPosition;
                        bestStartPositionCount = nextToPredators.Count();
                    }
                }

                StartPosition = NextCagePosition(StartPosition);
            }

            StartPosition = bestStartPosition;
            PopulateCages();

            List<Animal> nonPreys = (from animal in Animals where animal.Predator == false && animal.Prey == false select animal).ToList();
            AddNonPreyToCages(nonPreys);

            List<Animal> prey = (from animal in Animals where animal.Prey == true select animal).ToList();
            AddAnimalsToCages(prey);
        }

        private void PopulateCages()
        {
            EmptyCages();

            List<Animal> predators = (from animal in Animals where animal.Predator == true select animal).ToList();
            AddAnimalsToCages(predators);
          
            FlagCagesNextToPredators();
        }

        private void EmptyCages()
        {
            foreach (Cage cage in Cages)
            {
                cage.ClearCage();
            }
        }

        private void FlagCagesNextToPredators()
        {
            var predatorCages = from cage in Cages where cage.Predator == true select cage.CageNumber;

            if (predatorCages.Any())
            {
                foreach (Cage cage in Cages)
                {
                    foreach (int cageNumber in cage.NextToList)
                    {
                        if (predatorCages.Contains(cageNumber))
                        {
                            cage.NextToPredator = true;
                            break;
                        }
                    }
                }
            }
        }

        private void AddNonPreyToCages(List<Animal> nonPreys)
        {
            bool sideFlipNext = false;
            foreach (Animal nonPrey in nonPreys)
            {
                if (AddAnimalToUnfilledCage(nonPrey) == false)
                {
                    if (sideFlipNext == true)
                    {
                        AddAnimalToNextEmptyCage(nonPrey);
                    }
                    else
                    {
                        AddAnimalToPreviousEmptyCage(nonPrey);
                    }

                    sideFlipNext ^= true;
                }
            }
        }

        private void AddAnimalsToCages(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                if (AddAnimalToUnfilledCage(animal) == false)
                {
                    AddAnimalToNextEmptyCage(animal);
                }
            }
        }

        private void AddAnimalToNextEmptyCage(Animal animal)
        {
            int position = StartPosition;
            for (int i = 0; i < Cages.Count(); i++)
            {
                Cage cage = Cages[position - 1];
                if (cage.TypeOfAnimal == "None")//AnimalType.None)
                {
                    if (!(animal.Prey == true && cage.NextToPredator == true))
                    {
                        AddAnimalToCage(cage, animal);
                        break;
                    }
                }

                position = NextCagePosition(position);
            }
        }

        private void AddAnimalToPreviousEmptyCage(Animal animal)
        {
            int position = StartPosition;
            for (int i = 0; i < Cages.Count(); i++)
            {
                Cage cage = Cages[position - 1];

                if (cage.TypeOfAnimal == "None")//AnimalType.None)
                {
                    AddAnimalToCage(cage, animal);
                    break;
                }

                position = PreviousCagePosition(position);
            }
        }

        private bool AddAnimalToUnfilledCage(Animal animal)
        {
            var selectedCage = from cage in Cages where cage.TypeOfAnimal == animal.TypeOfAnimal && cage.AnimalCount < animal.CageLimit select cage;
            if (selectedCage.Any())
            {
                AddAnimalToCage(selectedCage.First(), animal);
                return true;
            }

            return false;
        }

        private void AddAnimalToCage(Cage cage, Animal animal)
        {
            if (cage.TypeOfAnimal == "None")//AnimalType.None)
            {
                cage.TypeOfAnimal = animal.TypeOfAnimal;
                cage.CountMax = animal.CageLimit;
                cage.Predator = animal.Predator;
            }

            cage.AnimalCount++;
            animal.Caged = true;

            if (cage.AnimalCount == animal.CageLimit)
            {
                cage.Status = CageStatus.Filled;
            }
            else
            {
                cage.Status = CageStatus.Spaces;
            }
        }

        private int NextCagePosition(int position)
        {
            return Cages.Count() == position ? 1 : position + 1;
        }

        private int PreviousCagePosition(int position)
        {
            return position == 1 ? Cages.Count() : position - 1;
        }
    }
}
