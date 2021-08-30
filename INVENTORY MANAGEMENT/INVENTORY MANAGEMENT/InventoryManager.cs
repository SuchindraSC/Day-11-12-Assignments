using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;

namespace INVENTORY_MANAGEMENT
{
    public class InventoryManager
    {
       public InventoryManager()
        {
            Console.WriteLine("Enter The Option \n1. Add To Inventory \n2. Display Inventory");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("You Selected 'Addition To Inventory'");
                    List<Inventory> InventoryList = new List<Inventory>();
                    Inventory RiceList = new Inventory("Rice", 45, 500);
                    Inventory PulseList = new Inventory("Wheat", 35, 200);
                    Inventory WheatList = new Inventory("Pulses", 120, 50);
                    InventoryList.Add(RiceList);
                    InventoryList.Add(PulseList);
                    InventoryList.Add(WheatList);
                    string file = JsonConvert.SerializeObject(InventoryList);
                    File.WriteAllText(@"C:\Users\ADVANCED\Desktop\Day 11 & 12 Assignment\INVENTORY MANAGEMENT\INVENTORY MANAGEMENT\Crops.json", file);
                    Console.WriteLine("Details Of Inventory Added Succesfully");
                           
                    break;
                case 2:
                    Console.WriteLine("You Selected To Display Inventory");
                    string Data = File.ReadAllText(@"C:\Users\ADVANCED\Desktop\Day 11 & 12 Assignment\INVENTORY MANAGEMENT\INVENTORY MANAGEMENT\Crops.json");
                    List<Inventory> DisplayData = JsonConvert.DeserializeObject<List<Inventory>>(Data);
                    foreach (var item in DisplayData)
                    {
                        Console.WriteLine("Name: "+item.Name);
                        Console.WriteLine("Price: "+item.Price);
                        Console.WriteLine("Weight: "+item.Weight);
                        
                        Console.WriteLine("Total Value of "+item.Name+" is "+(item.Weight*item.Price));
                    }
                    //string Data = File.ReadAllText(@"C:\Users\ADVANCED\Desktop\Day 11 & 12 Assignment\INVENTORY MANAGEMENT\INVENTORY MANAGEMENT\Crops.json");
                    break;
                default:
                    if(option > 2)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    break;
            }
        }
    }
}
