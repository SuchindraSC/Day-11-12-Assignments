using System;

namespace INVENTORY_MANAGEMENT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME! THIS IS JSON INVENTORY DATA MANAGEMENT SYSTEM");

            InventoryManager inventorymanager = new InventoryManager();
            Console.ReadKey();
        }
    }
}
