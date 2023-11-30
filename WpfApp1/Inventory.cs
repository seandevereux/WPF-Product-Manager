using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{

    public class Inventory
    {

        private Dictionary<InventoryItem, int> Items = new Dictionary<InventoryItem, int>();

        public Inventory()
        {

        }

        public void AddItem(InventoryItem item, int quantity)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] += quantity;
            }
            else
            {
                Items[item] = quantity;
            }
        }

        public Dictionary<InventoryItem, int> GetItems()
        {
            return Items;
        }

        public int GetQuantity(InventoryItem item)
        {
            if (Items.ContainsKey(item))
            {
                return Items[item];
            }
            else
            {
                return 0;
            }
        }

        public string GetItemsUI()
        {
            string o = "";
            foreach (var item in Items)
            {
                o = o + "Item : " + item.Key.ItemName + " Price : " + item.Key.Price + " Quantity : " + item.Value;
            }
            return o;
        }

        public void EditItem(InventoryItem itemToEdit, InventoryItem newItem)
        {
            ItemOptions.UpdateNameByID(itemToEdit.ItemID, newItem.ItemName);
            ItemOptions.UpdatePriceByID(itemToEdit.ItemID, newItem.Price);
        }

        public void RemoveItem(InventoryItem item, int quantity)
        {
            if (Items.ContainsKey(item))
            {
                if (Items[item] - quantity <= 0)
                {
                    //MessageBox.Show(Items[item].ToString() + " +" +  quantity);
                    Items.Remove(item);
                    
                }
                else
                {
                    Items[item] -= quantity;
                }
            }
            else
            {
                Console.WriteLine("No item present");
            }
        }
    }
}

