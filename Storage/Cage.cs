using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public enum CageStatus
    {
        Empty,
        Filled,
        Spaces,
    }

    public class Cage
    {
        public int CageNumber { get; set; }
        public CageStatus Status { get; set; }
        public int[] NextToList { get; set; }
        //public AnimalType TypeOfAnimal { get; set; }
        public string TypeOfAnimal { get; set; }
        public int AnimalCount { get; set; }
        public int CountMax { get; set; }
        public bool Predator { get; set; }
        public bool NextToPredator { get; set; }

        public void ClearCage()
        {
            Status = CageStatus.Empty;
            TypeOfAnimal = "None";//AnimalType.None;
            AnimalCount = 0;
            CountMax = 0;
            Predator = false;
            NextToPredator = false;
        }
    }
}
