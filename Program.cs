using AssetTracking;

//Create some offices with their local currency's code and the exchange rate from USD to local currency
Office skövde = new("Skövde", "SEK", 10.49);
Office london = new("London", "GDP", 0.8);
Office newYork = new("New York", "USD", 1.00);


//Create a populated list of assets
List<Asset> assets =
[
    new Laptop("Asus", "2024-01-15", 500, skövde),
    new Laptop("Macintosh", "2021-05-20", 1000, skövde),
    new Laptop("HP", "01/26/2023", 800, london),
    new Laptop("Lenovo", "03/19/2021", 900, newYork),

    new Phone("Nokia", "23-08-27", 200, newYork),
    new Phone ("Motorola", "2020-12-24", 300, london),
    new Phone ("Iphone", "2021-06-20", 1250, london)
];

//Display the list of assets
PrintList();




void PrintList()
{
    //Prints information about each asset.
    //The assets are sorted by which office they belong to, then by their purchase date

    List<Asset> assetsSorted = assets.OrderBy(a => a.Office.Name).ThenBy(a => a.PurchaseDate).ToList();

    Console.WriteLine("Type".PadRight(16) + "Brand".PadRight(16) + "Office".PadRight(16) + "Purchase Date".PadRight(16)
                        + "Price in USD".PadRight(16) + "Local Currency".PadRight(16) + "Local Price");
    Console.WriteLine("----".PadRight(16) + "-----".PadRight(16) + "------".PadRight(16) + "-------------".PadRight(16)
                        + "------------".PadRight(16) + "--------------".PadRight(16) + "-----------");

    foreach (Asset a in assetsSorted)
    {
        // Calculate the asset's price in the local currency.
        int localPrice = (int)(a.Price * a.Office.ExchangeRate);

        string stringToWrite = a.GetType().Name.PadRight(16) + a.Brand.PadRight(16) + a.Office.Name.PadRight(16)
                                + a.PurchaseDate.ToString("yyyy-MM-dd").PadRight(16) + a.Price.ToString().PadRight(16)
                                + a.Office.currencyCode.PadRight(16) + localPrice.ToString().PadRight(10);

        //Calculate the time remaining until the expiration date of the asset.
        //Indicate if the asset is expiring soon or has expired by displaying in different colors and adding text.
        TimeSpan timeLeft = a.ExpirationDate - DateTime.Now;
        if (timeLeft.Days < 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            stringToWrite += "EXPIRED";
        }
        else if (timeLeft.Days < 90) Console.ForegroundColor = ConsoleColor.Red;
        else if (timeLeft.Days < 180) Console.ForegroundColor = ConsoleColor.Yellow; 

        Console.WriteLine(stringToWrite);
        Console.ResetColor();
    }
}




Console.ReadLine();


