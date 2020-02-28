
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
        }
    }
}
