using System;
using System.Collections.Generic;
using studyingProgect.Models;

namespace studyingProgect
{
    class Program
    {
        static void Main(string[] args)
        {
            State.Initialize();

            LineItem lineItem = new LineItem();

             void addLineItem(string nomenclature, decimal quantiy, decimal price){
                lineItem.Nomenclature.Description = nomenclature;
                lineItem.Quantity = quantiy;
                lineItem.Price = price;
                lineItem.Amount = quantiy * price;

            }
            



            addLineItem("Mouse", 3, 500);
            Console.WriteLine(lineItem);

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
