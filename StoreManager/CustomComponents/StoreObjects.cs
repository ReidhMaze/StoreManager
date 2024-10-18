using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreObjects
{

    public class Item
    {
        public int Id { get; }
        public int ItemCode { get; }
        public string Name { get; }
        public double Price { get; }
        public double CostPerItem { get; }
        public string Size { get; }
        public string Type { get; }
        public int CurrentStocks { get; }
        public string ImgName { get; }
        public string SupplierName { get; }
        public int RestockThreshold { get; }

        public Item(int id, string name, string size, double price, int stocks)
        {
            this.Id = id;
            this.Name = name;
            this.Size = size;
            this.Price = price;
            this.CurrentStocks = stocks;
        }

        public Item(int id, int itemCode, string name, double price, double costPerItem, string size, string type, int currentStocks, string imgLocation)
        {
            this.Id = id;
            this.ItemCode = itemCode;
            this.Name = name;
            this.Price = price;
            this.CostPerItem = costPerItem;
            this.Size = size;
            this.Type = type;
            this.CurrentStocks = currentStocks;
            this.ImgName = imgLocation;
        }

        public Item(int id, int itemCode, string name, double price, double costPerItem, string size, string type, int currentStocks, int restockThreshold, string supplierName, string imgLocation)
        {
            this.Id = id;
            this.ItemCode = itemCode;
            this.Name = name;
            this.Price = price;
            this.CostPerItem = costPerItem;
            this.Size = size;
            this.Type = type;
            this.CurrentStocks = currentStocks;
            this.ImgName = imgLocation;
            this.SupplierName = supplierName;
            this.RestockThreshold = restockThreshold;
        }

        public CartItem ToCartItem()
        {
            return new CartItem(this.Id, this.ItemCode, this.Name, this.Size, this.Price, this.CurrentStocks, this.CostPerItem);
        }

        public void Display()
        {
            Debug.WriteLine(Name + " " + " " + Size + " " + Price + " " + CurrentStocks);
        }

    }

    public class CartItem
    {
        public int Id { get; }
        public string Name { get; }
        public string Size { get; }
        public double CostPerItem { get; }
        public int ItemCode { get; }


        private double price;
        private int qty = 1;
        private int stocksLeft;


        public CartItem(int id, int itemCode, string name, string size, double price, int stocksLeft, double costPerItem)
        {
            this.Id = id;
            this.ItemCode = itemCode;
            this.Name = name;
            this.Size = size;
            this.price = price;
            this.stocksLeft = stocksLeft;
            this.CostPerItem = costPerItem;
        }

        public void IncrementQty()
        {
            qty++;
        }

        public void DecrementQty()
        {
            if (qty > 0)
            {
                qty--;
            }
        }

        public int Qty
        {
            get { return qty; }

        }

        public double Price
        {
            get { return this.price; }
        }

        public int StocksLeft
        {
            get { return this.stocksLeft; }
        }
    }
}
