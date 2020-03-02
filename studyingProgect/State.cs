
using studyingProgect.Models;
using System.Collections.Generic;

namespace studyingProgect
{
    public static class State
    {
        public static List<Nomenclature> Nomenclaure { get; set; }

        public static List<Warehouse> Warehouses { get; set; }

        public static List<Incoming> Incomings { get; set; }

        public static List<Assemblage> Assemblage { get; set; }

        public static List<Consumption> Consumptions { get; set; }

        public static List<History> History { get; set; }


        static State()
        {
            Nomenclaure = new List<Nomenclature>();
            Warehouses = new List<Warehouse>();
            Incomings = new List<Incoming>();
            Assemblage = new List<Assemblage>();
            Consumptions = new List<Consumption>();
            History = new List<History>();
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

            Warehouses.Add(new Warehouse("Main"));
            Warehouses.Add(new Warehouse("Additional"));
        }
    }
}
