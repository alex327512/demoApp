using System;
using System.Collections.Generic;
using studyingProgect.Models;

namespace studyingProgect
{
    class Program
    {
        private static void AddLineItem(LineItem lineItem, Nomenclature nomenclature, decimal price, decimal quantiy)
        {
            lineItem.Nomenclature = nomenclature;
            lineItem.Quantity = quantiy;
            lineItem.Price = price;
            lineItem.Sum = quantiy * price;           
        }
        private static void AddIncoming()
        {
            var incoming = new Incoming();

            incoming.Warehouse = State.Warehouses.Find(w => w.Description == "Main");

            LineItem lineItem = new LineItem();
            Random rnd = new Random();

            foreach (var item in State.Nomenclaure)
            {
                //int currPrice = rnd.Next(50, 150);
                int currPrice = 100;
                //int currAmount = rnd.Next(5, 15);
                int currAmount = 120;
                AddLineItem(lineItem, item, currPrice, currAmount);
                incoming.ListOfNomenc.Add(lineItem);
            }

            State.Incomings.Add(incoming);
            incoming.Write();
        }
        private static void AddConsumption()
        {
            var consumption = new Consumption();

            consumption.Warehouse = State.Warehouses.Find(w => w.Description == "Main");

            LineItem lineItem = new LineItem();
            Random rnd = new Random();

            foreach (var item in State.Nomenclaure)
            {
                int currPrice = 100;
                //int currPrice = rnd.Next(50, 150);
                int currAmount = 100;
               // int currAmount = rnd.Next(5, 15);
                AddLineItem(lineItem, item, currPrice, currAmount);
                consumption.ListOfNomenc.Add(lineItem);
            }

            State.Consumptions.Add(consumption);
            consumption.Write();
        }

        //private static void MakeAssemblage()
        //{
        //    var consumption = new Consumption();

        //    consumption.Warehouse = State.Warehouses.Find(w => w.Description == "Main");

        //    LineItem lineItem = new LineItem();
        //    Random rnd = new Random();

        //    foreach (var item in State.Nomenclaure)
        //    {
        //        int currPrice = rnd.Next(50, 100);
        //        int currAmount = rnd.Next(5, 10);
        //        AddLineItem(lineItem, item, currPrice, currAmount);
        //        consumption.ListOfNomenc.Add(lineItem);
        //    }

        //    State.Consumptions.Add(consumption);

        //}

        //private static void AddChangesToHistory()
        //{
        //    var history = new History();
        //    foreach(var inc in State.Incomings)
        //    {
                
        //        history.Warehouse.Add(inc.Warehouse.Description);
        //        history.Date.Add(inc.Date);
        //        history.IncOrCons.Add(Incoming);
                
        //        foreach(var listItem in inc.ListOfNomenc)
        //        {
        //            history.Nomenclature.Add(listItem.Nomenclature);
        //            history.Quantity.Add(listItem.Quantity);

        //        }
        //    }
        //    foreach (var cons in State.Consumptions)
        //    {
        //        history.Warehouse.Add(cons.Warehouse.Description);
        //        history.Date.Add(cons.Date);
        //        history.IncOrCons.Add(Consumption);

        //        foreach (var listItem in cons.ListOfNomenc)
        //        {
        //            history.Nomenclature.Add(listItem.Nomenclature);
        //            history.Quantity.Add(listItem.Quantity);
        //            //history.Nomenclature = listItem.Nomenclature;
        //        }
        //    }
        //    State.History.Add(history);
        //}

        static void Main(string[] args)
        {
            State.Initialize();

            LineItem lineItem = new LineItem();

            AddIncoming();
            AddIncoming();
            AddConsumption();

     

            foreach(var remainNomenclature in State.RemainNomenclature)
            {
                Console.WriteLine(remainNomenclature);
            }
            Console.WriteLine(State.RemainNomenclature);
            foreach (var inc in State.Incomings)
            {
               
               
                 Console.WriteLine(inc);
                
              
            }
            foreach (var cons in State.Consumptions)
            {
                Console.WriteLine(cons);
            }



            //for (int i = 0; i < State.Nomenclaure.Count; i++)
            //{
            //    lineItem.Nomenclature = State.Nomenclaure[i];
            //    Console.WriteLine(lineItem.Nomenclature.Description);
            //}




            //foreach (var nom in State.Nomenclaure)
            //{
            //    Console.WriteLine(nom.Description);
            //}

            Console.ReadLine();

            //static bool DeleteLineItem(string item, LineItem lineItem)
            //{
            //    foreach (var currentLineItem in lineItem)
            //    {

            //    }
            //    return false;
            //}
            
            //LineItem lineItem1 = addLineItem(Mouse, 3, 500);
            //Console.WriteLine(lineItem1);

            //void deleteLineItem(string nomenclature)
            //{
            //    string nomenc = nomenclature;
            //    foreach (var name in lineItem)
            //    {
            //        if(nomenc == name.Nomenclature.Description)
            //        {
            //            lineItem.Remove(name);
            //        }

            //    }
            //} 

            //Dictionary<string, int> componentsList = new Dictionary<string, int>();
            //Console.WriteLine("please write down components names and amount");
           
            //ConsoleKeyInfo btn;
            


            //do
            //{
            //    btn = Console.ReadKey();
            //    if (btn.Key == ConsoleKey.Escape)
            //    {
            //        break;
            //    }
            //    Console.WriteLine("components names");
            //    string currentName = Console.ReadLine();
            //    if (!componentsList.ContainsKey(currentName))
            //    {
                    
                   
                   
            //        try
            //        {
            //            Console.WriteLine("components amount");
            //            int currentAmount = Convert.ToInt32(Console.ReadLine());
            //            componentsList.Add(currentName, currentAmount);
            //        }
            //        catch
            //        {
                        
            //            Console.WriteLine("wrong value");
            //            break;
            //        }

            //    }
                
            //}
            //while (!(btn.Key == ConsoleKey.Escape));


            //Console.WriteLine("result");

            //int min = 10000000;
            //foreach (KeyValuePair<string, Int32> components in componentsList)
            //{
            //    Console.WriteLine($"Component {components.Key}: {components.Value}");
            //    if(min > Convert.ToInt32(components.Value))
            //    {
            //        min = Convert.ToInt32(components.Value);
            //    }
            //}
            
            //if(componentsList.Count < 5)
            //{
            //    Console.WriteLine("You dont have enough parts of computer");
            //}
            //else
            //{
            //    Console.WriteLine($"You could sell {min} computers");
            //}





        }
    
        
    }
}
