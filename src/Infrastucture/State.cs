using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using System;
using System.Collections.Generic;

namespace StudyingProgect.ApplicationCore
{
    public class State : IDb
    {
        public  List<Nomenclature> Nomenclature { get; set; }

        public  List<Warehouse> Warehouses { get; set; }

        public  List<Incoming> Incomings { get; set; }

        public  List<Assemblage> Assemblage { get; set; }

        public  List<Consumption> Consumptions { get; set; }

        public  List<RemainNomenclature> RemainNomenclature { get; set; }

        public  List<RemainNomenclatureBalance> RemainNomenclatureBalance { get; set; }

        public State()
        {
            Nomenclature = new List<Nomenclature>();
            Warehouses = new List<Warehouse>();
            Incomings = new List<Incoming>();
            Assemblage = new List<Assemblage>();
            Consumptions = new List<Consumption>();
            RemainNomenclature = new List<RemainNomenclature>();
            RemainNomenclatureBalance = new List<RemainNomenclatureBalance>();
        }

        public void Initialize()
        {
            Nomenclature.Add(new Nomenclature("AMD"));
            Nomenclature.Add(new Nomenclature("INTEL"));
            Nomenclature.Add(new Nomenclature("NVIDIA"));
            Nomenclature.Add(new Nomenclature("KINGSTON"));
            Nomenclature.Add(new Nomenclature("CORSAIR"));
            Nomenclature.Add(new Nomenclature("WD"));
            Nomenclature.Add(new Nomenclature("SEAGATE"));
            Nomenclature.Add(new Nomenclature("SAMSUNG"));
            Nomenclature.Add(new Nomenclature("PHILIPS"));
            Warehouses.Add(new Warehouse("Main"));
            Warehouses.Add(new Warehouse("Additional"));
        }

        public List<T> GetTable<T>()
        {
            Type type = typeof(T);

            if (type == typeof(Nomenclature))
            {
                return (List<T>)(object)Nomenclature;
            }
            else if (type == typeof(Warehouse))
            {
                return (List<T>)(object)Warehouses;
            }
            else if (type == typeof(Incoming))
            {
                return (List<T>)(object)Incomings;
            }
            else if (type == typeof(Assemblage))
            {
                return (List<T>)(object)Assemblage;
            }
            else if (type == typeof(Consumption))
            {
                return (List<T>)(object)Consumptions;
            }
            else if (type == typeof(RemainNomenclature))
            {
                return (List<T>)(object)RemainNomenclature;
            }
            else if (type == typeof(RemainNomenclatureBalance))
            {
                return (List<T>)(object)RemainNomenclatureBalance;
            }
            return (List<T>)null;
        }
    }
}
