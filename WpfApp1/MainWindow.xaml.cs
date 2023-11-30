using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Inventory inventory = new Inventory();

        public MainWindow()
        {
            InitializeComponent();

            ItemOptions.Initialize();

            foreach(InventoryItem i in ItemOptions.ItemList)
            {
                itemsLB.Items.Add(i.ItemName);
            }

        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();

            

        }

        private void addToInventory_Click(object sender, RoutedEventArgs e)
        {

            if(itemsLB.SelectedValue != null)
            {

                InventoryItem item = ItemOptions.getItemByName(itemsLB.SelectedValue.ToString());
                inventory.AddItem(item, int.Parse(itemListqtBox.Text));
                UpdateInventory();
            } else
            {
                MessageBox.Show("Please select an item from the list box!");

            }

        }

        void UpdateInventory()
        {
            inventoryLB.Items.Clear();
            inventoryQuantityLB.Items.Clear();
            inventoryPriceLB.Items.Clear();
            foreach (InventoryItem item in inventory.GetItems().Keys)
            {
                inventoryLB.Items.Add(item.ItemName);
                inventoryPriceLB.Items.Add(item.Price);
                inventoryQuantityLB.Items.Add(inventory.GetQuantity(item));
            }
            //this error is basically just when an item with the same name with a different price gets added to the inventory, it gets added to the same item ID,
/*            foreach(float item in ItemOptions.ItemList.k)
            {
                inventoryPriceLB.Items.Add(item);
            }*/
        }

        void UpdateItemList()
        {
            itemsLB.Items.Clear();
            foreach (InventoryItem i in ItemOptions.ItemList)
            {
                itemsLB.Items.Add(i.ItemName);
            }
            UpdateInventory();
        }

        private void itemListqtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

/*        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem item = ItemOptions.getItemByName("Bread");

            InventoryItem newItem = new InventoryItem(item.ItemID, "Soggy Bread", 0.5f);

            inventory.EditItem(item, newItem);

            UpdateInventory();
            UpdateItemList();
        }*/

        private void removeFromInventory_Click(object sender, RoutedEventArgs e)
        {
            var cache = inventoryLB.SelectedValue;
            if (inventoryLB.SelectedValue != null)
            {

                InventoryItem item = ItemOptions.getItemByName(inventoryLB.SelectedValue.ToString());
                inventory.RemoveItem(item, int.Parse(invListqtBox.Text));
                UpdateInventory();
                inventoryLB.SelectedValue = cache;
            }
            else
            {
                MessageBox.Show("Please select an item from the list box!");

            }
        }

        private void createNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            ItemOptions.CreateItem(createNewItemNameTextBox.Text, float.Parse(createNewItemPriceTextBox.Text));

            UpdateItemList();
        }

        private void editItemInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (itemsLB.SelectedValue != null)
            {
                try
                {
                    ItemOptions.UpdatePriceByItem(ItemOptions.getItemByName(itemsLB.SelectedValue.ToString()), float.Parse(editItemPriceTextBox.Text));
                    ItemOptions.UpdateNameByItem(ItemOptions.getItemByName(itemsLB.SelectedValue.ToString()), editItemNameTextBox.Text);
                    UpdateItemList();
                    itemsLB.SelectedValue = editItemNameTextBox.Text;
                } catch(Exception exc)
                {
                    MessageBox.Show("Please set a value for all fields");
                }
                
            }
            else
            {
                MessageBox.Show("Please select an item from the list box!");

            }

        }

        private void itemsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(itemsLB.SelectedValue != null)
            {
                String name = itemsLB.SelectedValue.ToString();
                editItemNameTextBox.Text = itemsLB.SelectedValue.ToString();
                editItemPriceTextBox.Text = ItemOptions.getItemByName(itemsLB.SelectedValue.ToString()).Price.ToString();
            }

        }

        private void inventoryPriceLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inventoryQuantityLB.SelectedIndex = inventoryPriceLB.SelectedIndex;
            inventoryLB.SelectedIndex = inventoryPriceLB.SelectedIndex;
        }

        private void inventoryLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inventoryQuantityLB.SelectedIndex = inventoryLB.SelectedIndex;
            inventoryPriceLB.SelectedIndex = inventoryLB.SelectedIndex;
        }

        private void inventoryQuantityLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inventoryPriceLB.SelectedIndex = inventoryQuantityLB.SelectedIndex;
            inventoryLB.SelectedIndex = inventoryQuantityLB.SelectedIndex;
        }

    }
}
