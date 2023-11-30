using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class InventoryItem
    {

        public int ItemID;
        public String ItemName;
        public float Price;

        public InventoryItem(int id, String name, float price)
        {
            this.ItemID = id;
            this.ItemName = name;
            this.Price = price;
        }

        public void Edit(int id, String name, float price)
        {
            this.ItemID = id;
            this.ItemName = name;
            this.Price = price;
        }
    }
}
