using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using System.Collections.Generic;

namespace StudyingProgect.ApplicationCore
{
    public class State : IDb
    {
        public static List<Nomenclature> Nomenclaure { get; set; }

        public static List<Warehouse> Warehouses { get; set; }

        public static List<Incoming> Incomings { get; set; }

        public static List<Assemblage> Assemblage { get; set; }

        public static List<Consumption> Consumptions { get; set; }

        public static List<RemainNomenclature> RemainNomenclature { get; set; }

        public static List<RemainNomenclatureBalance> RemainNomenclatureBalance { get; set; }

        public State()
        {
            Nomenclaure = new List<Nomenclature>();
            Warehouses = new List<Warehouse>();
            Incomings = new List<Incoming>();
            Assemblage = new List<Assemblage>();
            Consumptions = new List<Consumption>();
            RemainNomenclature = new List<RemainNomenclature>();
            RemainNomenclatureBalance = new List<RemainNomenclatureBalance>();
        }

        public void Initialize()
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

        public List<T> GetTable<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
