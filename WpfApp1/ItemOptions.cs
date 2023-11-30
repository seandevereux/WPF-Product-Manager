using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    public static class ItemOptions
    {

        public static List<InventoryItem> ItemList = new List<InventoryItem>();

        public static void Initialize()
        {

            InventoryItem breadItem = new InventoryItem(0, "Bread", 1f);
            InventoryItem watchItem = new InventoryItem(1, "Watch", 50f);
            InventoryItem televisionItem = new InventoryItem(2, "Television", 750f);

            ItemList.Add(breadItem);
            ItemList.Add(watchItem);
            ItemList.Add(televisionItem);

        }

        public static void PrintItems()
        {
            int index = 0;
            foreach (InventoryItem item in ItemList) { 
            }
        }

        public static InventoryItem getItemByID(int id)
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                if (inventoryItem.ItemID == id)
                {
                    return inventoryItem;
                }
            }
            return null;
        }


        public static InventoryItem getItemByName(string name)
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                if (inventoryItem.ItemName == name)
                {
                    return inventoryItem;
                }
            }
            return null;
        }

        public static void UpdatePriceByID(int id, float newPrice)
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                if (inventoryItem.ItemID == id)
                {
                    inventoryItem.Price = newPrice;
                }
            }
        }



        public static void UpdateNameByID(int id, String newName)
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                if (inventoryItem.ItemID == id)
                {
                    inventoryItem.ItemName = newName;
                }
            }
        }

        public static void UpdatePriceByItem(InventoryItem item, float newPrice)
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                if (inventoryItem == item)
                {
                    inventoryItem.Price = newPrice;
                }
            }
        }

        public static void UpdateNameByItem(InventoryItem item, String newName)
        {
            foreach (InventoryItem inventoryItem in ItemList)
            {
                if (inventoryItem == item)
                {
                    inventoryItem.ItemName = newName;
                }
            }
        }

        public static void CreateItem(String ItemName, float price)
        {
            InventoryItem newItem = new InventoryItem(ItemList.Count() + 1, ItemName, price);

            ItemList.Add(newItem);
        }
    }

}
