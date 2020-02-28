
using studyingProgect.Models;
using System.Collections.Generic;

namespace studyingProgect
{
    public static class State
    {
        public static List<Nomenclature> Nomenclaure { get; set; }


        static State()
        {
            Nomenclaure = new List<Nomenclature>();
        }

        public static void Initialize()
        {
            Nomenclaure.Add(new Nomenclature("AMD"));
            Nomenclaure.Add(new Nomenclature("INTEL"));
            Nomenclaure.Add(new Nomenclature("NVIDIA"));
            Nomenclaure.Add(new Nomenclature("KINGSTON"));
            Nomenclaure.Add(new Nomenclature("CORSAIR"));
            Nomenclaure.Add(new Nomenclature("WD"));
            Nomenclaure.Add(new Nomenclature("SEAGATE"));
            Nomenclaure.Add(new Nomenclature("SAMSUNG"));
            Nomenclaure.Add(new Nomenclature("PHILIPS"));
        }
    }
}
