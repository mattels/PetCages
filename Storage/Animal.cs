using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /*public enum AnimalType
    {
        None,
        Cats,
        Tara,
        Kang,
        Squi,
        Rats,
        Rabb,
        Bear
    }*/

    public class Animal
    {
        //public AnimalType TypeOfAnimal { get; set; }
        public string TypeOfAnimal { get; set; }
        public bool Predator { get; set; }
        public bool Prey { get; set; }
        public int CageLimit { get; set; }
        public bool Caged { get; set; }

        public int StockCount { get; set; }
    }
}
