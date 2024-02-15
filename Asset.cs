using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    abstract class Asset
    {
        //Stores all the information about an asset.
        //One constructor recieves DateOnly. The other recieves a string and tries to convert it to a date.
        //Assets have an expiration date which is 3 years after their purchase date.
        public Asset(string brand, DateOnly purchaseDate, int price, Office office)
        {
            Price = price;
            Brand = brand;
            PurchaseDate = purchaseDate;
            ExpirationDate = purchaseDate.AddYears(3);
            Office = office;
        }        
        public Asset(string brand, string purchaseDate, int price, Office office)
        {
            try
            {
                PurchaseDate = DateOnly.Parse(purchaseDate);
            }
            catch (Exception)
            {

                Console.WriteLine("An invalid date was entered");
            }

            Price = price;
            Brand = brand;            
            ExpirationDate = PurchaseDate.AddYears(3);
            Office = office;
        }

        public int Price { get; set; }
        public string Brand { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public Office Office { get; set; }

    }

    //Different types of assets. The Constructors use the base constructor.

    class Laptop : Asset
    {
        public Laptop( string brand, DateOnly purchaseDate, int price, Office office) : base(brand, purchaseDate, price, office) { }
        public Laptop( string brand, string purchaseDate, int price, Office office) : base(brand, purchaseDate, price, office) { }
    }
    
    class Phone : Asset
    {
        public Phone( string brand, DateOnly purchaseDate, int price, Office office) : base(brand, purchaseDate, price, office) { }
        public Phone( string brand, string purchaseDate, int price, Office office) : base(brand, purchaseDate, price, office) { }
    }



}
