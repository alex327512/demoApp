using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture
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

        public List<Specification> Specification { get; set; }

        public State()
        {
            Nomenclature = new List<Nomenclature>();
            Warehouses = new List<Warehouse>();
            Incomings = new List<Incoming>();
            Assemblage = new List<Assemblage>();
            Consumptions = new List<Consumption>();
            RemainNomenclature = new List<RemainNomenclature>();
            RemainNomenclatureBalance = new List<RemainNomenclatureBalance>();
            Specification = new List<Specification>();
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

            Nomenclature.Add(new Nomenclature("TYPE-A"));
            Nomenclature.Add(new Nomenclature("TYPE-B"));
            Nomenclature.Add(new Nomenclature("TYPE-C"));

            Warehouses.Add(new Warehouse("Main"));
            Warehouses.Add(new Warehouse("Additional"));
        }

        //// как задать ограничение по классу? where T : class не работает
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
            else if (type == typeof(Specification))
            {
                return (List<T>)(object)Specification;
            }
            return (List<T>)null;
        }

        public void RecalcBalances<T>() where T : Register
        {
            Type type = typeof(T);
        }

        private Recalc()
        {

        }

    }
}
