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
        public string Name { get; }
        public string Size { get; }
        public double Price { get; }
        public int Stocks { get; }

        public Item(int id, string name, string size, double price, int stocks)
        {
            this.Id = id;
            this.Name = name;
            this.Size = size;
            this.Price = price;
            this.Stocks = stocks;
        }

        public CartItem ToCartItem()
        {
            return new CartItem(this.Id, this.Name, this.Size, this.Price, this.Stocks);
        }

        public void Display()
        {
            Debug.WriteLine(Name + " " + " " + Size + " " + Price + " " + Stocks);
        }

    }

    public class CartItem
    {
        public int Id { get; }
        public string Name { get; }
        public string Size { get; }
        private double price;
        private int qty = 1;
        private int stocksLeft;


        public CartItem(int id, string name, string size, double price, int stocksLeft)
        {
            this.Id = id;
            this.Name = name;
            this.Size = size;
            this.price = price;
            this.stocksLeft = stocksLeft;
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
