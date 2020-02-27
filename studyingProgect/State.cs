
using studyingProgect.Models;
using System.Collections.Generic;

namespace studyingProgect
{
    public static class State
    {
        public static List<Nomenclaure> Nomenclaure { get; set; }

        static State()
        {
            Nomenclaure = new List<Nomenclaure>();
        }

        public static void Initialize()
        {
            Nomenclaure.Add(new Nomenclaure("AMD"));
        }
    }
}
