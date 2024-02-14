using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    abstract class Asset
    {
        public Asset(string brand, DateOnly purchaseDate, int price, string office)
        {
            Price = price;
            Brand = brand;
            PurchaseDate = purchaseDate;
            ExpireTime = purchaseDate.AddYears(3);
            Office = office;
        }        
        public Asset(string brand, string purchaseDate, int price, string office)
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
            ExpireTime = PurchaseDate.AddYears(3);
            Office = office;
        }

        public int Price { get; set; }
        public string Brand { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public DateOnly ExpireTime { get; set; }
        public string Office { get; set; }

    }

    class Laptop : Asset
    {
        public Laptop( string brand, DateOnly purchaseDate, int price, string office) : base(brand, purchaseDate, price, office) { }
        public Laptop( string brand, string purchaseDate, int price, string office) : base(brand, purchaseDate, price, office) { }
    }
    
    class Phone : Asset
    {
        public Phone( string brand, DateOnly purchaseDate, int price, string office) : base(brand, purchaseDate, price, office) { }
        public Phone( string brand, string purchaseDate, int price, string office) : base(brand, purchaseDate, price, office) { }
    }



}
