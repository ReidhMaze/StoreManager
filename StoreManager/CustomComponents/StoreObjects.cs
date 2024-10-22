using Org.BouncyCastle.Asn1.Mozilla;
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

    public class StoreOrder
    {
        public int Id { get; }
        public string InvoiceNum { get; }
        public double TotalPrice { get; }
        public double Subtotal { get; }
        public double Vat { get; }
        public double TaxRate { get; }

        public DateTime Date { get; }
        public string StaffName { get; }

        public StoreOrder(int id, string invoiceNum, double totalPrice, double subtotal, double vat, double taxRate, DateTime date, string staffName)
        {
            Id = id;
            InvoiceNum = invoiceNum;
            TotalPrice = totalPrice;
            Subtotal = subtotal;
            Vat = vat;
            TaxRate = taxRate;
            Date = date;
            StaffName = staffName;
        }
    }

    public class InventoryLogEntry
    {
        public string ItemName { get; }
        public int Quantity { get; }
        public DateTime Date { get; }
        public string SupplierOrInvoice { get; }
        public string StaffName { get; }

        public InventoryLogEntry(string itemName, int quantity, DateTime date, string supplierOrInvoice, string staffName)
        {
            ItemName = itemName;
            Quantity = quantity;
            Date = date;
            SupplierOrInvoice = supplierOrInvoice;
            StaffName = staffName;
        }

    }

    public class Staff
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Gender { get; }
        public string EmailAddress { get; }
        public string MobileNum { get; }
        public string Username { get; }
        public string Password { get; }
        public string RoleType { get; }

        public Staff(int id, string firstName, string lastName, DateTime birthDate,
                string gender, string emailAddress, string mobileNum,
                string username, string password, string roleType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            EmailAddress = emailAddress;
            MobileNum = mobileNum;
            Username = username;
            Password = password;
            RoleType = roleType;
        }

    }

}
